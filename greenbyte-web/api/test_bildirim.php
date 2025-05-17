<?php
// test_bildirim.php adında yeni bir dosya oluşturun
header('Content-Type: application/json');
header('Access-Control-Allow-Origin: *'); // CORS sorunlarını önlemek için

// Sabit test verisi döndür
echo json_encode([
    'durum' => 'basarili',
    'bildirimler' => [
        [
            'id' => 1,
            'baslik' => 'Test Bildirimi',
            'mesaj' => 'Bu bir test bildirimidir',
            'olusturma_zamani' => date('Y-m-d H:i:s'),
            'okundu' => 0,
            'tur' => 'info'
        ]
    ],
    'okunmamis_sayi' => 1
]);
?>