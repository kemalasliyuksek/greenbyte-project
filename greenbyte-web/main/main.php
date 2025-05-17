<?php
date_default_timezone_set('Europe/Istanbul');
// Oturum kontrolü
session_start();

// Kullanıcı giriş yapmış mı kontrol et
if (!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true) {
    header("Location: ../login/login.html");
    exit;
}

// Kullanıcı bilgisi
$kullanici_adi = isset($_SESSION["kullanici_adi"]) ? $_SESSION["kullanici_adi"] : "Kullanıcı";

// Veritabanı bağlantı bilgileri
$servername = "92.205.171.9";
$username = "admin";
$password = "Ke3@1.3ySq1";
$dbname = "greenbyte";

// Sensör değerleri için varsayılan değerler (veri yoksa gösterilecek)
$sicaklik = "--";
$nem = "--";
$isik_seviyesi = "--";
$toprak_nemi = "--";
$co2 = "---";
$su_seviyesi = "--";
$son_guncelleme = "--:--";
$sistem_durumu = "Aktif";
$cihaz_durumu = "Çevrimiçi";

// Yeni eklenen dinamik veri alanları için varsayılan değerler
$hava_durumu = [
    'sicaklik' => '--',
    'yer' => 'Bursa'
];
$isik_detay = [
    'gun_isigi' => '--',
    'isik_suresi' => '--'
];
$su_deposu = [
    'hacim' => '--',
    'kapasite' => '--',
    'yeterlilik' => '--'
];
$co2_detay = [
    'optimal_aralik' => '--',
    'hava_kalitesi' => '--',
    'duman' => '--'
];

// Sensör durumları
$durum_sicaklik = "normal";
$durum_nem = "normal";
$durum_isik = "normal";
$durum_toprak = "normal";
$durum_hava = "normal";
$durum_su = "normal";

// Veritabanından sensör verilerini çekme
try {
    // Kullanıcının sera ID'sini al
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
        
        // Sera için en son sensör verilerini çek
        $stmt = $conn->prepare("
            SELECT 
                s.ad AS sensor_adi,
                sv.deger,
                sv.ek_veri,
                sv.kayit_zamani
            FROM 
                sensorler s
            LEFT JOIN (
                SELECT 
                    sensor_id,
                    deger,
                    ek_veri,
                    kayit_zamani,
                    ROW_NUMBER() OVER (PARTITION BY sensor_id ORDER BY kayit_zamani DESC) as rn
                FROM 
                    sensor_verileri
            ) sv ON s.id = sv.sensor_id AND sv.rn = 1
            WHERE 
                s.sera_id = :sera_id
            ORDER BY 
                s.id
        ");
        $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
        $stmt->execute();
        
        $son_guncelleme = null;
        
        while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
            $sensor_adi = strtolower($row['sensor_adi']);
            $deger = $row['deger'];
            $ek_veri = $row['ek_veri'];
            $zaman = $row['kayit_zamani'];
            
            // Son güncelleme zamanını formatlı
        if ($son_guncelleme) {
        $son_guncelleme = date('H:i:s', strtotime($son_guncelleme));
        }
            
            // Sensör verilerini eşleştir
            if ($deger !== null) {
                if (strpos($sensor_adi, 'sicaklik') !== false) {
                    $sicaklik = floatval($deger);
                    $durum_sicaklik = ($sicaklik >= 22 && $sicaklik <= 28) ? 'normal' : (($sicaklik < 22) ? 'dusuk' : 'yuksek');
                } else if (strpos($sensor_adi, 'nem') !== false && strpos($sensor_adi, 'toprak') === false) {
                    $nem = floatval($deger);
                    $durum_nem = ($nem >= 55 && $nem <= 75) ? 'normal' : (($nem < 55) ? 'dusuk' : 'yuksek');
                } else if (strpos($sensor_adi, 'isik') !== false) {
                    $isik_seviyesi = intval($deger);
                    $durum_isik = ($isik_seviyesi >= 60 && $isik_seviyesi <= 90) ? 'normal' : (($isik_seviyesi < 60) ? 'dusuk' : 'yuksek');
                } else if (strpos($sensor_adi, 'toprak') !== false) {
                    $toprak_nemi = intval($deger);
                    $toprak_nemli = intval($deger) >= 40;
                    $durum_toprak = $toprak_nemli ? 'normal' : 'dusuk';
                } else if (strpos($sensor_adi, 'hava') !== false || strpos($sensor_adi, 'co2') !== false) {
                    if ($ek_veri === 'co2ppm') {
                        $co2 = intval($deger);
                        $durum_hava = ($co2 >= 500 && $co2 <= 800) ? 'normal' : (($co2 < 500) ? 'dusuk' : 'yuksek');
                    }
                } else if (strpos($sensor_adi, 'su') !== false) {
                    $su_seviyesi = intval($deger);
                    $durum_su = ($su_seviyesi >= 20) ? 'normal' : 'kritik';
                }
            }
        }
        
        // Son güncelleme zamanını formatlı
        if ($son_guncelleme) {
            $son_guncelleme = date('H:i', strtotime($son_guncelleme));
        }
         // Sera ayarlarını ve ek bilgileri çek
        $stmt = $conn->prepare("
            SELECT 
                ayar_tipi, 
                ayar_adi, 
                deger 
            FROM 
                sera_ayarlar
            WHERE 
                sera_id = :sera_id
        ");
        $stmt->bindParam(':sera_id', $sera_id, PDO::PARAM_INT);
        $stmt->execute();

        // Veritabanından gelen ayarları yerleştir
        while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
            $tip = $row['ayar_tipi'];
            $ad = $row['ayar_adi'];
            $deger = $row['deger'];
            
            switch ($tip) {
                case 'hava_durumu':
                    $hava_durumu[$ad] = $deger;
                    break;
                case 'isik':
                    $isik_detay[$ad] = $deger;
                    break;
                case 'su_deposu':
                    $su_deposu[$ad] = $deger;
                    break;
                case 'co2':
                    $co2_detay[$ad] = $deger;
                    break;
            }
        }
    }
} catch (PDOException $e) {
    // Hata durumunda gizlice geç, varsayılan değerler kullanılacak
    error_log("Veritabanı hatası: " . $e->getMessage());
}

