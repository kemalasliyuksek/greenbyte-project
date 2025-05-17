<?php
// Oturum kontrolü
session_start();
header('Content-Type: application/json');

// Debug için
error_reporting(E_ALL);
ini_set('display_errors', 1);

// Kullanıcı giriş yapmış mı kontrol et
if (!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true) {
    http_response_code(401); // Unauthorized
    echo json_encode(['status' => 'error', 'message' => 'Oturum açmanız gerekiyor']);
    exit;
}

// Kullanıcı bilgilerini getir
echo json_encode([
    'status' => 'success',
    'kullanici_id' => $_SESSION["id"],
    'kullanici_adi' => $_SESSION["kullanici_adi"]
]);