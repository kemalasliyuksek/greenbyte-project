// notifications.js - Bildirim işlevlerini yöneten JavaScript
document.addEventListener('DOMContentLoaded', function() {
    console.log("Bildirim scripti yükleniyor...");
    
    // Bildirim elementlerini seç
    const notificationIcon = document.querySelector('.notifications');
    const notificationPanel = document.getElementById('notification-panel');
    const notificationCount = document.querySelector('.notification-count');
    const notificationList = document.querySelector('.notification-list');
    const closeNotificationsButton = document.getElementById('close-notifications');
    
    // Bildirim panelinin açık/kapalı durumunu tutan değişken
    let isPanelOpen = false;
    
    // Bildirim sayısını güncelle
    function updateNotificationCount(count) {
        notificationCount.textContent = count;
        // Eğer bildirim yoksa sayıyı gizle
        if (count === 0) {
            notificationCount.style.display = 'none';
        } else {
            notificationCount.style.display = 'flex';
        }
    }
    
    // Bildirimleri getir ve listele
    function fetchNotifications() {
        console.log("Bildirimler getiriliyor...");
        
        fetch('../api/bildirim_getir.php')
            .then(response => {
                if (!response.ok) {
                    throw new Error('API yanıtı başarısız: ' + response.status);
                }
                return response.json();
            })
            .then(data => {
                console.log("Bildirim verileri:", data);
                
                if (data.durum === 'basarili') {
                    // Bildirim sayısını güncelle
                    updateNotificationCount(data.okunmamis_sayi);
                    
                    // Bildirim listesini temizle
                    notificationList.innerHTML = '';
                    
                    if (data.bildirimler.length === 0) {
                        notificationList.innerHTML = '<div class="no-notifications">Hiç bildiriminiz yok</div>';
                        return;
                    }
                    
                    // Bildirimleri listele
                    data.bildirimler.forEach(bildirim => {
                        // Tarih formatını düzenle
                        const tarih = new Date(bildirim.olusturma_zamani);
                        const formatlanmisTarih = `${tarih.getDate()}.${tarih.getMonth() + 1}.${tarih.getFullYear()} ${tarih.getHours()}:${String(tarih.getMinutes()).padStart(2, '0')}`;
                        
                        // Bildirim tipine göre ikon sınıfı belirleme (default: info)
                        let iconClass = 'info';
                        if (bildirim.tur) {
                            switch (bildirim.tur) {
                                case 'warning':
                                    iconClass = 'warning';
                                    break;
                                case 'error':
                                    iconClass = 'danger';
                                    break;
                                case 'success':
                                    iconClass = 'success';
                                    break;
                            }
                        }
                        
                        // Tüm bildirimleri varsayılan olarak "unread" sınıfı ile oluştur
                        const notificationHTML = `
                            <div class="notification ${iconClass} unread" data-id="${bildirim.id}">
                                <i class="fas ${getIconForType(bildirim.tur)}"></i>
                                <div class="notification-content">
                                    <p><strong>${bildirim.baslik}</strong></p>
                                    <p>${bildirim.mesaj}</p>
                                    <span class="notification-time">${formatlanmisTarih}</span>
                                </div>
                            </div>
                        `;
                        
                        notificationList.innerHTML += notificationHTML;
                    });
                    
                    // Bildirimlere tıklama işlevselligi ekle
                    document.querySelectorAll('.notification').forEach(notification => {
                        notification.addEventListener('click', function() {
                            const bildirimId = this.getAttribute('data-id');
                            markNotificationAsRead(bildirimId, this);
                        });
                    });
                    
                } else {
                    console.error('Bildirim getirme hatası:', data.mesaj);
                    notificationList.innerHTML = '<div class="no-notifications">Bildirimler yüklenirken bir hata oluştu</div>';
                }
            })
            .catch(error => {
                console.error('Bildirim çekme hatası:', error);
                notificationList.innerHTML = '<div class="no-notifications">Bildirimler yüklenirken bir hata oluştu</div>';
            });
    }
    
    // Bildirim türüne göre ikon belirle
    function getIconForType(type) {
        switch (type) {
            case 'warning':
                return 'fa-exclamation-triangle';
            case 'error':
                return 'fa-times-circle';
            case 'success':
                return 'fa-check-circle';
            default:
                return 'fa-info-circle';  // Default type 'info'
        }
    }
    
    // Bildirimi okundu olarak işaretle
    function markNotificationAsRead(notificationId, notificationElement) {
        console.log("Bildirim okundu olarak işaretleniyor, ID:", notificationId);
        
        const formData = new FormData();
        formData.append('bildirim_id', notificationId);
        
        fetch('../api/bildirim_okundu.php', {
            method: 'POST',
            body: formData
        })
        .then(response => response.json())
        .then(data => {
            console.log("Bildirim işaretleme yanıtı:", data);
            
            if (data.durum === 'basarili') {
                // Bildirimi DOM'dan kaldır
                if (notificationElement) {
                    notificationElement.remove();
                }
                
                // Bildirim sayısını güncelle
                const currentCount = parseInt(notificationCount.textContent) || 0;
                updateNotificationCount(Math.max(0, currentCount - 1));
                
                // Eğer liste boş kaldıysa mesaj göster
                if (notificationList.querySelectorAll('.notification').length === 0) {
                    notificationList.innerHTML = '<div class="no-notifications">Hiç bildiriminiz yok</div>';
                }
            } else {
                console.error('Bildirim işaretleme hatası:', data.mesaj);
            }
        })
        .catch(error => {
            console.error('Bildirim işaretleme hatası:', error);
        });
    }
    
    // Bildirim ikonuna tıklama olayını ekle
    if (notificationIcon) {
        notificationIcon.addEventListener('click', function(e) {
            e.stopPropagation(); // Sayfa tıklamalarının bu tıklamayı etkilememesi için
            
            if (!isPanelOpen) {
                fetchNotifications(); // Bildirimleri getir
                notificationPanel.style.display = 'block';
                
                setTimeout(() => {
                    notificationPanel.style.opacity = '1';
                    notificationPanel.style.transform = 'translateY(0)';
                }, 10);
                isPanelOpen = true;
            } else {
                closeNotificationPanel();
            }
        });
    }
    
    // Paneli kapatma işlevi
    function closeNotificationPanel() {
        notificationPanel.style.opacity = '0';
        notificationPanel.style.transform = 'translateY(-20px)';
        setTimeout(() => {
            notificationPanel.style.display = 'none';
        }, 300);
        isPanelOpen = false;
    }
    
    // Kapatma butonuna tıklama
    if (closeNotificationsButton) {
        closeNotificationsButton.addEventListener('click', function() {
            closeNotificationPanel();
        });
    }
    
    // Sayfa yüklendiğinde bildirimleri getir - burada sadece bildirim sayısını göstermek için çağırıyoruz
    fetch('../api/bildirim_getir.php')
        .then(response => response.json())
        .then(data => {
            if (data.durum === 'basarili') {
                updateNotificationCount(data.okunmamis_sayi);
            }
        })
        .catch(error => {
            console.error('Başlangıçta bildirim sayısı alınamadı:', error);
        });
    
    // Sayfa tıklamalarına tepki ver - panel dışına tıklandığında kapat
    document.addEventListener('click', function(e) {
        if (isPanelOpen && notificationPanel && !notificationPanel.contains(e.target) && !notificationIcon.contains(e.target)) {
            closeNotificationPanel();
        }
    });
    
    // Her 30 saniyede bir bildirim sayısını güncelle
    setInterval(() => {
        fetch('../api/bildirim_getir.php')
            .then(response => response.json())
            .then(data => {
                if (data.durum === 'basarili') {
                    updateNotificationCount(data.okunmamis_sayi);
                    
                    // Açık panel varsa içeriğini de güncelle
                    if (isPanelOpen) {
                        fetchNotifications();
                    }
                }
            })
            .catch(error => {
                console.error('Bildirim sayısı güncellenirken hata:', error);
            });
    }, 30000);
});