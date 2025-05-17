// ESP32 Akıllı Sera Projesi - WiFi ve API Entegrasyonu
// Gerekli kütüphaneler
#include <DHT.h>
#include <WiFi.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>

// WiFi ayarları
const char* ssid = "Superbox53";
const char* password = "SuperB0x.53";
const char* apiUrl = "http://kemalasliyuksek.com/greenbyte/api/sensor_kaydet.php"; // API endpoint'iniz

// Sensör pinleri
#define DHT_PIN 21          // DHT11 için GPIO21 pini (WIRE_SDA olarak gösterilen pin)
#define LDR_PIN 34          // LDR için GPIO34 pini (ADC1_6)
#define MQ135_PIN 35        // MQ135 için GPIO35 pini (ADC1_7)
#define TOPRAK_NEM_PIN_ANALOG 32   // Toprak nemi analog pin (AO) - GPIO32 (ADC1_4)
#define TOPRAK_NEM_PIN_DIJITAL 25  // Toprak nemi dijital pin (DO) - GPIO25 (GPIO25/DAC1)
#define SU_SEVIYE_PIN 33    // Su seviye sensörü için GPIO33 pini (ADC1_5)

// RÖLE PİNLERİ TANIMLAMALARI
#define FAN_ROLE_PIN 26      // Fan kontrolü için röle pini (GPIO26)
#define LED_ROLE_PIN 27      // LED şerit kontrolü için röle pini (GPIO27)
#define SU_POMPASI_ROLE_PIN 13      // Su pompası için röle pini (GPIO13)

// Röle Açık/Kapalı Tanımlamaları - Röle modülünüzün tipine göre ayarlayın
#define ROLE_ACIK LOW        // Röle modülünüzün tetikleme mantığı LOW ise (Genelde LOW ile tetiklenir)
#define ROLE_KAPALI HIGH     // Röle modülünüzün kapalı durumu HIGH ise

// Fan kontrolü için eşik değerleri
#define SICAKLIK_ESIK 25.0   // Sıcaklık bu değerin üzerine çıkarsa fan açılır
#define NEM_ESIK 70.0        // Nem bu değerin üzerine çıkarsa fan açılır

// LED şerit kontrolü için eşik değeri
#define ISIK_ESIK 30         // Işık seviyesi bu değerin altına düşerse LED şerit açılır

// Su pompası kontrolü için eşik değeri
#define TOPRAK_NEM_ESIK 20   // Toprak nemi bu değerin altına düşerse su pompası çalışır

// ESP32 kimlik bilgisi
const int CIHAZ_ID = 1;     // Bu ESP32'nin veritabanındaki cihaz ID'si

// DHT sensör tipi
#define DHT_TIP DHT11

// ADC çözünürlüğü (ESP32 için)
#define ADC_COZUNURLUK 4095  // ESP32'nin ADC çözünürlüğü (12-bit)

// MQ135 eşik değerleri - DUMAN EŞİK DEĞERİ DÜŞÜRÜLMÜŞTİR
#define DUMAN_ESIK 1500     // Duman/yangın algılama eşiği (ham değer - düşürüldü)
#define DUMAN_ARTIS_ESIK 300 // Ani artış eşiği

// DHT sensör objesi
DHT dhtSensor(DHT_PIN, DHT_TIP);

// Değişkenler
float sicaklik;         // Sıcaklık değeri (°C)
float nem;              // Nem değeri (%)
int isikSeviyesi;       // Işık seviyesi (ham ADC değeri)
int isikSeviyesiYuzde;  // Işık seviyesi (%)
int havaKalitesi;       // Hava kalitesi (ham ADC değeri)
int oncekiHavaKalitesi = 0; // Önceki ölçüm değeri
int havaKalitesiYuzde;  // Hava kalitesi (%)
float co2ppm;           // CO2 seviyesi (ppm)
bool dumanVarMi;        // Duman/yangın durumu
int toprakNemi;         // Toprak nemi (ham ADC değeri)
int toprakNemiYuzde;    // Toprak nemi (%)
bool toprakNemlimi;     // Toprak nem durumu (true=nemli, false=kuru)
int suSeviyesi;         // Su seviyesi (ham ADC değeri)
int suSeviyesiYuzde;    // Su seviyesi (%)

// Rölelerin mevcut durumu
bool fanDurumu = false;      // Başlangıçta fan kapalı
bool ledDurumu = false;      // Başlangıçta LED şerit kapalı
bool suPompasiDurumu = false;        // Başlangıçta su pompası kapalı
unsigned long suPompasiBaslangicZamani = 0; // Su pompası başlangıç zamanı
const long suPompasiCalismaZamani = 2000;  // Su pompası çalışma süresi (2 saniye)

