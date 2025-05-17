<?php
// Oturum kontrolü
session_start();

// Kullanıcı giriş yapmış mı kontrol et
if (!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true) {
    http_response_code(401);
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Oturum açmanız gerekiyor']);
    exit;
}

// Hata raporlama
error_reporting(E_ALL);
ini_set('display_errors', 1);

// Veritabanı bağlantı bilgileri
$servername = "92.205.171.9";
$username = "admin";
$password = "Ke3@1.3ySq1";
$dbname = "greenbyte";

// Cevap için header ayarları
header('Content-Type: application/json');

// POST verilerini kontrol et
if ($_SERVER["REQUEST_METHOD"] !== "POST") {
    http_response_code(405);
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Sadece POST istekleri kabul edilir']);
    exit;
}

$tip = isset($_POST['tip']) ? $_POST['tip'] : null;
$deger = isset($_POST['deger']) ? $_POST['deger'] : null;
$otomatik = isset($_POST['otomatik']) ? (bool)$_POST['otomatik'] : null;

if (!$tip) {
    http_response_code(400);
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Komut tipi belirtilmedi']);
    exit;
}

// Kullanıcının sera ID'sini al
$sera_id = null;
try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    
    $stmt = $conn->prepare("
        SELECT id FROM seralar
        WHERE kullanici_id = :kullanici_id
        LIMIT 1
    ");
    $stmt->bindParam(':kullanici_id', $_SESSION["id"], PDO::PARAM_INT);
    $stmt->execute();
    
    if ($stmt->rowCount() > 0) {
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        $sera_id = $row['id'];
    } else {
        http_response_code(404);
        echo json_encode(['durum' => 'hata', 'mesaj' => 'Kullanıcıya ait sera bulunamadı']);
        exit;
    }
} catch (PDOException $e) {
    http_response_code(500);
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Veritabanı hatası: ' . $e->getMessage()]);
    exit;
}

// Komut tiplerine göre işlem yap
try {
    switch ($tip) {
        case 'sicaklik':
            kontrolSicaklik($conn, $sera_id, $deger, $otomatik);
            break;
            
        case 'nem':
            kontrolNem($conn, $sera_id, $deger, $otomatik);
            break;
            
        case 'sulama':
            kontrolSulama($conn, $sera_id, $deger);
            break;
            
        case 'isik':
            kontrolIsik($conn, $sera_id, $deger);
            break;
            
        case 'havalandirma':
            kontrolHavalandirma($conn, $sera_id, $deger);
            break;
            
        case 'su_deposu':
            kontrolSuDeposu($conn, $sera_id, $deger);
            break;
            
        default:
            http_response_code(400);
            echo json_encode(['durum' => 'hata', 'mesaj' => 'Geçersiz komut tipi']);
            exit;
    }
} catch (Exception $e) {
    http_response_code(500);
    echo json_encode(['durum' => 'hata', 'mesaj' => $e->getMessage()]);
    exit;
}

