<?php
// bildirim_getir.php - Bildirimleri getirmek için API
header('Content-Type: application/json');
session_start();

// Oturum kontrolü
if (!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true) {
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Oturum açık değil']);
    exit;
}

// Veritabanı bağlantı bilgileri
$servername = "92.205.171.9";
$username = "admin";
$password = "Ke3@1.3ySq1";
$dbname = "greenbyte";

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    
    // Kullanıcının sera ID'sini al
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
        
        // SADECE OKUNMAMIŞ bildirimleri çek (son 10 bildirim)
        $stmt = $conn->prepare("
            SELECT 
                id,
                baslik,
                mesaj,
                olusturma_zamani,
                okundu,
                tur
            FROM 
                bildirimler
            WHERE 
                sera_id = :sera_id AND (okundu IS NULL OR okundu = 0)
            ORDER BY 
                olusturma_zamani DESC
            LIMIT 10
        ");
        $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
        $stmt->execute();
        
        $bildirimler = $stmt->fetchAll(PDO::FETCH_ASSOC);
        
        // Okunmamış bildirim sayısını hesapla
        $stmt = $conn->prepare("
            SELECT COUNT(*) as okunmamis_sayi
            FROM bildirimler
            WHERE sera_id = :sera_id AND (okundu IS NULL OR okundu = 0)
        ");
        $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
        $stmt->execute();
        $okunmamis = $stmt->fetch(PDO::FETCH_ASSOC);
        
        // Bildirim sonuçlarını döndür
        echo json_encode([
            'durum' => 'basarili',
            'bildirimler' => $bildirimler,
            'okunmamis_sayi' => $okunmamis['okunmamis_sayi']
        ]);
    } else {
        echo json_encode(['durum' => 'hata', 'mesaj' => 'Sera bulunamadı']);
    }
} catch (PDOException $e) {
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Veritabanı hatası: ' . $e->getMessage()]);
}
?>