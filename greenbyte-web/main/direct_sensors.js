// Grafik nesneleri
let temperatureChart = null;
let humidityChart = null;

// Sıcaklık ve nem için veri yapıları
const temperatureData = {
    labels: [],
    datasets: [{
        label: 'Sıcaklık (°C)',
        data: [],
        borderColor: '#4caf50',
        backgroundColor: 'rgba(76, 175, 80, 0.1)',
        borderWidth: 2,
        pointRadius: 3,
        pointBackgroundColor: '#2e7d32',
        tension: 0.4,
        fill: true
    }]
};

const humidityData = {
    labels: [],
    datasets: [{
        label: 'Nem (%)',
        data: [],
        borderColor: '#1976d2',
        backgroundColor: 'rgba(25, 118, 210, 0.1)',
        borderWidth: 2,
        pointRadius: 3,
        pointBackgroundColor: '#0d47a1',
        tension: 0.4,
        fill: true
    }]
};

const chartOptions = {
    responsive: true,
    maintainAspectRatio: false,
    animation: {
        duration: 800,
        easing: 'easeOutQuart'
    },
    scales: {
        y: {
            beginAtZero: true,
            grid: { color: 'rgba(0, 0, 0, 0.05)' }
        },
        x: {
            grid: { display: false }
        }
    },
    plugins: {
        legend: { display: false },
        tooltip: {
            backgroundColor: 'rgba(0, 0, 0, 0.7)',
            padding: 10,
            titleFont: { size: 14 },
            bodyFont: { size: 13 },
            displayColors: false
        }
    }
};

// Verileri getir ve HTML'e aktar
function fetchSensorData() {
    fetch('get_sensor_data.php')
        .then(res => res.json())
        .then(data => {
            console.log("Gelen sensör verisi:", data);

            updateValue('temperature-value', data.sicaklik, '°C');
            updateValue('current-temperature', data.sicaklik, '°C');

            updateValue('humidity-value', data.nem, '%');
            updateValue('current-humidity', data.nem, '%');

            updateValue('light-value', data.isik_seviyesi, '%');
            updateValue('current-light', data.isik_seviyesi, '%');

            updateValue('soil-moisture-value', data.toprak_nemi, '%');
            updateValue('soil-gauge-value', data.toprak_nemi, '%');
            if (data.toprak_nemi !== undefined && data.toprak_nemi !== "--") {
                document.querySelector('#soil-gauge .gauge-value').style.height = `${data.toprak_nemi}%`;
            }

            updateValue('co2-value', data.co2, ' ppm');
            updateValue('current-co2', data.co2, ' ppm');

            updateValue('water-level-value', data.su_seviyesi, '%');
            updateValue('water-percentage', data.su_seviyesi, '%');
            if (data.su_seviyesi !== undefined && data.su_seviyesi !== "--") {
                document.querySelector('.water-level').style.height = `${data.su_seviyesi}%`;
            }

            if (data.son_guncelleme) {
                document.querySelector('#last-update strong').textContent = data.son_guncelleme;
            }

            if (data.hava_durumu) {
                updateValue('weather-temp', data.hava_durumu.sicaklik, '°C');
                updateValue('weather-location', data.hava_durumu.yer);
            }

            if (data.isik_detay) {
                updateValueWithQuery('#light-panel .light-info .light-detail:nth-child(1) strong', data.isik_detay.gun_isigi);
                updateValueWithQuery('#light-panel .light-info .light-detail:nth-child(2) strong', data.isik_detay.isik_suresi);
            }

            if (data.su_deposu) {
                updateValueWithQuery('#water-panel .panel-data .detail-item:nth-child(1) strong', data.su_deposu.hacim + ' L');
                updateValueWithQuery('#water-panel .panel-data .detail-item:nth-child(2) strong', data.su_deposu.kapasite + ' L');
                updateValueWithQuery('#water-panel .panel-data .detail-item:nth-child(3) strong', data.su_deposu.yeterlilik + ' gün');
            }

            if (data.co2_detay) {
                updateValueWithQuery('#co2-panel .co2-info .co2-detail:nth-child(1) strong', data.co2_detay.optimal_aralik);
                updateValueWithQuery('#co2-panel .co2-info .co2-detail:nth-child(2) strong', data.co2_detay.hava_kalitesi);

                const dumanElem = document.querySelector('#co2-panel .co2-info .co2-detail:nth-child(3) strong');
                dumanElem.textContent = data.co2_detay.duman;
                dumanElem.className = (data.co2_detay.duman === 'Algılandı') ? 'danger' : 'normal';
            }

            // Grafik verileri
            updateChartData(data);
        })
        .catch(err => {
            console.error("Veri alma hatası:", err);
        });
}

// Değerleri güncellemek için yardımcı fonksiyonlar
function updateValue(id, value, unit = '') {
    if (value !== undefined && value !== "--" && document.getElementById(id)) {
        document.getElementById(id).textContent = value + unit;
    }
}

function updateValueWithQuery(selector, value) {
    if (value !== undefined && value !== "--") {
        const el = document.querySelector(selector);
        if (el) el.textContent = value;
    }
}

// Grafik verilerini işleme
function updateChartData(data) {
    if (data.sicaklik_tarihce && temperatureChart) {
        temperatureData.labels = data.sicaklik_tarihce.map(x => x.zaman);
        temperatureData.datasets[0].data = data.sicaklik_tarihce.map(x => x.deger);
        temperatureChart.update();
        updateStats('#temperature-panel', data.sicaklik_min, data.sicaklik_max, data.sicaklik_avg);
    }

    if (data.nem_tarihce && humidityChart) {
        humidityData.labels = data.nem_tarihce.map(x => x.zaman);
        humidityData.datasets[0].data = data.nem_tarihce.map(x => x.deger);
        humidityChart.update();
        updateStats('#humidity-panel', data.nem_min, data.nem_max, data.nem_avg);
    }
}

// Panel istatistiklerini güncelle
function updateStats(panelSelector, min, max, avg) {
    const items = document.querySelectorAll(`${panelSelector} .reading-details .detail-item strong`);
    if (items.length >= 3) {
        if (min) items[0].textContent = min;
        if (max) items[1].textContent = max;
        if (avg) items[2].textContent = avg;
    }
}

// Grafik başlat
function initCharts() {
    const tempCtx = document.getElementById('temperature-chart').getContext('2d');
    temperatureChart = new Chart(tempCtx, {
        type: 'line',
        data: temperatureData,
        options: {
            ...chartOptions,
            scales: {
                ...chartOptions.scales,
                y: {
                    ...chartOptions.scales.y,
                    title: {
                        display: true,
                        text: 'Sıcaklık (°C)'
                    }
                }
            }
        }
    });

    const humCtx = document.getElementById('humidity-chart').getContext('2d');
    humidityChart = new Chart(humCtx, {
        type: 'line',
        data: humidityData,
        options: {
            ...chartOptions,
            scales: {
                ...chartOptions.scales,
                y: {
                    ...chartOptions.scales.y,
                    title: {
                        display: true,
                        text: 'Nem (%)'
                    }
                }
            }
        }
    });
}

// Başlat
document.addEventListener('DOMContentLoaded', () => {
    initCharts();
    fetchSensorData();
    setInterval(fetchSensorData, 30000); // Her 30 saniyede bir güncelle
});