// Durum sınıfları için yardımcı fonksiyon
function getDurumClass($durum) {
    switch ($durum) {
        case 'normal': return 'normal';
        case 'dusuk': return 'warning';
        case 'yuksek': return 'warning';
        case 'kritik': return 'danger';
        default: return 'normal';
    }
}

// Durum metinleri için yardımcı fonksiyon
function getDurumText($durum) {
    switch ($durum) {
        case 'normal': return 'Normal';
        case 'dusuk': return 'Düşük';
        case 'yuksek': return 'Yüksek';
        case 'kritik': return 'Kritik';
        default: return 'Normal';
    }
}

// Tarih ve saat
$tarih = date("d F Y");
$saat = date("H:i");

// Şu anki hava durumu (örnek değer)
$hava_durumu_sicaklik = "26";
$hava_durumu_yer = "Bursa";
?>
<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>GreenByte - Akıllı Sera Yönetim Paneli</title>
    <link rel="stylesheet" href="main.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <style>
    /* Sensör değerleri için ek stiller */
    .mevcut-deger {
        font-weight: 600;
        font-size: 1.8rem;
        color: var(--dark-green);
    }
    </style>
</head>
<body>
    <div class="dashboard-container">
        <!-- Main Content -->
        <div class="main-content">
            <!-- Top Navigation -->
            <div class="top-nav">
                <div class="site-logo">
                    <i class="fas fa-leaf logo-icon"></i>
                    <h1>GreenByte</h1>
                    <p class="slogan">Akıllı Sera Sistemleri</p>
                </div>
                <div class="user-info">
    <div class="notifications">
        <i class="fas fa-bell"></i>
        <span class="notification-count">0</span>
    </div>
    <div class="user">
        <i class="fas fa-user-circle"></i>
        <span id="kullanici-adi"><?php echo htmlspecialchars($kullanici_adi); ?></span>
    </div>
    <button class="logout-btn" id="logout-link" title="Çıkış Yap">
        <i class="fas fa-sign-out-alt"></i>
    </button>
