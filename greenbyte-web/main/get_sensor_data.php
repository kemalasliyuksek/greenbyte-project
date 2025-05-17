<?php
header('Content-Type: application/json');
date_default_timezone_set('Europe/Istanbul');
session_start();

// Oturum kontrolü
if (!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true) {
    echo json_encode(['error' => 'Oturum doğrulanamadı']);
    exit;
}

// DB bağlantı bilgileri
$dsn = "mysql:host=92.205.171.9;dbname=greenbyte;charset=utf8mb4";
$db_user = "admin";
$db_pass = "Ke3@1.3ySq1";

// Varsayılan response
$response = [
    'sicaklik' => "--",
    'nem' => "--",
    'isik_seviyesi' => "--",
    'toprak_nemi' => "--",
    'co2' => "---",
    'su_seviyesi' => "--",
    'son_guncelleme' => "--:--",
    'sicaklik_tarihce' => [],
    'nem_tarihce' => [],
    'hava_durumu' => [ 'sicaklik' => '--', 'yer' => 'Bursa' ],
    'isik_detay' => [ 'gun_isigi' => '--', 'isik_suresi' => '--' ],
    'su_deposu' => [ 'hacim' => '--', 'kapasite' => '--', 'yeterlilik' => '--' ],
    'co2_detay' => [ 'optimal_aralik' => '--', 'hava_kalitesi' => '--', 'duman' => '--' ]
];

try {
    $pdo = new PDO($dsn, $db_user, $db_pass, [
        PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION
    ]);

    // 1. Kullanıcıya ait sera ID'sini bul
    $stmt = $pdo->prepare("SELECT id FROM seralar WHERE kullanici_id = ? LIMIT 1");
    $stmt->execute([$_SESSION["id"]]);
    $sera = $stmt->fetch(PDO::FETCH_ASSOC);

    if (!$sera) {
        echo json_encode($response); exit;
    }

    $sera_id = $sera['id'];

    // 2. Son sensör verileri
    $stmt = $pdo->prepare("
        SELECT s.id, s.ad AS sensor_adi, v.deger, v.ek_veri, v.kayit_zamani
        FROM sensorler s
        LEFT JOIN (
            SELECT sensor_id, deger, ek_veri, kayit_zamani
            FROM sensor_verileri
            WHERE kayit_zamani = (
                SELECT MAX(kv.kayit_zamani) FROM sensor_verileri kv WHERE kv.sensor_id = sensor_verileri.sensor_id
            )
        ) v ON s.id = v.sensor_id
        WHERE s.sera_id = ?
    ");
    $stmt->execute([$sera_id]);

    $sensor_ids = ['sicaklik' => null, 'nem' => null];

    foreach ($stmt->fetchAll(PDO::FETCH_ASSOC) as $row) {
        $adi = strtolower($row['sensor_adi']);
        $deger = $row['deger'];
        $ek = $row['ek_veri'];
        $zaman = $row['kayit_zamani'];

        if ($zaman) $response['son_guncelleme'] = date("H:i", strtotime($zaman));

        if ($deger !== null) {
            // Geliştirilmiş sensör eşleştirme mantığı
            if (preg_match('/(sicakl|sıcakl|heat|temp)/i', $adi)) {
                $response['sicaklik'] = floatval($deger);
                $sensor_ids['sicaklik'] = $row['id'];
            } 
            elseif (preg_match('/(nem|humid)/i', $adi) && !preg_match('/(toprak|soil)/i', $adi)) {
                $response['nem'] = floatval($deger);
                $sensor_ids['nem'] = $row['id'];
            } 
            elseif (preg_match('/(isik|ışık|light)/i', $adi)) {
                $response['isik_seviyesi'] = intval($deger);
            } 
            elseif (preg_match('/(toprak|soil)/i', $adi)) {
                $response['toprak_nemi'] = intval($deger);
            } 
            elseif (preg_match('/(su|water)/i', $adi)) {
                $response['su_seviyesi'] = intval($deger);
            } 
            elseif (preg_match('/(hava|air|co2)/i', $adi)) {
                if ($ek === 'co2ppm') {
                    $response['co2'] = intval($deger);
                }
                else {
                    $response['hava_kalitesi'] = intval($deger);
                }
            }
        }
    }

    // CO2 değerini ek_veri = 'co2ppm' olmayan durumlar için de kontrol et
    if ($response['co2'] === "---") {
        $stmt = $pdo->prepare("
            SELECT deger 
            FROM sensor_verileri 
            WHERE sensor_id IN (
                SELECT id FROM sensorler WHERE sera_id = ? AND (ad LIKE '%co2%' OR ad LIKE '%hava%')
            )
            AND ek_veri = 'co2ppm'
            ORDER BY kayit_zamani DESC 
            LIMIT 1
        ");
        $stmt->execute([$sera_id]);
        
        if ($stmt->rowCount() > 0) {
            $row = $stmt->fetch(PDO::FETCH_ASSOC);
            $response['co2'] = intval($row['deger']);
        }
    }

    // 3. Geçmiş grafik verisi (sadece sıcaklık ve nem)
    $range = $_GET['range'] ?? 'day';
    $sensor = $_GET['sensor'] ?? null;
    $limit = ['day' => 8, 'week' => 7, 'month' => 30][$range] ?? 8;
    $interval = ['day' => '24 HOUR', 'week' => '7 DAY', 'month' => '30 DAY'][$range] ?? '24 HOUR';

    foreach (['sicaklik', 'nem'] as $tip) {
        if (($sensor === null || $sensor === $tip) && $sensor_ids[$tip]) {
            $stmt = $pdo->prepare("
                SELECT ROUND(deger, 1) AS deger, DATE_FORMAT(kayit_zamani, '%H:%i') AS zaman
                FROM sensor_verileri
                WHERE sensor_id = ? AND kayit_zamani >= DATE_SUB(NOW(), INTERVAL $interval)
                ORDER BY kayit_zamani ASC LIMIT $limit
            ");
            $stmt->execute([$sensor_ids[$tip]]);
            $history = $stmt->fetchAll(PDO::FETCH_ASSOC);

            $response["{$tip}_tarihce"] = $history;

            if (!empty($history)) {
                $values = array_column($history, 'deger');
                $response["{$tip}_min"] = min($values) . ($tip === 'nem' ? '%' : '°C');
                $response["{$tip}_max"] = max($values) . ($tip === 'nem' ? '%' : '°C');
                $response["{$tip}_avg"] = round(array_sum($values) / count($values), 1) . ($tip === 'nem' ? '%' : '°C');
            }
        }
    }

    // 4. Ayarlar tablosu (ekstra bilgiler)
    $stmt = $pdo->prepare("SELECT ayar_tipi, ayar_adi, deger FROM sera_ayarlari WHERE sera_id = ?");
    $stmt->execute([$sera_id]);

    foreach ($stmt->fetchAll(PDO::FETCH_ASSOC) as $row) {
        $type = $row['ayar_tipi'];
        $key = $row['ayar_adi'];
        $value = $row['deger'];

        if (isset($response[$type]) && is_array($response[$type])) {
            $response[$type][$key] = $value;
        }
    }

    echo json_encode($response, JSON_UNESCAPED_UNICODE);

} catch (PDOException $e) {
    echo json_encode(['error' => 'Veritabanı hatası', 'detail' => $e->getMessage()]);
}
?>