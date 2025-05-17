<?php
// Türkiye zaman dilimini ayarla
date_default_timezone_set('Europe/Istanbul');

// Oturum kontrolü
session_start();

// Debug için
error_reporting(E_ALL);
ini_set('display_errors', 1);

// Kullanıcı giriş yapmış mı kontrol et
if (!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true) {
    http_response_code(401);
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Oturum açmanız gerekiyor']);
    exit;
}

// Veritabanı bağlantı bilgileri
$servername = "92.205.171.9";
$username = "admin";
$password = "Ke3@1.3ySq1";
$dbname = "greenbyte";

// Cevap için header ayarları
header('Content-Type: application/json');

// İstek tipini kontrol et (GET parametresi)
$istek_tipi = isset($_GET['tip']) ? $_GET['tip'] : 'son_veriler';
$sera_id = isset($_GET['sera_id']) ? intval($_GET['sera_id']) : null;

// Kullanıcının sera_id'sini alıyoruz (kullanıcıya ait ilk sera)
if ($sera_id === null) {
    try {
        $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        
        $stmt = $conn->prepare("
            SELECT s.id FROM seralar s
            WHERE s.kullanici_id = :kullanici_id
            LIMIT 1
        ");
        $stmt->bindParam(':kullanici_id', $_SESSION["id"], PDO::PARAM_INT);
        $stmt->execute();
        
        if ($stmt->rowCount() > 0) {
            $row = $stmt->fetch(PDO::FETCH_ASSOC);
            $sera_id = $row['id'];
        } else {
            // Eğer kullanıcının bir serası yoksa, yeni bir sera oluşturalım
            $stmt = $conn->prepare("
                INSERT INTO seralar (kullanici_id, ad, konum)
                VALUES (:kullanici_id, 'Varsayılan Sera', 'Bursa')
            ");
            $stmt->bindParam(':kullanici_id', $_SESSION["id"], PDO::PARAM_INT);
            $stmt->execute();
            
            $sera_id = $conn->lastInsertId();
            
            // Debug bilgisi
            error_log("Yeni sera oluşturuldu. ID: " . $sera_id);
        }
    } catch (PDOException $e) {
        http_response_code(500);
        echo json_encode(['durum' => 'hata', 'mesaj' => 'Veritabanı hatası: ' . $e->getMessage()]);
        exit;
    }
}

try {
    // Veritabanı bağlantısı
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    
    // İstek tipine göre farklı sorgular yapılır
    switch ($istek_tipi) {
        case 'son_veriler':
            // Her sensör için en son değerleri getir
            $result = getSonVeriler($conn, $sera_id);
            echo json_encode($result);
            break;
            
        case 'grafik_verileri':
            // Grafik için belirli bir zaman aralığındaki verileri getir
            $sensor_tur = isset($_GET['sensor']) ? $_GET['sensor'] : null;
            $zaman_aralik = isset($_GET['aralik']) ? $_GET['aralik'] : 'day'; // day, week, month
            
            if ($sensor_tur === null) {
                http_response_code(400);
                echo json_encode(['durum' => 'hata', 'mesaj' => 'Sensör türü belirtilmedi']);
                exit;
            }
            
            getGrafikVerileri($conn, $sera_id, $sensor_tur, $zaman_aralik);
            break;
            
        case 'bildirimler':
            // Son bildirimleri getir
            getBildirimler($conn, $sera_id);
            break;
            
        case 'cihaz_durumlari':
            // Cihazların durumlarını getir
            getCihazDurumlari($conn, $sera_id);
            break;
            
        default:
            http_response_code(400);
            echo json_encode(['durum' => 'hata', 'mesaj' => 'Geçersiz istek tipi']);
            exit;
    }
    
} catch (PDOException $e) {
    http_response_code(500);
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Veritabanı hatası: ' . $e->getMessage()]);
    exit;
}

// Son sensör verilerini getiren fonksiyon - YENİLENMİŞ VERSİYON
function getSonVeriler($conn, $sera_id) {
    // Debug için log ekleyelim
    error_log("getSonVeriler çağrıldı, sera_id: " . $sera_id);
    
    // Sensör tablosundaki sensörleri kontrol et ve yoksa oluştur
    $sensorVarMi = $conn->prepare("SELECT COUNT(*) as sayi FROM sensorler WHERE sera_id = :sera_id");
    $sensorVarMi->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $sensorVarMi->execute();
    $sensorSayisi = $sensorVarMi->fetch(PDO::FETCH_ASSOC)['sayi'];
    
    if ($sensorSayisi == 0) {
        error_log("Sera ID: " . $sera_id . " için hiç sensör bulunamadı. Sensörler oluşturuluyor...");
        
        // Sensörleri otomatik oluştur
        $sensor_tipleri = [
            "Sıcaklık Sensörü", 
            "Nem Sensörü", 
            "Işık Sensörü", 
            "Toprak Nem Sensörü", 
            "Hava Kalitesi Sensörü", 
            "Su Seviye Sensörü"
        ];
        
        foreach ($sensor_tipleri as $tip) {
            $stmt = $conn->prepare("INSERT INTO sensorler (sera_id, ad, durum) VALUES (:sera_id, :ad, 1)");
            $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
            $stmt->bindParam(':ad', $tip, PDO::PARAM_STR);
            $stmt->execute();
        }
        
        error_log("Sensörler başarıyla oluşturuldu.");
        
        // Cihazları da oluşturalım
        $cihaz_tipleri = [
            "Isıtma Sistemi",
            "Nemlendirici",
            "Aydınlatma Sistemi",
            "Sulama Sistemi",
            "Havalandırma Sistemi"
        ];
        
        foreach ($cihaz_tipleri as $tip) {
            $stmt = $conn->prepare("INSERT INTO cihazlar (sera_id, ad, durum) VALUES (:sera_id, :ad, 0)");
            $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
            $stmt->bindParam(':ad', $tip, PDO::PARAM_STR);
            $stmt->execute();
        }
        
        error_log("Cihazlar başarıyla oluşturuldu.");
    }

    // Sensör türlerini ID'lerle eşleştir
    $sensorMapping = [];
    $stmt = $conn->prepare("SELECT id, ad FROM sensorler WHERE sera_id = :sera_id");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        $sensorAdi = strtolower($row['ad']);
        $sensorId = $row['id'];
        
        // Daha basit ama sağlam eşleştirme
        if (preg_match('/(sicakl|sıcakl|heat|temp)/i', $sensorAdi)) {
            $sensorMapping['sicaklik'] = $sensorId;
        } 
        else if (preg_match('/(nem|humid)/i', $sensorAdi) && !preg_match('/(toprak|soil)/i', $sensorAdi)) {
            $sensorMapping['nem'] = $sensorId;
        } 
        else if (preg_match('/(isik|ışık|light)/i', $sensorAdi)) {
            $sensorMapping['isik_seviyesi'] = $sensorId;
        } 
        else if (preg_match('/(toprak|soil)/i', $sensorAdi)) {
            $sensorMapping['toprak_nemi'] = $sensorId;
        } 
        else if (preg_match('/(hava|air|co2)/i', $sensorAdi)) {
            $sensorMapping['hava_kalitesi'] = $sensorId;
        } 
        else if (preg_match('/(su|water)/i', $sensorAdi)) {
            $sensorMapping['su_seviyesi'] = $sensorId;
        }
    }
    
    error_log("Sensör eşleştirme: " . json_encode($sensorMapping));
    
    // Eşleştirme eksikse varsayılan ID'lere geri dön
    if (!isset($sensorMapping['sicaklik'])) $sensorMapping['sicaklik'] = 1;
    if (!isset($sensorMapping['nem'])) $sensorMapping['nem'] = 2;
    if (!isset($sensorMapping['isik_seviyesi'])) $sensorMapping['isik_seviyesi'] = 3;
    if (!isset($sensorMapping['toprak_nemi'])) $sensorMapping['toprak_nemi'] = 4;
    if (!isset($sensorMapping['hava_kalitesi'])) $sensorMapping['hava_kalitesi'] = 5;
    if (!isset($sensorMapping['su_seviyesi'])) $sensorMapping['su_seviyesi'] = 6;
    
    // Eşleştirilen her sensör için tek sorguda son değeri çek
    // Çok daha verimli
    $placeholders = implode(',', array_fill(0, count($sensorMapping), '?'));
    $sql = "
        SELECT 
            sv.sensor_id,
            sv.deger,
            sv.ek_veri,
            sv.kayit_zamani
        FROM (
            SELECT 
                sensor_id,
                deger,
                ek_veri,
                kayit_zamani,
                ROW_NUMBER() OVER (PARTITION BY sensor_id ORDER BY kayit_zamani DESC) as rn
            FROM 
                sensor_verileri
            WHERE 
                sensor_id IN ({$placeholders})
        ) sv
        WHERE sv.rn = 1
        ORDER BY sv.sensor_id
    ";
    
    $stmt = $conn->prepare($sql);
    $i = 1;
    foreach ($sensorMapping as $sensorId) {
        $stmt->bindValue($i++, $sensorId, PDO::PARAM_INT);
    }
    $stmt->execute();
    
    // Varsayılan değerleri başlat
    $veriler = [
        'sicaklik' => "--",
        'nem' => "--",
        'isik_seviyesi' => "--",
        'toprak_nemi' => "--",
        'toprak_nemli' => false,
        'hava_kalitesi' => "--",
        'co2' => "---",
        'su_seviyesi' => "--"
    ];
    
    $son_guncelleme = null;
    
    // Hangi sensörün hangi tür olduğunu kolayca belirlemek için ters eşleştirme
    $reverseMapping = array_flip($sensorMapping);
    
    // Tüm sensör değerlerini birlikte işle
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        $sensor_id = $row['sensor_id'];
        $deger = $row['deger'];
        $ek_veri = $row['ek_veri'];
        $zaman = $row['kayit_zamani'];
        
        // En son güncelleme zamanını takip et
        if ($son_guncelleme === null || strtotime($zaman) > strtotime($son_guncelleme)) {
            $son_guncelleme = $zaman;
        }
        
        // Sensör değerlerini ters eşleştirmeyle belirle
        if (isset($reverseMapping[$sensor_id]) && $deger !== null) {
            $sensorType = $reverseMapping[$sensor_id];
            
            switch ($sensorType) {
                case 'sicaklik':
                    $veriler['sicaklik'] = floatval($deger);
                    error_log("Sıcaklık sensörü değeri: $deger");
                    break;
                    
                case 'nem':
                    $veriler['nem'] = floatval($deger);
                    error_log("Nem sensörü değeri: $deger");
                    break;
                    
                case 'isik_seviyesi':
                    $veriler['isik_seviyesi'] = intval($deger);
                    error_log("Işık sensörü değeri: $deger");
                    break;
                    
                case 'toprak_nemi':
                    $veriler['toprak_nemi'] = intval($deger);
                    $veriler['toprak_nemli'] = intval($deger) >= 40;
                    error_log("Toprak nem sensörü değeri: $deger");
                    break;
                    
                case 'hava_kalitesi':
                    if ($ek_veri === 'co2ppm') {
                        $veriler['co2'] = intval($deger);
                        error_log("CO2 sensörü değeri: $deger ppm");
                    } else {
                        $veriler['hava_kalitesi'] = intval($deger);
                        error_log("Hava kalitesi sensörü değeri: $deger");
                    }
                    break;
                    
                case 'su_seviyesi':
                    $veriler['su_seviyesi'] = intval($deger);
                    error_log("Su seviye sensörü değeri: $deger");
                    break;
            }
        }
    }
    
    // CO2 değeri ayrıca kontrol et (ek_veri ile saklanabilir)
    if ($veriler['co2'] === "---") {
        $stmt = $conn->prepare("
            SELECT deger 
            FROM sensor_verileri 
            WHERE sensor_id = :sensor_id 
            AND ek_veri = 'co2ppm'
            ORDER BY kayit_zamani DESC 
            LIMIT 1
        ");
        $stmt->bindParam(':sensor_id', $sensorMapping['hava_kalitesi'], PDO::PARAM_INT);
        $stmt->execute();
        
        if ($stmt->rowCount() > 0) {
            $row = $stmt->fetch(PDO::FETCH_ASSOC);
            $veriler['co2'] = intval($row['deger']);
            error_log("CO2 sensörü değeri (ek sorgu): " . $veriler['co2'] . " ppm");
        }
    }
    
    // Sensör durumlarını işle
    if ($veriler['sicaklik'] !== "--") {
        $veriler['durum_sicaklik'] = ($veriler['sicaklik'] >= 22 && $veriler['sicaklik'] <= 28) ? 'normal' : (($veriler['sicaklik'] < 22) ? 'dusuk' : 'yuksek');
    } else {
        $veriler['durum_sicaklik'] = 'normal';
    }
    
    if ($veriler['nem'] !== "--") {
        $veriler['durum_nem'] = ($veriler['nem'] >= 55 && $veriler['nem'] <= 75) ? 'normal' : (($veriler['nem'] < 55) ? 'dusuk' : 'yuksek');
    } else {
        $veriler['durum_nem'] = 'normal';
    }
    
    if ($veriler['isik_seviyesi'] !== "--") {
        $veriler['durum_isik'] = ($veriler['isik_seviyesi'] >= 60 && $veriler['isik_seviyesi'] <= 90) ? 'normal' : (($veriler['isik_seviyesi'] < 60) ? 'dusuk' : 'yuksek');
    } else {
        $veriler['durum_isik'] = 'normal';
    }
    
    $veriler['durum_toprak'] = $veriler['toprak_nemli'] ? 'normal' : 'dusuk';
    
    if ($veriler['co2'] !== "---") {
        $veriler['durum_hava'] = ($veriler['co2'] >= 500 && $veriler['co2'] <= 800) ? 'normal' : (($veriler['co2'] < 500) ? 'dusuk' : 'yuksek');
    } else {
        $veriler['durum_hava'] = 'normal';
    }
    
    if ($veriler['su_seviyesi'] !== "--") {
        $veriler['durum_su'] = ($veriler['su_seviyesi'] >= 20) ? 'normal' : 'kritik';
    } else {
        $veriler['durum_su'] = 'normal';
    }
    
    // Son güncelleme zamanı formatı - DateTime kullanarak zaman dilimini düzeltiyoruz
    if ($son_guncelleme) {
        $dt = new DateTime($son_guncelleme);
        $dt->setTimezone(new DateTimeZone('Europe/Istanbul'));
        $veriler['son_guncelleme'] = $dt->format('G:i:s');
    } else {
        $veriler['son_guncelleme'] = 'Veri yok';
    }
    
    // Cihazın çevrimiçi durumunu kontrol et
    $stmt = $conn->prepare("
        SELECT 
            TIMESTAMPDIFF(SECOND, son_cevrimici, NOW()) as saniye_farki,
            son_cevrimici
        FROM cihazlar 
        WHERE sera_id = :sera_id 
        LIMIT 1
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    $cihaz_durumu = 'cevrimici';
    $sistem_durumu = 'aktif';
    
    if ($stmt->rowCount() > 0) {
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        // 45 saniye veri gelmezse çevrimdışı say
        if ($row['saniye_farki'] > 45) {
            $cihaz_durumu = 'cevrimdisi';
            $sistem_durumu = 'beklemede';
        }
    }
    
    $veriler['cihaz_durumu'] = $cihaz_durumu;
    $veriler['sistem_durumu'] = $sistem_durumu;
    
    error_log("getSonVeriler tamamlandı, veri: " . json_encode($veriler));
    
    return ['durum' => 'basarili', 'veriler' => $veriler];
}

// Grafik verilerini getiren fonksiyon
function getGrafikVerileri($conn, $sera_id, $sensor_tur, $zaman_aralik) {
    // Zaman aralığı kısıtını belirle
    $zaman_kisiti = "";
    switch ($zaman_aralik) {
        case 'day':
            $zaman_kisiti = "AND sv.kayit_zamani >= DATE_SUB(NOW(), INTERVAL 1 DAY)";
            break;
        case 'week':
            $zaman_kisiti = "AND sv.kayit_zamani >= DATE_SUB(NOW(), INTERVAL 1 WEEK)";
            break;
        case 'month':
            $zaman_kisiti = "AND sv.kayit_zamani >= DATE_SUB(NOW(), INTERVAL 1 MONTH)";
            break;
        default:
            $zaman_kisiti = "AND sv.kayit_zamani >= DATE_SUB(NOW(), INTERVAL 1 DAY)";
    }
    
    // Sensör türüne göre WHERE şartını belirle
    $sensor_sart = "";
    switch ($sensor_tur) {
        case 'sicaklik':
            $sensor_sart = "AND (s.ad LIKE '%sicaklik%' OR s.ad LIKE '%sıcaklık%' OR s.ad LIKE '%heat%' OR s.ad LIKE '%temp%')";
            break;
        case 'nem':
            $sensor_sart = "AND (s.ad LIKE '%nem%' OR s.ad LIKE '%humid%') AND s.ad NOT LIKE '%toprak%' AND s.ad NOT LIKE '%soil%'";
            break;
        case 'isik':
            $sensor_sart = "AND (s.ad LIKE '%isik%' OR s.ad LIKE '%ışık%' OR s.ad LIKE '%light%')";
            break;
        case 'toprak_nemi':
            $sensor_sart = "AND (s.ad LIKE '%toprak%' OR s.ad LIKE '%soil%')";
            break;
        case 'hava_kalitesi':
            $sensor_sart = "AND (s.ad LIKE '%hava%' OR s.ad LIKE '%air%') AND sv.ek_veri IS NULL";
            break;
        case 'co2':
            $sensor_sart = "AND (s.ad LIKE '%hava%' OR s.ad LIKE '%air%' OR s.ad LIKE '%co2%') AND sv.ek_veri = 'co2ppm'";
            break;
        case 'su_seviyesi':
            $sensor_sart = "AND (s.ad LIKE '%su%' OR s.ad LIKE '%water%')";
            break;
        default:
            $sensor_sart = "";
    }
    
    // Sorgu
    $sql = "
        SELECT 
            sv.kayit_zamani,
            sv.deger
        FROM 
            sensor_verileri sv
        JOIN 
            sensorler s ON sv.sensor_id = s.id
        WHERE 
            s.sera_id = :sera_id
            $sensor_sart
            $zaman_kisiti
        ORDER BY 
            sv.kayit_zamani ASC
    ";
    
    $stmt = $conn->prepare($sql);
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    $veriler = [];
    
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        // DateTime kullanarak zaman dilimini düzeltiyoruz
        $dt = new DateTime($row['kayit_zamani']);
        $dt->setTimezone(new DateTimeZone('Europe/Istanbul'));
        $zaman = $dt->format('H:i');
        
        $deger = floatval($row['deger']);
        
        $veriler[] = [
            'zaman' => $zaman,
            'deger' => $deger
        ];
    }
    
    // Veri yoksa boş bir dizi dön
    
    echo json_encode(['durum' => 'basarili', 'veriler' => $veriler]);
}

// Bildirimleri getiren fonksiyon
function getBildirimler($conn, $sera_id) {
    // CASE ifadesini kullanarak zaman farklarını hesaplıyoruz
    $stmt = $conn->prepare("
        SELECT 
            id,
            baslik,
            mesaj,
            tur,
            okundu,
            olusturma_zamani,
            CASE
                WHEN olusturma_zamani > DATE_SUB(NOW(), INTERVAL 1 HOUR) THEN CONCAT(TIMESTAMPDIFF(MINUTE, olusturma_zamani, NOW()), ' dk önce')
                WHEN olusturma_zamani > DATE_SUB(NOW(), INTERVAL 1 DAY) THEN CONCAT(TIMESTAMPDIFF(HOUR, olusturma_zamani, NOW()), ' saat önce')
                ELSE CONCAT(TIMESTAMPDIFF(DAY, olusturma_zamani, NOW()), ' gün önce')
            END as zaman_farki
        FROM 
            bildirimler
        WHERE 
            sera_id = :sera_id
        ORDER BY 
            olusturma_zamani DESC
        LIMIT 10
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    $bildirimler = [];
    
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        // DateTime kullanarak zaman dilimini düzeltiyoruz
        $dt = new DateTime($row['olusturma_zamani']);
        $dt->setTimezone(new DateTimeZone('Europe/Istanbul'));
        $zaman = $dt->format('H:i');
        
        $bildirimler[] = [
            'id' => $row['id'],
            'baslik' => $row['baslik'],
            'mesaj' => $row['mesaj'],
            'tur' => $row['tur'],
            'okundu' => (bool)$row['okundu'],
            'zaman' => $zaman,
            'zaman_farki' => $row['zaman_farki']
        ];
    }
    
    // Okunmamış bildirim sayısını getir
    $stmt = $conn->prepare("
        SELECT 
            COUNT(*) as sayi
        FROM 
            bildirimler
        WHERE 
            sera_id = :sera_id
            AND okundu = 0
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    $row = $stmt->fetch(PDO::FETCH_ASSOC);
    $okunmamis_sayi = intval($row['sayi']);
    
    echo json_encode([
        'durum' => 'basarili',
        'bildirimler' => $bildirimler,
        'okunmamis_sayi' => $okunmamis_sayi
    ]);
}

// Cihaz durumlarını getiren fonksiyon
function getCihazDurumlari($conn, $sera_id) {
    $stmt = $conn->prepare("
        SELECT 
            id,
            ad,
            durum
        FROM 
            cihazlar
        WHERE 
            sera_id = :sera_id
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    $cihazlar = [];
    
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        $cihazlar[] = [
            'id' => $row['id'],
            'ad' => $row['ad'],
            'durum' => (bool)$row['durum']
        ];
    }
    
    echo json_encode(['durum' => 'basarili', 'cihazlar' => $cihazlar]);
}
?>