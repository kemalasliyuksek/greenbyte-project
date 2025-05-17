<?php
// bildirim_okundu.php - Bildirimi okundu olarak işaretleyen API
session_start();

// Oturum kontrolü
if (!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true) {
    header('Content-Type: application/json');
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Oturum açık değil']);
    exit;
}

// POST verisi kontrolü
if (!isset($_POST['bildirim_id']) || empty($_POST['bildirim_id'])) {
    header('Content-Type: application/json');
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Bildirim ID gerekli']);
    exit;
}

$bildirim_id = $_POST['bildirim_id'];
$tumu_okundu = isset($_POST['tumu_okundu']) ? $_POST['tumu_okundu'] : false;

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
        
        if ($tumu_okundu) {
            // Tüm bildirimleri okundu olarak işaretle
            $stmt = $conn->prepare("
                UPDATE bildirimler 
                SET okundu = 1 
                WHERE sera_id = :sera_id
            ");
            $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
            $stmt->execute();
            
            echo json_encode(['durum' => 'basarili', 'mesaj' => 'Tüm bildirimler okundu olarak işaretlendi']);
        } else {
            // Tek bir bildirimi okundu olarak işaretle
            $stmt = $conn->prepare("
                UPDATE bildirimler 
                SET okundu = 1 
                WHERE id = :bildirim_id AND sera_id = :sera_id
            ");
            $stmt->bindParam(':bildirim_id', $bildirim_id, PDO::PARAM_INT);
            $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
            $stmt->execute();
            
            echo json_encode(['durum' => 'basarili', 'mesaj' => 'Bildirim okundu olarak işaretlendi']);
        }
    } else {
        echo json_encode(['durum' => 'hata', 'mesaj' => 'Sera bulunamadı']);
    }
} catch (PDOException $e) {
    echo json_encode(['durum' => 'hata', 'mesaj' => 'Veritabanı hatası: ' . $e->getMessage()]);
}
?>