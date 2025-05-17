CREATE DATABASE IF NOT EXISTS `greenbyte` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci;
USE `greenbyte`;

CREATE TABLE `bildirimler` (
  `id` int(11) NOT NULL,
  `sera_id` int(11) NOT NULL,
  `baslik` varchar(100) NOT NULL,
  `mesaj` text NOT NULL,
  `tur` enum('info','success','warning','danger') DEFAULT 'info',
  `okundu` tinyint(1) DEFAULT 0,
  `olusturma_zamani` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `bitkiler` (
  `id` int(11) NOT NULL,
  `sera_id` int(11) NOT NULL,
  `bitki_tur_id` int(11) NOT NULL,
  `bolge_kodu` varchar(50) NOT NULL,
  `ekim_tarihi` date NOT NULL,
  `gelisim_yuzdesi` float DEFAULT 0,
  `tahmini_hasat_tarihi` date DEFAULT NULL,
  `notlar` text DEFAULT NULL,
  `durum` enum('aktif','hasat_edildi','iptal') DEFAULT 'aktif',
  `son_guncelleme` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `bitki_turleri` (
  `id` int(11) NOT NULL,
  `tur_adi` varchar(100) NOT NULL,
  `min_sicaklik` float DEFAULT NULL,
  `max_sicaklik` float DEFAULT NULL,
  `min_nem` float DEFAULT NULL,
  `max_nem` float DEFAULT NULL,
  `min_gunluk_isik_saati` float DEFAULT NULL,
  `max_gunluk_isik_saati` float DEFAULT NULL,
  `min_isik_yogunlugu` int(11) DEFAULT NULL,
  `max_isik_yogunlugu` int(11) DEFAULT NULL,
  `min_toprak_nemi` float DEFAULT NULL,
  `max_toprak_nemi` float DEFAULT NULL,
  `sulama_sikligi` int(11) DEFAULT NULL,
  `yetistirme_suresi` int(11) DEFAULT NULL,
  `notlar` text DEFAULT NULL,
  `eklenme_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `cihazlar` (
  `id` int(11) NOT NULL,
  `sera_id` int(11) DEFAULT NULL,
  `ad` varchar(100) DEFAULT NULL,
  `durum` tinyint(1) DEFAULT 0,
  `eklenme_tarihi` datetime DEFAULT current_timestamp(),
  `son_cevrimici` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `cihaz_olaylari` (
  `id` int(11) NOT NULL,
  `cihaz_id` int(11) DEFAULT NULL,
  `islem` enum('ac','kapat') DEFAULT NULL,
  `tetikleyici` enum('manuel','otomatik') DEFAULT NULL,
  `zaman` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `hava_durumu` (
  `id` int(11) NOT NULL,
  `sera_id` int(11) DEFAULT NULL,
  `sicaklik` float DEFAULT NULL,
  `nem` float DEFAULT NULL,
  `ruzgar_hizi` float DEFAULT NULL,
  `yagis` tinyint(1) DEFAULT NULL,
  `hava_durumu_aciklama` varchar(100) DEFAULT NULL,
  `kayit_zamani` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `kullanicilar` (
  `id` int(11) NOT NULL,
  `sera_id` int(11) DEFAULT NULL,
  `kullanici_adi` varchar(50) NOT NULL,
  `sifre` varchar(255) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `kayit_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `log_kayitlari` (
  `id` int(11) NOT NULL,
  `kullanici_id` int(11) DEFAULT NULL,
  `log_tipi` enum('Info','Error') NOT NULL,
  `mesaj` text DEFAULT NULL,
  `log_zamani` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `sensorler` (
  `id` int(11) NOT NULL,
  `sera_id` int(11) DEFAULT NULL,
  `ad` varchar(100) DEFAULT NULL,
  `durum` tinyint(1) DEFAULT 0,
  `eklenme_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `sensor_verileri` (
  `id` int(11) NOT NULL,
  `sensor_id` int(11) DEFAULT NULL,
  `deger` float DEFAULT NULL,
  `ek_veri` varchar(50) DEFAULT NULL,
  `kayit_zamani` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `seralar` (
  `id` int(11) NOT NULL,
  `kullanici_id` int(11) DEFAULT NULL,
  `ad` varchar(100) DEFAULT NULL,
  `konum` varchar(255) DEFAULT NULL,
  `olusturma_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

CREATE TABLE `sera_ayarlar` (
  `id` int(11) NOT NULL,
  `sera_id` int(11) NOT NULL,
  `ayar_tipi` varchar(50) NOT NULL,
  `ayar_adi` varchar(50) DEFAULT NULL,
  `deger` varchar(100) NOT NULL,
  `otomatik` tinyint(1) DEFAULT 0,
  `guncelleme_zamani` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;


ALTER TABLE `bildirimler`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sera_id` (`sera_id`);

ALTER TABLE `bitkiler`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sera_id` (`sera_id`),
  ADD KEY `bitki_tur_id` (`bitki_tur_id`);

ALTER TABLE `bitki_turleri`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `cihazlar`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sera_id` (`sera_id`);

ALTER TABLE `cihaz_olaylari`
  ADD PRIMARY KEY (`id`),
  ADD KEY `cihaz_id` (`cihaz_id`);

ALTER TABLE `hava_durumu`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sera_id` (`sera_id`);

ALTER TABLE `kullanicilar`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `kullanici_adi` (`kullanici_adi`);

ALTER TABLE `log_kayitlari`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `sensorler`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sera_id` (`sera_id`);

ALTER TABLE `sensor_verileri`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sensor_id` (`sensor_id`);

ALTER TABLE `seralar`
  ADD PRIMARY KEY (`id`),
  ADD KEY `seralar_ibfk_1` (`kullanici_id`);

ALTER TABLE `sera_ayarlar`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `sera_ayar_unique` (`sera_id`,`ayar_tipi`,`ayar_adi`);


ALTER TABLE `bildirimler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `bitkiler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `bitki_turleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `cihazlar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `cihaz_olaylari`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `hava_durumu`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `kullanicilar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `log_kayitlari`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `sensorler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `sensor_verileri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `seralar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `sera_ayarlar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;


ALTER TABLE `bildirimler`
  ADD CONSTRAINT `bildirimler_ibfk_1` FOREIGN KEY (`sera_id`) REFERENCES `seralar` (`id`) ON DELETE CASCADE;

ALTER TABLE `bitkiler`
  ADD CONSTRAINT `bitkiler_ibfk_1` FOREIGN KEY (`sera_id`) REFERENCES `seralar` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `bitkiler_ibfk_2` FOREIGN KEY (`bitki_tur_id`) REFERENCES `bitki_turleri` (`id`);

ALTER TABLE `cihazlar`
  ADD CONSTRAINT `cihazlar_ibfk_1` FOREIGN KEY (`sera_id`) REFERENCES `seralar` (`id`) ON DELETE CASCADE;

ALTER TABLE `cihaz_olaylari`
  ADD CONSTRAINT `cihaz_olaylari_ibfk_1` FOREIGN KEY (`cihaz_id`) REFERENCES `cihazlar` (`id`) ON DELETE CASCADE;

ALTER TABLE `hava_durumu`
  ADD CONSTRAINT `hava_durumu_ibfk_1` FOREIGN KEY (`sera_id`) REFERENCES `seralar` (`id`) ON DELETE CASCADE;

ALTER TABLE `sensorler`
  ADD CONSTRAINT `sensorler_ibfk_1` FOREIGN KEY (`sera_id`) REFERENCES `seralar` (`id`) ON DELETE CASCADE;

ALTER TABLE `sensor_verileri`
  ADD CONSTRAINT `sensor_verileri_ibfk_1` FOREIGN KEY (`sensor_id`) REFERENCES `sensorler` (`id`) ON DELETE CASCADE;

ALTER TABLE `seralar`
  ADD CONSTRAINT `seralar_ibfk_1` FOREIGN KEY (`kullanici_id`) REFERENCES `kullanicilar` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION;

ALTER TABLE `sera_ayarlar`
  ADD CONSTRAINT `sera_ayarlar_ibfk_1` FOREIGN KEY (`sera_id`) REFERENCES `seralar` (`id`) ON DELETE CASCADE;