// Veri gönderme için zaman değişkenleri
unsigned long sonVeriGondermeSuresi = 0;
const long veriGondermeAraligi = 15000; // 15 saniyede bir veri gönder (milisaniye)

// Röle durum kontrolü için zaman değişkenleri
unsigned long sonRoleDurumKontrol = 0;
const long roleDurumKontrolAraligi = 5000; // 5 saniyede bir kontrol

void setup() {
  // Serial bağlantısı başlatılıyor
  Serial.begin(115200);
  Serial.println("ESP32 Akıllı Sera Sistemi Başlatılıyor...");

  // Röle pinleri için çıkış ayarları
  pinMode(FAN_ROLE_PIN, OUTPUT);
  pinMode(LED_ROLE_PIN, OUTPUT);
  pinMode(SU_POMPASI_ROLE_PIN, OUTPUT);
  
  // Röleleri başlangıçta kapalı duruma getir
  digitalWrite(FAN_ROLE_PIN, ROLE_KAPALI);
  digitalWrite(LED_ROLE_PIN, ROLE_KAPALI);
  digitalWrite(SU_POMPASI_ROLE_PIN, ROLE_KAPALI);
  
  Serial.println("Röle kontrolleri hazır!");

  // WiFi bağlantısı kuruyoruz
  WiFi.begin(ssid, password);
  Serial.print("WiFi'ye bağlanılıyor");
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  
  Serial.println("");
  Serial.println("WiFi bağlantısı kuruldu!");
  Serial.print("IP Adresi: ");
  Serial.println(WiFi.localIP());
  
  // DHT sensörü başlatılıyor
  dhtSensor.begin();
  
  // Toprak nemi dijital pin modu ayarlanıyor
  pinMode(TOPRAK_NEM_PIN_DIJITAL, INPUT);
  
  // ADC çözünürlüğü ayarlanıyor (ESP32 için)
  analogReadResolution(12);  // ESP32 için 12-bit çözünürlük
  
  // Kısa bir bekleme
  delay(2000);
  
  // İlk okuma
  oncekiHavaKalitesi = analogRead(MQ135_PIN);
  
  Serial.println("Sensörler hazır!");
  Serial.println("---------------------------------------------");
}

// MQ135 sensöründen CO2 PPM hesaplama (düzeltilmiş basit yaklaşım)
float hesaplaCO2PPM(int sensorDeger) {
  // Doğrudan ADC değerinden yaklaşık CO2 PPM'e dönüştürme
  // 400 ppm (temiz hava) - 2000 ppm (kirli) aralığında
  float co2ppm = map(sensorDeger, 1000, 3000, 400, 2000);
  
  // Makul aralıkta değer döndürme
  if (co2ppm < 0) co2ppm = 0; // Atmosferik minimum
  if (co2ppm > 5000) co2ppm = 5000; // Üst limit
  
  return co2ppm;
}

// Sensör verilerini oku
void sensorleriOku() {
  // 1. DHT11 sensöründen sıcaklık ve nem verilerini oku
  sicaklik = dhtSensor.readTemperature();
  nem = dhtSensor.readHumidity();
  
  // DHT11 okuma hatası kontrolü
  if (isnan(sicaklik) || isnan(nem)) {
    Serial.println("DHT11 sensöründen veri okunamadı!");
  }
  
  // 2. LDR sensöründen ışık seviyesini oku (İki bacaklı LDR için)
  isikSeviyesi = analogRead(LDR_PIN);
  isikSeviyesiYuzde = map(isikSeviyesi, 0, ADC_COZUNURLUK, 0, 100);
  
  // 3. MQ135 sensöründen hava kalitesini oku
  havaKalitesi = analogRead(MQ135_PIN);
  havaKalitesiYuzde = map(havaKalitesi, 0, ADC_COZUNURLUK, 0, 100);
  
  // MQ135 CO2 PPM hesaplama
  co2ppm = hesaplaCO2PPM(havaKalitesi);
  
  // Duman/yangın kontrolü - iki koşulu kontrol ediyoruz:
  // 1. Eşik değerini geçmiş mi?
  // 2. Önceki ölçüme göre ani bir artış var mı?
  int havaKalitesiArtisi = havaKalitesi - oncekiHavaKalitesi;
  dumanVarMi = (havaKalitesi > DUMAN_ESIK || havaKalitesiArtisi > DUMAN_ARTIS_ESIK);
  
  // Önceki değeri güncelle
  oncekiHavaKalitesi = havaKalitesi;
  
  // 4. Toprak nemi sensöründen toprak nemini oku (4 pinli modül)
  // a. Analog değer okuma
  toprakNemi = analogRead(TOPRAK_NEM_PIN_ANALOG);
  toprakNemiYuzde = map(toprakNemi, ADC_COZUNURLUK, 0, 0, 100);  // Değer ters çevriliyor
  
  // b. Dijital değer okuma (eşik değerini aşıp aşmadığı)
  toprakNemlimi = !digitalRead(TOPRAK_NEM_PIN_DIJITAL); // NOT operatörü ile tersini alıyoruz (LOW=nemli, HIGH=kuru)
  
  // 5. Su seviye sensöründen su seviyesini oku
  suSeviyesi = analogRead(SU_SEVIYE_PIN);
  suSeviyesiYuzde = map(suSeviyesi, 0, ADC_COZUNURLUK, 0, 100);
}

