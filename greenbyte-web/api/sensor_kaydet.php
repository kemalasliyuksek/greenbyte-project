<?php
// Hata raporlama
error_reporting(E_ALL);
ini_set('display_errors', 1);

// Gelen JSON verisini alalım
$json_data = file_get_contents('php://input');
$data = json_decode($json_data, true);

// Log dosyasına gelen veriyi kaydedelim (debug için)
$log_file = fopen("sensor_log.txt", "a");
fwrite($log_file, date('Y-m-d H:i:s') . " - Gelen Veri: " . $json_data . "\n");

// Veritabanı bağlantı bilgileri
$servername = "92.205.171.9";
$username = "admin";
$password = "Ke3@1.3ySq1";
$dbname = "greenbyte";

// Cevap için header ayarları
header('Content-Type: application/json');

// Gelen veri doğru formatta mı kontrol edelim
if ($data === null || !isset($data['cihaz_id'])) {
    $error_msg = "Geçersiz veri formatı";
    fwrite($log_file, date('Y-m-d H:i:s') . " - HATA: " . $error_msg . "\n");
    fclose($log_file);
    
    http_response_code(400);
    echo json_encode(['durum' => 'hata', 'mesaj' => $error_msg]);
    exit;
}

try {
    // Veritabanı bağlantısı oluştur
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    // PDO hata modunu ayarla
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    
    // Veri ekleme işlemlerini başlat
    $conn->beginTransaction();
    
    // 1. Cihaz kontrolü - Cihaz var mı ve hangi seraya ait?
    $stmt = $conn->prepare("SELECT sera_id FROM cihazlar WHERE id = :cihaz_id");
    $stmt->bindParam(':cihaz_id', $data['cihaz_id'], PDO::PARAM_INT);
    $stmt->execute();
    
    if ($stmt->rowCount() == 0) {
        $error_msg = "Belirtilen cihaz bulunamadı: ID=" . $data['cihaz_id'];
        fwrite($log_file, date('Y-m-d H:i:s') . " - HATA: " . $error_msg . "\n");
        fclose($log_file);
        
        throw new Exception($error_msg);
    }
    
    $cihaz = $stmt->fetch(PDO::FETCH_ASSOC);
    $sera_id = $cihaz['sera_id'];
    
    fwrite($log_file, date('Y-m-d H:i:s') . " - Sera ID: " . $sera_id . "\n");
    
    // 2. Sensörleri sorgulayıp eşleştirelim
    $sensorler = []; // Sensör türü => ID şeklinde bir eşleşme yapacağız
    
    // Tüm sensörleri getir
    $stmt = $conn->prepare("SELECT id, ad FROM sensorler WHERE sera_id = :sera_id");
    $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
    $stmt->execute();
    
    $bulunan_sensorler = $stmt->fetchAll(PDO::FETCH_ASSOC);
    fwrite($log_file, date('Y-m-d H:i:s') . " - Bulunan sensör sayısı: " . count($bulunan_sensorler) . "\n");
    
    // YENİ: Bulunan tüm sensörleri detaylı logla
    foreach ($bulunan_sensorler as $sensor) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - Sensör: ID=" . $sensor['id'] . ", İsim=" . $sensor['ad'] . "\n");
    }
    
    // Eğer hiç sensör bulunamadıysa, otomatik olarak sensörleri oluşturalım
    if (count($bulunan_sensorler) == 0) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - Hiç sensör bulunamadı, sensörler oluşturuluyor...\n");
        
        // Otomatik sensör oluşturma
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
            
            $sensor_id = $conn->lastInsertId();
            
            fwrite($log_file, date('Y-m-d H:i:s') . " - Oluşturulan sensör: " . $tip . ", ID: " . $sensor_id . "\n");
            
            // Sensör eşleştirmelerini yapalım
            if (stripos($tip, "Sıcaklık") !== false) {
                $sensorler['sicaklik'] = $sensor_id;
            } else if (stripos($tip, "Nem") !== false && stripos($tip, "Toprak") === false) {
                $sensorler['nem'] = $sensor_id;
            } else if (stripos($tip, "Işık") !== false) {
                $sensorler['isik'] = $sensor_id;
            } else if (stripos($tip, "Toprak") !== false) {
                $sensorler['toprak_nem'] = $sensor_id;
            } else if (stripos($tip, "Hava") !== false) {
                $sensorler['hava_kalitesi'] = $sensor_id;
            } else if (stripos($tip, "Su") !== false) {
                $sensorler['su_seviyesi'] = $sensor_id;
            }
        }
    } else {
        // Sensörleri tanımlanmış isimlere göre eşleştir
        foreach ($bulunan_sensorler as $sensor) {
            $sensor_ad = strtolower($sensor['ad']);
            $sensor_id = $sensor['id'];
            
            fwrite($log_file, date('Y-m-d H:i:s') . " - Kontrol edilen sensör: " . $sensor['ad'] . ", ID: " . $sensor_id . "\n");
            
            // İyileştirilmiş eşleştirme mantığı
            if (stripos($sensor_ad, "sıcaklık") !== false || stripos($sensor_ad, "sicaklik") !== false) {
                $sensorler['sicaklik'] = $sensor_id;
                fwrite($log_file, " > Sıcaklık sensörü eşleştirildi: ID=" . $sensor_id . "\n");
            }
            
            if (stripos($sensor_ad, "nem") !== false && 
                stripos($sensor_ad, "toprak") === false) {
                $sensorler['nem'] = $sensor_id;
                fwrite($log_file, " > Nem sensörü eşleştirildi: ID=" . $sensor_id . "\n");
            }
            
            if (stripos($sensor_ad, "ışık") !== false || 
                stripos($sensor_ad, "isik") !== false) {
                $sensorler['isik'] = $sensor_id;
                fwrite($log_file, " > Işık sensörü eşleştirildi: ID=" . $sensor_id . "\n");
            }
            
            if ((stripos($sensor_ad, "toprak") !== false && stripos($sensor_ad, "nem") !== false) || 
                 stripos($sensor_ad, "toprak_nem") !== false) {
                $sensorler['toprak_nem'] = $sensor_id;
                fwrite($log_file, " > Toprak nem sensörü eşleştirildi: ID=" . $sensor_id . "\n");
            }
            
            if (stripos($sensor_ad, "hava") !== false || 
                stripos($sensor_ad, "co2") !== false || 
                stripos($sensor_ad, "mq135") !== false) {
                $sensorler['hava_kalitesi'] = $sensor_id;
                fwrite($log_file, " > Hava kalitesi sensörü eşleştirildi: ID=" . $sensor_id . "\n");
            }
            
            if (stripos($sensor_ad, "su") !== false) {
                $sensorler['su_seviyesi'] = $sensor_id;
                fwrite($log_file, " > Su seviyesi sensörü eşleştirildi: ID=" . $sensor_id . "\n");
            }
        }
    }
    
    // YENİ: Gelen tüm veriyi logla
    fwrite($log_file, date('Y-m-d H:i:s') . " - JSON Veri: " . json_encode($data) . "\n");

    // YENİ: Eğer sensör eşleştirme başarısız olduysa, doğrudan ID'leri kullan
    if (!isset($sensorler['sicaklik']) && isset($data['sicaklik'])) {
        $sensorler['sicaklik'] = 1; // Doğrudan sıcaklık sensörü ID'si
        fwrite($log_file, date('Y-m-d H:i:s') . " - Sıcaklık sensörü doğrudan ID=1 olarak atandı\n");
    }

    if (!isset($sensorler['isik']) && isset($data['isik_seviyesi'])) {
        $sensorler['isik'] = 3; // Doğrudan ışık sensörü ID'si
        fwrite($log_file, date('Y-m-d H:i:s') . " - Işık sensörü doğrudan ID=3 olarak atandı\n");
    }
    
    // Bulunan sensörleri loglayalım
    fwrite($log_file, date('Y-m-d H:i:s') . " - Eşleşen sensörler: " . json_encode($sensorler) . "\n");
    
    // ÖNEMLI: Veritabanı tablosunda ek_veri sütunu var mı kontrol et
    $hasEkVeriColumn = false;
    try {
        $checkColumnStmt = $conn->query("SHOW COLUMNS FROM sensor_verileri LIKE 'ek_veri'");
        $hasEkVeriColumn = ($checkColumnStmt->rowCount() > 0);
        fwrite($log_file, date('Y-m-d H:i:s') . " - 'ek_veri' sütunu " . ($hasEkVeriColumn ? "bulundu" : "bulunamadı") . "\n");
    } catch (Exception $e) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - Sütun kontrolü hatası: " . $e->getMessage() . "\n");
    }
    
    // Her sensör için try-catch ile veri kaydını deneyelim
    // Sıcaklık
    try {
        if (isset($sensorler['sicaklik']) && isset($data['sicaklik'])) {
            $stmt = $conn->prepare("INSERT INTO sensor_verileri (sensor_id, deger) VALUES (:sensor_id, :deger)");
            $stmt->bindParam(':sensor_id', $sensorler['sicaklik'], PDO::PARAM_INT);
            $stmt->bindParam(':deger', $data['sicaklik'], PDO::PARAM_STR);
            $stmt->execute();
            fwrite($log_file, date('Y-m-d H:i:s') . " - Sıcaklık kaydedildi: " . $data['sicaklik'] . "\n");
        } else {
            fwrite($log_file, date('Y-m-d H:i:s') . " - Sıcaklık kaydedilemedi - Sensör veya veri eksik\n");
            // YENİ: Daha detaylı log
            fwrite($log_file, date('Y-m-d H:i:s') . " - Sıcaklık sensör durumu: " . (isset($sensorler['sicaklik']) ? "Var (ID: " . $sensorler['sicaklik'] . ")" : "Yok") . "\n");
            fwrite($log_file, date('Y-m-d H:i:s') . " - Sıcaklık veri durumu: " . (isset($data['sicaklik']) ? "Var (" . $data['sicaklik'] . ")" : "Yok") . "\n");
        }
    } catch (Exception $e) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - HATA (Sıcaklık): " . $e->getMessage() . "\n");
    }
    
    // Nem
    try {
        if (isset($sensorler['nem']) && isset($data['nem'])) {
            $stmt = $conn->prepare("INSERT INTO sensor_verileri (sensor_id, deger) VALUES (:sensor_id, :deger)");
            $stmt->bindParam(':sensor_id', $sensorler['nem'], PDO::PARAM_INT);
            $stmt->bindParam(':deger', $data['nem'], PDO::PARAM_STR);
            $stmt->execute();
            fwrite($log_file, date('Y-m-d H:i:s') . " - Nem kaydedildi: " . $data['nem'] . "\n");
        } else {
            fwrite($log_file, date('Y-m-d H:i:s') . " - Nem kaydedilemedi - Sensör veya veri eksik\n");
            // YENİ: Daha detaylı log
            fwrite($log_file, date('Y-m-d H:i:s') . " - Nem sensör durumu: " . (isset($sensorler['nem']) ? "Var (ID: " . $sensorler['nem'] . ")" : "Yok") . "\n");
            fwrite($log_file, date('Y-m-d H:i:s') . " - Nem veri durumu: " . (isset($data['nem']) ? "Var (" . $data['nem'] . ")" : "Yok") . "\n");
        }
    } catch (Exception $e) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - HATA (Nem): " . $e->getMessage() . "\n");
    }
    
    // Işık seviyesi
    try {
        if (isset($sensorler['isik']) && isset($data['isik_seviyesi'])) {
            $stmt = $conn->prepare("INSERT INTO sensor_verileri (sensor_id, deger) VALUES (:sensor_id, :deger)");
            $stmt->bindParam(':sensor_id', $sensorler['isik'], PDO::PARAM_INT);
            $stmt->bindParam(':deger', $data['isik_seviyesi'], PDO::PARAM_INT);
            $stmt->execute();
            fwrite($log_file, date('Y-m-d H:i:s') . " - Işık seviyesi kaydedildi: " . $data['isik_seviyesi'] . "\n");
        } else {
            fwrite($log_file, date('Y-m-d H:i:s') . " - Işık seviyesi kaydedilemedi - Sensör veya veri eksik\n");
            // YENİ: Daha detaylı log
            fwrite($log_file, date('Y-m-d H:i:s') . " - Işık sensör durumu: " . (isset($sensorler['isik']) ? "Var (ID: " . $sensorler['isik'] . ")" : "Yok") . "\n");
            fwrite($log_file, date('Y-m-d H:i:s') . " - Işık veri durumu: " . (isset($data['isik_seviyesi']) ? "Var (" . $data['isik_seviyesi'] . ")" : "Yok") . "\n");
        }
    } catch (Exception $e) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - HATA (Işık): " . $e->getMessage() . "\n");
    }
    
    // Toprak nemi
    try {
        if (isset($sensorler['toprak_nem']) && isset($data['toprak_nemi'])) {
            $stmt = $conn->prepare("INSERT INTO sensor_verileri (sensor_id, deger) VALUES (:sensor_id, :deger)");
            $stmt->bindParam(':sensor_id', $sensorler['toprak_nem'], PDO::PARAM_INT);
            $stmt->bindParam(':deger', $data['toprak_nemi'], PDO::PARAM_INT);
            $stmt->execute();
            fwrite($log_file, date('Y-m-d H:i:s') . " - Toprak nemi kaydedildi: " . $data['toprak_nemi'] . "\n");
        } else {
            fwrite($log_file, date('Y-m-d H:i:s') . " - Toprak nemi kaydedilemedi - Sensör veya veri eksik\n");
            // YENİ: Daha detaylı log
            fwrite($log_file, date('Y-m-d H:i:s') . " - Toprak nem sensör durumu: " . (isset($sensorler['toprak_nem']) ? "Var (ID: " . $sensorler['toprak_nem'] . ")" : "Yok") . "\n");
            fwrite($log_file, date('Y-m-d H:i:s') . " - Toprak nem veri durumu: " . (isset($data['toprak_nemi']) ? "Var (" . $data['toprak_nemi'] . ")" : "Yok") . "\n");
        }
    } catch (Exception $e) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - HATA (Toprak nemi): " . $e->getMessage() . "\n");
    }
    
    // Hava kalitesi ve CO2
    try {
        if (isset($sensorler['hava_kalitesi'])) {
            if (isset($data['hava_kalitesi'])) {
                $stmt = $conn->prepare("INSERT INTO sensor_verileri (sensor_id, deger) VALUES (:sensor_id, :deger)");
                $stmt->bindParam(':sensor_id', $sensorler['hava_kalitesi'], PDO::PARAM_INT);
                $stmt->bindParam(':deger', $data['hava_kalitesi'], PDO::PARAM_INT);
                $stmt->execute();
                fwrite($log_file, date('Y-m-d H:i:s') . " - Hava kalitesi kaydedildi: " . $data['hava_kalitesi'] . "\n");
            }
            
            // CO2 için ayrı bir kayıt
            if (isset($data['co2ppm'])) {
                if ($hasEkVeriColumn) {
                    // ek_veri sütunu varsa
                    $stmt = $conn->prepare("INSERT INTO sensor_verileri (sensor_id, deger, ek_veri) VALUES (:sensor_id, :deger, 'co2ppm')");
                } else {
                    // ek_veri sütunu yoksa
                    $stmt = $conn->prepare("INSERT INTO sensor_verileri (sensor_id, deger) VALUES (:sensor_id, :deger)");
                }
                $stmt->bindParam(':sensor_id', $sensorler['hava_kalitesi'], PDO::PARAM_INT);
                $stmt->bindParam(':deger', $data['co2ppm'], PDO::PARAM_INT);
                $stmt->execute();
                fwrite($log_file, date('Y-m-d H:i:s') . " - CO2 kaydedildi: " . $data['co2ppm'] . " ppm\n");
            }
        } else {
            fwrite($log_file, date('Y-m-d H:i:s') . " - Hava kalitesi kaydedilemedi - Sensör eksik\n");
            // YENİ: Daha detaylı log
            fwrite($log_file, date('Y-m-d H:i:s') . " - Hava kalitesi sensör durumu: " . (isset($sensorler['hava_kalitesi']) ? "Var (ID: " . $sensorler['hava_kalitesi'] . ")" : "Yok") . "\n");
            fwrite($log_file, date('Y-m-d H:i:s') . " - Hava kalitesi veri durumu: " . (isset($data['hava_kalitesi']) ? "Var (" . $data['hava_kalitesi'] . ")" : "Yok") . "\n");
            fwrite($log_file, date('Y-m-d H:i:s') . " - CO2 veri durumu: " . (isset($data['co2ppm']) ? "Var (" . $data['co2ppm'] . ")" : "Yok") . "\n");
        }
    } catch (Exception $e) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - HATA (Hava kalitesi): " . $e->getMessage() . "\n");
    }
    
    // Su seviyesi
    try {
        if (isset($sensorler['su_seviyesi']) && isset($data['su_seviyesi'])) {
            $stmt = $conn->prepare("INSERT INTO sensor_verileri (sensor_id, deger) VALUES (:sensor_id, :deger)");
            $stmt->bindParam(':sensor_id', $sensorler['su_seviyesi'], PDO::PARAM_INT);
            $stmt->bindParam(':deger', $data['su_seviyesi'], PDO::PARAM_INT);
            $stmt->execute();
            fwrite($log_file, date('Y-m-d H:i:s') . " - Su seviyesi kaydedildi: " . $data['su_seviyesi'] . "\n");
        } else {
            fwrite($log_file, date('Y-m-d H:i:s') . " - Su seviyesi kaydedilemedi - Sensör veya veri eksik\n");
            // YENİ: Daha detaylı log
            fwrite($log_file, date('Y-m-d H:i:s') . " - Su seviyesi sensör durumu: " . (isset($sensorler['su_seviyesi']) ? "Var (ID: " . $sensorler['su_seviyesi'] . ")" : "Yok") . "\n");
            fwrite($log_file, date('Y-m-d H:i:s') . " - Su seviyesi veri durumu: " . (isset($data['su_seviyesi']) ? "Var (" . $data['su_seviyesi'] . ")" : "Yok") . "\n");
        }
    } catch (Exception $e) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - HATA (Su seviyesi): " . $e->getMessage() . "\n");
    }
    
    // 4. Duman alarmı durumunu kontrol et
    if (isset($data['duman_algilandi']) && $data['duman_algilandi']) {
        try {
            // Duman algılanırsa bildirim oluştur
            $stmt = $conn->prepare("
            INSERT INTO bildirimler (sera_id, baslik, mesaj, tur, okundu)
            VALUES (:sera_id, 'Duman Alarmı!', 'Serada duman/yangın algılandı. Acil durum kontrolü yapın!', 'danger', 0)
            ");
            $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
            $stmt->execute();
            fwrite($log_file, date('Y-m-d H:i:s') . " - Duman alarmı bildirim oluşturuldu\n");
        } catch (Exception $e) {
            fwrite($log_file, date('Y-m-d H:i:s') . " - HATA (Duman alarmı): " . $e->getMessage() . "\n");
        }
    }
    
    // 5. Toprak nemi durumunu kontrol et ve düşükse sulama sistemi çalıştır
    if (isset($data['toprak_nemi']) && $data['toprak_nemi'] < 40 && isset($data['toprak_nemli']) && !$data['toprak_nemli']) {
        try {
            // Sulama sistemini çalıştır
            $stmt = $conn->prepare("
            SELECT id FROM cihazlar WHERE sera_id = :sera_id AND ad LIKE '%sulama%'
            ");
            $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
            $stmt->execute();
            
            if ($stmt->rowCount() > 0) {
                $sulama_cihaz = $stmt->fetch(PDO::FETCH_ASSOC);
                
                // Sulama cihazını aç
                $stmt = $conn->prepare("
                INSERT INTO cihaz_olaylari (cihaz_id, islem, tetikleyici)
                VALUES (:cihaz_id, 'ac', 'otomatik')
                ");
                $stmt->bindParam(':cihaz_id', $sulama_cihaz['id'], PDO::PARAM_INT);
                $stmt->execute();
                
                // Cihaz durumunu güncelle
                $stmt = $conn->prepare("UPDATE cihazlar SET durum = 1 WHERE id = :cihaz_id");
                $stmt->bindParam(':cihaz_id', $sulama_cihaz['id'], PDO::PARAM_INT);
                $stmt->execute();
                
                // Bildirim oluştur
                $stmt = $conn->prepare("
                INSERT INTO bildirimler (sera_id, baslik, mesaj, tur, okundu)
                VALUES (:sera_id, 'Otomatik Sulama Başlatıldı', 'Toprak nemi düşük olduğu için otomatik sulama başlatıldı.', 'info', 0)
                ");
                $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
                $stmt->execute();
                
                fwrite($log_file, date('Y-m-d H:i:s') . " - Otomatik sulama başlatıldı\n");
            }
        } catch (Exception $e) {
            fwrite($log_file, date('Y-m-d H:i:s') . " - HATA (Sulama): " . $e->getMessage() . "\n");
        }
    }
    
    // 6. Su seviyesi kontrolü
    if (isset($data['su_seviyesi']) && $data['su_seviyesi'] < 20) {
        try {
            // Su seviyesi düşük bildirim oluştur
            $stmt = $conn->prepare("
            INSERT INTO bildirimler (sera_id, baslik, mesaj, tur, okundu)
            VALUES (:sera_id, 'Su Seviyesi Kritik', 'Su deposu seviyesi kritik seviyede! Lütfen su deposunu doldurun.', 'warning', 0)
            ");
            $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
            $stmt->execute();
            
            fwrite($log_file, date('Y-m-d H:i:s') . " - Su seviyesi kritik bildirim oluşturuldu\n");
        } catch (Exception $e) {
            fwrite($log_file, date('Y-m-d H:i:s') . " - HATA (Su seviyesi uyarı): " . $e->getMessage() . "\n");
        }
    }
    
    // YENİ: Veri gönderen cihazın son çevrimiçi zamanını güncelle
    try {
        $stmt = $conn->prepare("
            UPDATE cihazlar 
            SET son_cevrimici = CURRENT_TIMESTAMP 
            WHERE id = :cihaz_id
        ");
        $stmt->bindParam(':cihaz_id', $data['cihaz_id'], PDO::PARAM_INT);
        $stmt->execute();
        fwrite($log_file, date('Y-m-d H:i:s') . " - Cihaz son çevrimiçi zamanı güncellendi\n");
    } catch (Exception $e) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - HATA (Cihaz güncelleme): " . $e->getMessage() . "\n");
    }
    
    // İşlemleri tamamla
    $conn->commit();
    
    fwrite($log_file, date('Y-m-d H:i:s') . " - İşlem BAŞARILI: Sensör verileri kaydedildi\n");
    fwrite($log_file, "-----------------------------------------------------\n");
    fclose($log_file);
    
    // Başarılı cevap
    http_response_code(200);
    echo json_encode(['durum' => 'basarili', 'mesaj' => 'Sensör verileri başarıyla kaydedildi']);
    
} catch (Exception $e) {
    // Hata durumunda işlemleri geri al
    if (isset($conn)) {
        $conn->rollBack();
    }
    
    // Hatayı logla
    if (isset($log_file)) {
        fwrite($log_file, date('Y-m-d H:i:s') . " - HATA: " . $e->getMessage() . "\n");
        fwrite($log_file, "-----------------------------------------------------\n");
        fclose($log_file);
    }
    
    // Hata cevabı
    http_response_code(500);
    echo json_encode(['durum' => 'hata', 'mesaj' => $e->getMessage()]);
}
?>