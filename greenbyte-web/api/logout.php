<?php
session_start();
header('Content-Type: application/json');

// Oturumu kapat
session_unset();
session_destroy();

// Çerezleri temizle
if (isset($_COOKIE['user'])) {
    setcookie('user', '', time() - 3600, '/');
}

echo json_encode(['status' => 'success', 'message' => 'Çıkış başarılı']);
?>