// Sıcaklık kontrolü
function kontrolSicaklik($conn, $sera_id, $deger, $otomatik) {
    if (!is_numeric($deger) || $deger < 15 || $deger > 35) {
        throw new Exception("Geçersiz sıcaklık değeri. 15-35°C aralığında olmalıdır.");
    }
    
    // 1. İlgili cihazı bul (ısıtma/soğutma gibi)
    $stmt = $conn->prepare("
        SELECT id, ad, durum FROM cihazlar
        WHERE sera_id = :sera_id AND (ad LIKE '%ısıtma%' OR ad LIKE '%isitma%' OR ad LIKE '%soğutma%' OR ad LIKE '%sogutma%')
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    $cihazlar = $stmt->fetchAll(PDO::FETCH_ASSOC);
    
    if (count($cihazlar) === 0) {
        throw new Exception("Isıtma veya soğutma cihazı bulunamadı.");
    }
    
    // 2. Son sıcaklık değerini al
    $stmt = $conn->prepare("
        SELECT sv.deger FROM sensor_verileri sv
        JOIN sensorler s ON sv.sensor_id = s.id
        WHERE s.sera_id = :sera_id AND s.ad LIKE '%sicaklik%'
        ORDER BY sv.kayit_zamani DESC
        LIMIT 1
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    $son_sicaklik = null;
    if ($stmt->rowCount() > 0) {
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        $son_sicaklik = $row['deger'];
    }
    
    // 3. Hedef sıcaklık ve otomatik modu ayarla (ayarlar tablosu oluşturuluyor)
    $stmt = $conn->prepare("
        INSERT INTO sera_ayarlari (sera_id, ayar_tipi, deger, otomatik)
        VALUES (:sera_id, 'sicaklik', :deger, :otomatik)
        ON DUPLICATE KEY UPDATE
        deger = VALUES(deger),
        otomatik = VALUES(otomatik),
        guncelleme_zamani = CURRENT_TIMESTAMP
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->bindParam(':deger', $deger, PDO::PARAM_STR);
    $otomatik_int = $otomatik ? 1 : 0;
    $stmt->bindParam(':otomatik', $otomatik_int, PDO::PARAM_INT);
    $stmt->execute();
    
    // 4. Otomatik modda ise, mevcut sıcaklığa göre cihazları çalıştır/durdur
    if ($otomatik && $son_sicaklik !== null) {
        foreach ($cihazlar as $cihaz) {
            $cihaz_tipi = (strpos(strtolower($cihaz['ad']), 'isitma') !== false || strpos(strtolower($cihaz['ad']), 'ısıtma') !== false) ? 'isitma' : 'sogutma';
            $yeni_durum = false;
            
            if ($cihaz_tipi === 'isitma') {
                // Isıtma cihazı - sıcaklık düşükse çalıştır
                $yeni_durum = $son_sicaklik < $deger;
            } else {
                // Soğutma cihazı - sıcaklık yüksekse çalıştır
                $yeni_durum = $son_sicaklik > $deger;
            }
            
            // Durum değiştiyse güncelle
            if ($yeni_durum != $cihaz['durum']) {
                $stmt = $conn->prepare("
                    UPDATE cihazlar SET durum = :durum
                    WHERE id = :cihaz_id
                ");
                $durum_int = $yeni_durum ? 1 : 0;
                $stmt->bindParam(':durum', $durum_int, PDO::PARAM_INT);
                $stmt->bindParam(':cihaz_id', $cihaz['id'], PDO::PARAM_INT);
                $stmt->execute();
                
                // Cihaz olayını kaydet
                $stmt = $conn->prepare("
                    INSERT INTO cihaz_olaylari (cihaz_id, islem, tetikleyici)
                    VALUES (:cihaz_id, :islem, 'otomatik')
                ");
                $islem = $yeni_durum ? 'ac' : 'kapat';
                $stmt->bindParam(':cihaz_id', $cihaz['id'], PDO::PARAM_INT);
                $stmt->bindParam(':islem', $islem, PDO::PARAM_STR);
                $stmt->execute();
            }
        }
    }
    
    echo json_encode([
        'durum' => 'basarili',
        'mesaj' => 'Sıcaklık ayarları güncellendi' . ($otomatik ? ' ve otomatik kontrol aktif edildi' : '')
    ]);
}

// Nem kontrolü
function kontrolNem($conn, $sera_id, $deger, $otomatik) {
    if (!is_numeric($deger) || $deger < 40 || $deger > 90) {
        throw new Exception("Geçersiz nem değeri. 40-90% aralığında olmalıdır.");
    }
    
    // 1. İlgili cihazı bul (nemlendirici/nem alıcı gibi)
    $stmt = $conn->prepare("
        SELECT id, ad, durum FROM cihazlar
        WHERE sera_id = :sera_id AND (ad LIKE '%nem%')
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    $cihazlar = $stmt->fetchAll(PDO::FETCH_ASSOC);
    
    if (count($cihazlar) === 0) {
        throw new Exception("Nem kontrol cihazı bulunamadı.");
    }
    
    // 2. Son nem değerini al
    $stmt = $conn->prepare("
        SELECT sv.deger FROM sensor_verileri sv
        JOIN sensorler s ON sv.sensor_id = s.id
        WHERE s.sera_id = :sera_id AND s.ad LIKE '%nem%' AND s.ad NOT LIKE '%toprak%'
        ORDER BY sv.kayit_zamani DESC
        LIMIT 1
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    $son_nem = null;
    if ($stmt->rowCount() > 0) {
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        $son_nem = $row['deger'];
    }
    
    // 3. Hedef nem ve otomatik modu ayarla
    $stmt = $conn->prepare("
        INSERT INTO sera_ayarlari (sera_id, ayar_tipi, deger, otomatik)
        VALUES (:sera_id, 'nem', :deger, :otomatik)
        ON DUPLICATE KEY UPDATE
        deger = VALUES(deger),
        otomatik = VALUES(otomatik),
        guncelleme_zamani = CURRENT_TIMESTAMP
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->bindParam(':deger', $deger, PDO::PARAM_STR);
    $otomatik_int = $otomatik ? 1 : 0;
    $stmt->bindParam(':otomatik', $otomatik_int, PDO::PARAM_INT);
    $stmt->execute();
    
    // 4. Otomatik modda ise, mevcut neme göre cihazları çalıştır/durdur
    if ($otomatik && $son_nem !== null) {
        foreach ($cihazlar as $cihaz) {
            $cihaz_tipi = (strpos(strtolower($cihaz['ad']), 'nemlendirici') !== false) ? 'nemlendirici' : 'nem_alici';
            $yeni_durum = false;
            
            if ($cihaz_tipi === 'nemlendirici') {
                // Nemlendirici - nem düşükse çalıştır
                $yeni_durum = $son_nem < $deger;
            } else {
                // Nem alıcı - nem yüksekse çalıştır
                $yeni_durum = $son_nem > $deger;
            }
            
            // Durum değiştiyse güncelle
            if ($yeni_durum != $cihaz['durum']) {
                $stmt = $conn->prepare("
                    UPDATE cihazlar SET durum = :durum
                    WHERE id = :cihaz_id
                ");
                $durum_int = $yeni_durum ? 1 : 0;
                $stmt->bindParam(':durum', $durum_int, PDO::PARAM_INT);
                $stmt->bindParam(':cihaz_id', $cihaz['id'], PDO::PARAM_INT);
                $stmt->execute();
                
                // Cihaz olayını kaydet
                $stmt = $conn->prepare("
                    INSERT INTO cihaz_olaylari (cihaz_id, islem, tetikleyici)
                    VALUES (:cihaz_id, :islem, 'otomatik')
                ");
                $islem = $yeni_durum ? 'ac' : 'kapat';
                $stmt->bindParam(':cihaz_id', $cihaz['id'], PDO::PARAM_INT);
                $stmt->bindParam(':islem', $islem, PDO::PARAM_STR);
                $stmt->execute();
            }
        }
    }
    
    echo json_encode([
        'durum' => 'basarili',
        'mesaj' => 'Nem ayarları güncellendi' . ($otomatik ? ' ve otomatik kontrol aktif edildi' : '')
    ]);
}

// Sulama kontrolü
function kontrolSulama($conn, $sera_id, $islem) {
    // Sulama cihazını bul
    $stmt = $conn->prepare("
        SELECT id, durum FROM cihazlar
        WHERE sera_id = :sera_id AND ad LIKE '%sulama%'
        LIMIT 1
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    if ($stmt->rowCount() === 0) {
        throw new Exception("Sulama cihazı bulunamadı.");
    }
    
    $cihaz = $stmt->fetch(PDO::FETCH_ASSOC);
    
    // İşleme göre cihazı aç/kapat
    $yeni_durum = ($islem === 'baslat') ? true : false;
    
    // Durum güncelle
    $stmt = $conn->prepare("
        UPDATE cihazlar SET durum = :durum
        WHERE id = :cihaz_id
    ");
    $durum_int = $yeni_durum ? 1 : 0;
    $stmt->bindParam(':durum', $durum_int, PDO::PARAM_INT);
    $stmt->bindParam(':cihaz_id', $cihaz['id'], PDO::PARAM_INT);
    $stmt->execute();
    
    // Cihaz olayını kaydet
    $stmt = $conn->prepare("
        INSERT INTO cihaz_olaylari (cihaz_id, islem, tetikleyici)
        VALUES (:cihaz_id, :islem, 'manuel')
    ");
    $islem_db = $yeni_durum ? 'ac' : 'kapat';
    $stmt->bindParam(':cihaz_id', $cihaz['id'], PDO::PARAM_INT);
    $stmt->bindParam(':islem', $islem_db, PDO::PARAM_STR);
    $stmt->execute();
    
    // Bildirim oluştur
    $stmt = $conn->prepare("
        INSERT INTO bildirimler (sera_id, baslik, mesaj, tur, okundu)
        VALUES (:sera_id, :baslik, :mesaj, 'info', 0)
    ");
    $baslik = $yeni_durum ? 'Manuel Sulama Başlatıldı' : 'Sulama Durduruldu';
    $mesaj = $yeni_durum ? 'Manuel sulama sistemi başlatıldı.' : 'Sulama sistemi durduruldu.';
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->bindParam(':baslik', $baslik, PDO::PARAM_STR);
    $stmt->bindParam(':mesaj', $mesaj, PDO::PARAM_STR);
    $stmt->execute();
    
    echo json_encode([
        'durum' => 'basarili',
        'mesaj' => $yeni_durum ? 'Manuel sulama başlatıldı' : 'Sulama durduruldu'
    ]);
}

// Işık kontrolü
function kontrolIsik($conn, $sera_id, $islem) {
    // Işık cihazını bul
    $stmt = $conn->prepare("
        SELECT id, durum FROM cihazlar
        WHERE sera_id = :sera_id AND ad LIKE '%isik%'
        LIMIT 1
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    if ($stmt->rowCount() === 0) {
        throw new Exception("Işık cihazı bulunamadı.");
    }
    
    $cihaz = $stmt->fetch(PDO::FETCH_ASSOC);
    
    // İşleme göre cihazı aç/kapat
    $yeni_durum = ($islem === 'ac') ? true : false;
    
    // Durum güncelle
    $stmt = $conn->prepare("
        UPDATE cihazlar SET durum = :durum
        WHERE id = :cihaz_id
    ");
    $durum_int = $yeni_durum ? 1 : 0;
    $stmt->bindParam(':durum', $durum_int, PDO::PARAM_INT);
    $stmt->bindParam(':cihaz_id', $cihaz['id'], PDO::PARAM_INT);
    $stmt->execute();
    
    // Cihaz olayını kaydet
    $stmt = $conn->prepare("
        INSERT INTO cihaz_olaylari (cihaz_id, islem, tetikleyici)
        VALUES (:cihaz_id, :islem, 'manuel')
    ");
    $islem_db = $yeni_durum ? 'ac' : 'kapat';
    $stmt->bindParam(':cihaz_id', $cihaz['id'], PDO::PARAM_INT);
    $stmt->bindParam(':islem', $islem_db, PDO::PARAM_STR);
    $stmt->execute();
    
    echo json_encode([
        'durum' => 'basarili',
        'mesaj' => $yeni_durum ? 'Işıklar açıldı' : 'Işıklar kapatıldı'
    ]);
}

// Havalandırma kontrolü
function kontrolHavalandirma($conn, $sera_id, $islem) {
    // Havalandırma cihazını bul
    $stmt = $conn->prepare("
        SELECT id, durum FROM cihazlar
        WHERE sera_id = :sera_id AND (ad LIKE '%hava%' OR ad LIKE '%fan%')
        LIMIT 1
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    if ($stmt->rowCount() === 0) {
        throw new Exception("Havalandırma cihazı bulunamadı.");
    }
    
    $cihaz = $stmt->fetch(PDO::FETCH_ASSOC);
    
    // İşleme göre cihazı aç/kapat
    $yeni_durum = ($islem === 'ac') ? true : false;
    
    // Durum güncelle
    $stmt = $conn->prepare("
        UPDATE cihazlar SET durum = :durum
        WHERE id = :cihaz_id
    ");
    $durum_int = $yeni_durum ? 1 : 0;
    $stmt->bindParam(':durum', $durum_int, PDO::PARAM_INT);
    $stmt->bindParam(':cihaz_id', $cihaz['id'], PDO::PARAM_INT);
    $stmt->execute();
    
    // Cihaz olayını kaydet
    $stmt = $conn->prepare("
        INSERT INTO cihaz_olaylari (cihaz_id, islem, tetikleyici)
        VALUES (:cihaz_id, :islem, 'manuel')
    ");
    $islem_db = $yeni_durum ? 'ac' : 'kapat';
    $stmt->bindParam(':cihaz_id', $cihaz['id'], PDO::PARAM_INT);
    $stmt->bindParam(':islem', $islem_db, PDO::PARAM_STR);
    $stmt->execute();
    
    echo json_encode([
        'durum' => 'basarili',
        'mesaj' => $yeni_durum ? 'Havalandırma açıldı' : 'Havalandırma kapatıldı'
    ]);
}

// Su deposu kontrolü
function kontrolSuDeposu($conn, $sera_id, $islem) {
    if ($islem !== 'doldur') {
        throw new Exception("Geçersiz işlem. Sadece 'doldur' işlemi desteklenmektedir.");
    }
    
    // İşlem yapılıyor gibi simüle et
    usleep(500000); // 0.5 saniye beklet
    
    // Su seviyesini güncelle
    $stmt = $conn->prepare("
        SELECT sv.id, s.id as sensor_id FROM sensor_verileri sv
        JOIN sensorler s ON sv.sensor_id = s.id
        WHERE s.sera_id = :sera_id AND s.ad LIKE '%su%'
        ORDER BY sv.kayit_zamani DESC
        LIMIT 1
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    if ($stmt->rowCount() > 0) {
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        $sensor_id = $row['sensor_id'];
        
        // Yeni su seviyesi kaydı ekle (95%)
        $stmt = $conn->prepare("
            INSERT INTO sensor_verileri (sensor_id, deger)
            VALUES (:sensor_id, 95)
        ");
        $stmt->bindParam(':sensor_id', $sensor_id, PDO::PARAM_INT);
        $stmt->execute();
    }
    
    // Bildirim oluştur
    $stmt = $conn->prepare("
        INSERT INTO bildirimler (sera_id, baslik, mesaj, tur, okundu)
        VALUES (:sera_id, 'Su Deposu Dolduruldu', 'Su deposu başarıyla dolduruldu.', 'success', 0)
    ");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    echo json_encode([
        'durum' => 'basarili',
        'mesaj' => 'Su deposu dolduruldu'
    ]);
}
?>