// Fan kontrolü - Sıcaklık ve nem değerlerine göre
void fanKontrol() {
  // Sıcaklık veya nem eşik değerlerini aşarsa fanı çalıştır
  if (sicaklik > SICAKLIK_ESIK || nem > NEM_ESIK) {
    if (!fanDurumu) {  // Eğer fan kapalıysa açalım
      digitalWrite(FAN_ROLE_PIN, ROLE_ACIK);
      fanDurumu = true;
      Serial.println("FAN AÇILDI! Sıcaklık: " + String(sicaklik) + "°C, Nem: " + String(nem) + "%");
    }
  } else {
    if (fanDurumu) {  // Eğer fan açıksa kapatalım
      digitalWrite(FAN_ROLE_PIN, ROLE_KAPALI);
      fanDurumu = false;
      Serial.println("FAN KAPATILDI! Sıcaklık: " + String(sicaklik) + "°C, Nem: " + String(nem) + "%");
    }
  }
}

// LED şerit kontrolü - Işık seviyesine göre
void ledKontrol() {
  // Işık seviyesi eşik değerinin altındaysa LED şeridi aç
  if (isikSeviyesiYuzde < ISIK_ESIK) {
    if (!ledDurumu) {  // Eğer LED kapalıysa açalım
      digitalWrite(LED_ROLE_PIN, ROLE_ACIK);
      ledDurumu = true;
      Serial.println("LED ŞERİT AÇILDI! Işık Seviyesi: " + String(isikSeviyesiYuzde) + "%");
    }
  } else {
    if (ledDurumu) {  // Eğer LED açıksa kapatalım
      digitalWrite(LED_ROLE_PIN, ROLE_KAPALI);
      ledDurumu = false;
      Serial.println("LED ŞERİT KAPATILDI! Işık Seviyesi: " + String(isikSeviyesiYuzde) + "%");
    }
  }
}

// Verileri API'ye gönder
void verileriGonder() {
  // WiFi bağlantı kontrolü
  if (WiFi.status() != WL_CONNECTED) {
    Serial.println("WiFi bağlantısı kesildi. Yeniden bağlanılıyor...");
    WiFi.reconnect();
    return;
  }
  
  // JSON verisi oluşturuyoruz
  StaticJsonDocument<256> doc;
  
  doc["cihaz_id"] = CIHAZ_ID;
  doc["sicaklik"] = sicaklik;
  doc["nem"] = nem;
  doc["isik_seviyesi"] = isikSeviyesiYuzde;
  doc["toprak_nemi"] = toprakNemiYuzde;
  doc["co2ppm"] = (int)co2ppm;
  doc["su_seviyesi"] = suSeviyesiYuzde;
  // Röle durumlarını da ekleyelim
  doc["fan_durumu"] = fanDurumu;
  doc["led_durumu"] = ledDurumu;
  doc["su_pompasi_durumu"] = suPompasiDurumu;
  
  // JSON verisini string'e dönüştürüyoruz
  String jsonString;
  serializeJson(doc, jsonString);
  
  // HTTP POST isteği oluşturup gönderiyoruz
  HTTPClient http;
  
  http.begin(apiUrl);
  http.addHeader("Content-Type", "application/json");
  
  int httpResponseCode = http.POST(jsonString);
  
  // Yanıtı kontrol ediyoruz
  if (httpResponseCode > 0) {
    String response = http.getString();
    Serial.println("HTTP Yanıt kodu: " + String(httpResponseCode));
    Serial.println(response);
  } else {
    Serial.print("Hata kodu: ");
    Serial.println(httpResponseCode);
  }
  
  http.end();
}

