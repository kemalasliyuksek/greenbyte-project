<?php
// Oturum başlat
session_start();

// Veritabanı bağlantı bilgileri
$servername = "92.205.171.9"; 
$username = "admin"; 
$password = "Ke3@1.3ySq1"; 
$dbname = "greenbyte"; 

// JSON yanıtı mı yoksa normal yanıt mı olacağını kontrol et
$isAjaxRequest = !empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest';

// Form gönderildi mi kontrolü
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Kullanıcı adı ve şifre alınıyor
    $kullanici_adi = isset($_POST["kullanici_adi"]) ? $_POST["kullanici_adi"] : "";
    $sifre = isset($_POST["sifre"]) ? $_POST["sifre"] : "";
    
    // Boş veri kontrolü
    if (empty($kullanici_adi) || empty($sifre)) {
        if ($isAjaxRequest) {
            header('Content-Type: application/json');
            echo json_encode(['status' => 'error', 'message' => 'Kullanıcı adı ve şifre gereklidir.']);
        } else {
            header("Location: login.html?error=empty_fields");
        }
        exit;
    }
    
    try {
        // Veritabanı bağlantısı oluştur
        $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
        // PDO hata modunu ayarla
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        
        // Kullanıcıyı veritabanında ara
        $stmt = $conn->prepare("SELECT id, kullanici_adi, sifre FROM kullanicilar WHERE kullanici_adi = :kullanici_adi");
        $stmt->bindParam(':kullanici_adi', $kullanici_adi);
        $stmt->execute();
        
        // Kullanıcı bulundu mu kontrolü
        if ($stmt->rowCount() > 0) {
            $row = $stmt->fetch(PDO::FETCH_ASSOC);
            $stored_password = $row["sifre"];
            
            // Düz metin şifre karşılaştırması - şifreler direkt olarak veritabanında saklandığı için
            if ($sifre === $stored_password) {
                // Giriş başarılı, session'a bilgileri kaydet
                $_SESSION["loggedin"] = true;
                $_SESSION["id"] = $row["id"];
                $_SESSION["kullanici_adi"] = $row["kullanici_adi"];
                
                // Beni hatırla seçeneği işaretlenmişse çerez oluştur
                if (isset($_POST["remember"]) && $_POST["remember"] === "on") {
                    $cookie_name = "user";
                    $cookie_value = $row["kullanici_adi"];
                    setcookie($cookie_name, $cookie_value, time() + (86400 * 30), "/"); // 30 gün
                }
                
                // AJAX isteği ise JSON yanıtı, değilse doğrudan yönlendirme yap
                if ($isAjaxRequest) {
                    header('Content-Type: application/json');
                    echo json_encode(['status' => 'success', 'message' => 'Giriş başarılı']);
                } else {
                    // Doğrudan main.php'e yönlendir
                    header("Location: ../main/main.php");
                }
                exit;
            } else {
                // Şifre yanlış
                if ($isAjaxRequest) {
                    header('Content-Type: application/json');
                    echo json_encode(['status' => 'error', 'message' => 'Geçersiz kullanıcı adı veya şifre.']);
                } else {
                    header("Location: login.html?error=invalid_password");
                }
                exit;
            }
        } else {
            // Kullanıcı bulunamadı
            if ($isAjaxRequest) {
                header('Content-Type: application/json');
                echo json_encode(['status' => 'error', 'message' => 'Geçersiz kullanıcı adı veya şifre.']);
            } else {
                header("Location: login.html?error=invalid_username");
            }
            exit;
        }
    } catch(PDOException $e) {
        if ($isAjaxRequest) {
            header('Content-Type: application/json');
            echo json_encode(['status' => 'error', 'message' => 'Veritabanı hatası: ' . $e->getMessage()]);
        } else {
            header("Location: login.html?error=database");
        }
        exit;
    }
    
    // Bağlantıyı kapat
    $conn = null;
} else {
    // POST isteği değilse hata döndür
    if ($isAjaxRequest) {
        header('Content-Type: application/json');
        echo json_encode(['status' => 'error', 'message' => 'Geçersiz istek metodu.']);
    } else {
        header("Location: login.html?error=invalid_method");
    }
    exit;
}
?>