</div>
            </div>

            <!-- Dashboard Header -->
            <div class="dashboard-header">
                <h2>Sera Kontrol Paneli</h2>
                <div class="dashboard-actions">
                    <div class="weather-info">
                        <i class="fas fa-sun"></i>
                        <span id="weather-temp"><?php echo $hava_durumu_sicaklik; ?>°C</span>
                        <span id="weather-location"><?php echo $hava_durumu_yer; ?></span>
                    </div>
                    <div class="date-time">
                        <span id="current-date"><?php echo $tarih; ?></span>
                        <span id="current-time"><?php echo $saat; ?></span>
                    </div>
                </div>
            </div>

            <!-- System Status -->
            <div class="status-bar">
                <div class="status-item" id="system-status">
                    <i class="fas fa-check-circle"></i>
                    <span>Sistem Durumu: </span>
                    <strong><?php echo ucfirst($sistem_durumu); ?></strong>
                </div>
                <div class="status-item" id="last-update">
                    <i class="fas fa-sync"></i>
                    <span>Son Güncelleme: </span>
                    <strong><?php echo $son_guncelleme; ?></strong>
                </div>
                <div class="status-item" id="device-status">
                    <i class="fas fa-microchip"></i>
                    <span>Cihaz Durumu: </span>
                    <strong><?php echo ucfirst($cihaz_durumu); ?></strong>
                </div>
            </div>

            <!-- Notification Panel (hidden by default) -->
            <div class="notification-panel" id="notification-panel">
                <div class="notification-header">
                    <h3>Bildirimler</h3>
                    <div class="notification-actions">
                        <!-- Tümünü Okundu İşaretle butonu kaldırıldı -->
                        <button id="close-notifications" title="Kapat">
                            <i class="fas fa-times"></i>
                        </button>
                    </div>
                </div>
                <div class="notification-list">
                    <!-- Bildirimler JavaScript ile dinamik olarak buraya eklenecek -->
                    <div class="notification-loading">
                        <i class="fas fa-spinner fa-spin"></i>
                        <p>Bildirimler yükleniyor...</p>
                    </div>
                </div>
            </div>

            <!-- Quick Stats -->
            <div class="quick-stats">
                <!-- İlk satır: Sıcaklık, Hava Nemi, Işık Seviyesi -->
                <div class="stat-card">
                    <div class="stat-icon">
                        <i class="fas fa-temperature-high"></i>
                    </div>
                    <div class="stat-info">
                        <h3>Sıcaklık</h3>
                        <p class="stat-value" id="temperature-value"><?php echo $sicaklik; ?>°C</p>
                        <span class="stat-status <?php echo getDurumClass($durum_sicaklik); ?>"><?php echo getDurumText($durum_sicaklik); ?></span>
                    </div>
                </div>
                
                <div class="stat-card">
                    <div class="stat-icon">
                        <i class="fas fa-tint"></i>
                    </div>
                    <div class="stat-info">
                        <h3>Hava Nemi</h3>
                        <p class="stat-value" id="humidity-value"><?php echo $nem; ?>%</p>
                        <span class="stat-status <?php echo getDurumClass($durum_nem); ?>"><?php echo getDurumText($durum_nem); ?></span>
                    </div>
                </div>
                
                <div class="stat-card">
                    <div class="stat-icon">
                        <i class="fas fa-lightbulb"></i>
                    </div>
                    <div class="stat-info">
                        <h3>Işık Seviyesi</h3>
                        <p class="stat-value" id="light-value"><?php echo $isik_seviyesi; ?>%</p>
                        <span class="stat-status <?php echo getDurumClass($durum_isik); ?>"><?php echo getDurumText($durum_isik); ?></span>
                    </div>
                </div>
                
                <!-- İkinci satır: Toprak Nemi, CO2 Seviyesi, Su Deposu -->
                <div class="stat-card">
                    <div class="stat-icon">
                        <i class="fas fa-water"></i>
                    </div>
                    <div class="stat-info">
                        <h3>Toprak Nemi</h3>
                        <p class="stat-value" id="soil-moisture-value"><?php echo $toprak_nemi; ?>%</p>
                        <span class="stat-status <?php echo getDurumClass($durum_toprak); ?>"><?php echo getDurumText($durum_toprak); ?></span>
                    </div>
                </div>
                
                <div class="stat-card">
                    <div class="stat-icon">
                        <i class="fas fa-flask"></i>
                    </div>
                    <div class="stat-info">
                        <h3>CO2 Seviyesi</h3>
                        <p class="stat-value" id="co2-value"><?php echo $co2; ?> ppm</p>
                        <span class="stat-status <?php echo getDurumClass($durum_hava); ?>"><?php echo getDurumText($durum_hava); ?></span>
                    </div>
                </div>
                
                <div class="stat-card">
                    <div class="stat-icon">
                        <i class="fas fa-fill-drip"></i>
                    </div>
                    <div class="stat-info">
                        <h3>Su Deposu</h3>
                        <p class="stat-value" id="water-level-value"><?php echo $su_seviyesi; ?>%</p>
                        <span class="stat-status <?php echo getDurumClass($durum_su); ?>"><?php echo getDurumText($durum_su); ?></span>
                    </div>
                </div>
            </div>

            <!-- Main Dashboard Panels -->
            <div class="dashboard-panels">
                <!-- Temperature Panel -->
                <div class="dashboard-panel" id="temperature-panel">
                    <div class="panel-header">
                        <h3><i class="fas fa-temperature-high"></i> Sıcaklık Durumu</h3>
                        <div class="panel-actions">
                            <button class="refresh-btn"><i class="fas fa-sync-alt"></i></button>
                            <select id="temperature-time-range">
                                <option value="day">Bugün</option>
                                <option value="week">Bu Hafta</option>
                                <option value="month">Bu Ay</option>
                            </select>
                        </div>
                    </div>
                    <div class="panel-content">
                        <div class="panel-chart">
                            <canvas id="temperature-chart"></canvas>
                        </div>
                        <div class="panel-data">
                            <div class="current-reading">
                                <h4>Mevcut Sıcaklık</h4>
                                <p class="reading-value mevcut-deger" id="current-temperature"><?php echo $sicaklik; ?>°C</p>
                            </div>
                            <div class="reading-details">
                                <div class="detail-item">
                                    <span>Minimum:</span>
                                    <strong>--°C</strong>
                                </div>
                                <div class="detail-item">
                                    <span>Maksimum:</span>
                                    <strong>--°C</strong>
                                </div>
                                <div class="detail-item">
                                    <span>Ortalama:</span>
                                    <strong>--°C</strong>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Humidity Panel -->
                <div class="dashboard-panel" id="humidity-panel">
                    <div class="panel-header">
                        <h3><i class="fas fa-tint"></i> Hava Nemi Durumu</h3>
                        <div class="panel-actions">
                            <button class="refresh-btn"><i class="fas fa-sync-alt"></i></button>
                            <select id="humidity-time-range">
                                <option value="day">Bugün</option>
                                <option value="week">Bu Hafta</option>
                                <option value="month">Bu Ay</option>
                            </select>
                        </div>
                    </div>
                    <div class="panel-content">
                        <div class="panel-chart">
                            <canvas id="humidity-chart"></canvas>
                        </div>
                        <div class="panel-data">
                            <div class="current-reading">
                                <h4>Mevcut Nem</h4>
                                <p class="reading-value mevcut-deger" id="current-humidity"><?php echo $nem; ?>%</p>
                            </div>
                            <div class="reading-details">
                                <div class="detail-item">
                                    <span>Minimum:</span>
                                    <strong>--%</strong>
                                </div>
                                <div class="detail-item">
                                    <span>Maksimum:</span>
                                    <strong>--%</strong>
                                </div>
                                <div class="detail-item">
                                    <span>Ortalama:</span>
                                    <strong>--%</strong>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Soil Moisture Panel -->
                <div class="dashboard-panel" id="soil-panel">
                    <div class="panel-header">
                        <h3><i class="fas fa-water"></i> Toprak Nemi</h3>
                        <div class="panel-actions">
                            <button class="refresh-btn"><i class="fas fa-sync-alt"></i></button>
                        </div>
                    </div>
                    <div class="panel-content">
                        <div class="moisture-gauge">
                            <div class="gauge-container">
                                <div class="gauge" id="soil-gauge">
                                    <div class="gauge-value" style="height: <?php echo ($toprak_nemi !== '--') ? $toprak_nemi . '%' : '0%'; ?>"></div>
                                </div>
                                <div class="gauge-labels">
                                    <span>100%</span>
                                    <span>75%</span>
                                    <span>50%</span>
                                    <span>25%</span>
                                    <span>0%</span>
                                </div>
                            </div>
                            <div class="gauge-reading">
                                <h4>Mevcut Değer</h4>
                                <p class="mevcut-deger" id="soil-gauge-value"><?php echo $toprak_nemi; ?>%</p>
                                <p class="gauge-status <?php echo getDurumClass($durum_toprak); ?>"><?php echo ($durum_toprak === 'normal') ? 'Normal' : 'Sulama Gerekli'; ?></p>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Light Level Panel -->
                <div class="dashboard-panel" id="light-panel">
                    <div class="panel-header">
                        <h3><i class="fas fa-lightbulb"></i> Işık Seviyesi</h3>
                        <div class="panel-actions">
                            <button class="refresh-btn"><i class="fas fa-sync-alt"></i></button>
                        </div>
                    </div>
                    <div class="panel-content">
                        <div class="light-chart-container">
                            <canvas id="light-chart"></canvas>
                        </div>
                        <div class="light-status">
                            <div class="light-reading">
                                <h4>Mevcut Değer</h4>
                                <p class="mevcut-deger" id="current-light"><?php echo $isik_seviyesi; ?>%</p>
                            </div>
                            <div class="light-info">
                                <div class="light-detail">
                                    <span>Gün Işığı:</span>
                                    <strong>Yeterli</strong>
                                </div>
                                <div class="light-detail">
                                    <span>Işık Süresi:</span>
                                    <strong>12 saat</strong>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Water Level Panel -->
                <div class="dashboard-panel" id="water-panel">
                    <div class="panel-header">
                        <h3><i class="fas fa-fill-drip"></i> Su Deposu</h3>
                        <div class="panel-actions">
                            <button class="refresh-btn"><i class="fas fa-sync-alt"></i></button>
                        </div>
                    </div>
                    <div class="panel-content">
                        <div class="water-tank-container">
                            <div class="water-tank">
                                <div class="water-level" style="height: <?php echo ($su_seviyesi !== '--') ? $su_seviyesi . '%' : '0%'; ?>"></div>
                                <div class="water-labels">
                                    <span class="water-mark" style="bottom: 75%">75%</span>
                                    <span class="water-mark" style="bottom: 50%">50%</span>
                                    <span class="water-mark" style="bottom: 25%">25%</span>
                                    <span class="water-mark warning" style="bottom: 20%">20%</span>
                                </div>
                            </div>
                            <div class="water-reading">
                                <h4>Su Seviyesi</h4>
                                <p class="mevcut-deger" id="water-percentage"><?php echo $su_seviyesi; ?>%</p>
                                <?php if ($durum_su === 'kritik'): ?>
                                <p class="warning"><i class="fas fa-exclamation-triangle"></i> Kritik Seviye</p>
                                <?php endif; ?>
                            </div>
                        </div>
                        <div class="panel-data">
                            <div class="detail-item">
                                <span>Mevcut Hacim:</span>
                                <strong>-- L</strong>
                            </div>
                            <div class="detail-item">
                                <span>Toplam Kapasite:</span>
                                <strong>200 L</strong>
                            </div>
                            <div class="detail-item">
                                <span>Tahmini Yeterlilik:</span>
                                <strong>-- gün</strong>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- CO2 Panel -->
                <div class="dashboard-panel" id="co2-panel">
                    <div class="panel-header">
                        <h3><i class="fas fa-flask"></i> CO2 ve Hava Kalitesi</h3>
                        <div class="panel-actions">
                            <button class="refresh-btn"><i class="fas fa-sync-alt"></i></button>
                        </div>
                    </div>
                    <div class="panel-content">
                        <div class="co2-chart-container">
                            <canvas id="co2-chart"></canvas>
                        </div>
                        <div class="co2-status">
                            <div class="co2-reading">
                                <h4>CO2 Seviyesi</h4>
                                <p class="mevcut-deger" id="current-co2"><?php echo $co2; ?> ppm</p>
                                <p class="<?php echo getDurumClass($durum_hava); ?>">
                                    <?php echo ($durum_hava === 'normal') ? 'Normal Aralık' : (($durum_hava === 'dusuk') ? 'Düşük Seviye' : 'Yüksek Seviye'); ?>
                                </p>
                            </div>
                            <div class="co2-info">
                                <div class="co2-detail">
                                    <span>Bitki İçin Optimal:</span>
                                    <strong>600-800 ppm</strong>
                                </div>
                                <div class="co2-detail">
                                    <span>Hava Kalitesi:</span>
                                    <strong>--%</strong>
                                </div>
                                <div class="co2-detail">
                                    <span>Duman/Yangın:</span>
                                    <strong class="normal">Algılanmadı</strong>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="data_fetcher.js"></script>
    <script src="main.js"></script>
    <script src="notifications.js"></script> <!-- Bildirim scripti -->
    
    <script>
        document.getElementById('logout-link').addEventListener('click', function() {
            fetch('../api/logout.php')
                .then(response => response.json())
                .then(data => {
                    if (data.status === 'success') {
                        window.location.href = '../login/login.html';
                    } else {
                        alert('Çıkış yapılırken bir hata oluştu.');
                    }
                })
                .catch(error => {
                    console.error('Çıkış hatası:', error);
                    window.location.href = '../login/login.html'; // Hata alsa bile çıkış yap
                });
        });
    </script>

    <script src="direct_sensors.js"></script>
    <script>
document.addEventListener('DOMContentLoaded', function() {
    // direct_sensors.js dosyasındaki fetchSensorData fonksiyonunu çağır
    if (typeof fetchSensorData === 'function') {
        setTimeout(fetchSensorData, 500);
    }
});
</script>
</body>
</html>