// Serial port'a verileri yazdır
void verileriYazdir() {
  // Tüm verileri ekrana yazdır
  Serial.println("============ SERA DURUM BİLGİLERİ ============");
  
  // Sıcaklık ve Nem Bilgisi
  Serial.print("Sıcaklık: ");
  Serial.print(sicaklik);
  Serial.println(" °C");
  
  Serial.print("Nem: ");
  Serial.print(nem);
  Serial.println(" %");
  
  // Işık Seviyesi
  Serial.print("Işık Seviyesi: ");
  Serial.print(isikSeviyesiYuzde);
  Serial.print(" % (Ham Değer: ");
  Serial.print(isikSeviyesi);
  Serial.println(")");
  
  // Hava Kalitesi ve CO2
  Serial.print("Hava Kalitesi: ");
  Serial.print(havaKalitesiYuzde);
  Serial.print(" % (Ham Değer: ");
  Serial.print(havaKalitesi);
  Serial.println(")");
  
  Serial.print("CO2 Seviyesi: ");
  Serial.print(co2ppm, 0);  // Ondalık basamak olmadan
  Serial.println(" ppm");
  
  Serial.print("Duman/Yangın Durumu: ");
  if (dumanVarMi) {
    Serial.println("DİKKAT! DUMAN ALGILANDI!");
  } else {
    Serial.println("Normal");
  }
  
  // Toprak Nemi (Analog ve Dijital)
  Serial.print("Toprak Nemi: ");
  Serial.print(toprakNemiYuzde);
  Serial.print(" % (Ham Değer: ");
  Serial.print(toprakNemi);
  Serial.println(")");
  
  Serial.print("Toprak Durum: ");
  if (toprakNemlimi) {
    Serial.println("NEMLİ (Sulama Gerekmiyor)");
  } else {
    Serial.println("KURU (Sulama Gerekiyor)");
  }
  
  // Su Seviyesi
  Serial.print("Su Seviyesi: ");
  Serial.print(suSeviyesiYuzde);
  Serial.print(" % (Ham Değer: ");
  Serial.print(suSeviyesi);
  Serial.println(")");
  
  // Röle Durumları
  Serial.print("Fan Durumu: ");
  Serial.println(fanDurumu ? "AÇIK" : "KAPALI");
  
  Serial.print("LED Şerit Durumu: ");
  Serial.println(ledDurumu ? "AÇIK" : "KAPALI");
  
  Serial.print("Su Pompası Durumu: ");
  Serial.println(suPompasiDurumu ? "AÇIK" : "KAPALI");
  
  Serial.println("=============================================");
  Serial.println();
}

void loop() {
  unsigned long simdikiZaman = millis();
  
  // Belirli aralıklarla sensörleri oku ve veri gönder (15 saniyede bir)
  if (simdikiZaman - sonVeriGondermeSuresi >= veriGondermeAraligi) {
    // Sensörleri oku
    sensorleriOku();
    
    // Verileri Serial'e yazdır
    verileriYazdir();
    
    // Fan ve LED kontrolü
    fanKontrol();
    ledKontrol();
    
    // Toprak nemi %20'nin altında ise su pompasını başlat
    if (toprakNemiYuzde < TOPRAK_NEM_ESIK && !suPompasiDurumu) {
      digitalWrite(SU_POMPASI_ROLE_PIN, ROLE_ACIK);
      suPompasiDurumu = true;
      suPompasiBaslangicZamani = simdikiZaman;
      Serial.println("SU POMPASI AÇILDI! Toprak Nemi: " + String(toprakNemiYuzde) + "%");
    }
    
    // Verileri API'ye gönder
    verileriGonder();
    
    // Zaman damgasını güncelle
    sonVeriGondermeSuresi = simdikiZaman;
  }
  
  // Su pompası kontrolü - her döngüde kontrol edilir
  if (suPompasiDurumu && (simdikiZaman - suPompasiBaslangicZamani >= suPompasiCalismaZamani)) {
    digitalWrite(SU_POMPASI_ROLE_PIN, ROLE_KAPALI);
    suPompasiDurumu = false;
    Serial.println("SU POMPASI 2 SANİYE ÇALIŞTIKTAN SONRA KAPATILDI");
  }
  
  // Kısa bir gecikme (programın çok hızlı çalışmaması için)
  delay(100);
}