using System.Windows.Forms;
using System;

namespace greenByte.Pages
{
    partial class LightControlPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Ana panel
            this.panelMain = new System.Windows.Forms.Panel();

            // Başlık paneli
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();

            // Mevcut ışık seviyesi paneli
            this.panelLightLevel = new System.Windows.Forms.Panel();
            this.labelLightLevelTitle = new System.Windows.Forms.Label();
            this.panelLightIndicator = new System.Windows.Forms.Panel();
            this.labelPercentValue = new System.Windows.Forms.Label();
            this.btnLightControl = new System.Windows.Forms.Button();

            // Işık bildirimleri paneli
            this.panelLightNotifications = new System.Windows.Forms.Panel();
            this.labelNotificationsTitle = new System.Windows.Forms.Label();
            this.dataGridNotifications = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Işık sistemi olayları paneli
            this.panelLightEvents = new System.Windows.Forms.Panel();
            this.labelEventsTitle = new System.Windows.Forms.Label();
            this.dataGridEvents = new System.Windows.Forms.DataGridView();
            this.colEventDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventInitiator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventResult = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Son güncelleme bilgisi
            this.labelLastUpdate = new System.Windows.Forms.Label();

            // Designer init
            this.panelMain.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelLightLevel.SuspendLayout();
            this.panelLightIndicator.SuspendLayout();
            this.panelLightNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotifications)).BeginInit();
            this.panelLightEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEvents)).BeginInit();
            this.SuspendLayout();

            // panelMain - Ana panel
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(15);
            this.panelMain.Size = new System.Drawing.Size(900, 600);
            this.panelMain.TabIndex = 0;

            // panelHeader - Başlık paneli
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(15, 15);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(870, 40);
            this.panelHeader.TabIndex = 0;

            // labelTitle - Başlık etiketi
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(300, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Işık Kontrol Paneli";

            // panelLightLevel - Işık seviyesi paneli
            this.panelLightLevel.BackColor = System.Drawing.Color.White;
            this.panelLightLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLightLevel.Location = new System.Drawing.Point(15, 65);
            this.panelLightLevel.Name = "panelLightLevel";
            this.panelLightLevel.Size = new System.Drawing.Size(300, 230);
            this.panelLightLevel.TabIndex = 1;

            // labelLightLevelTitle - Işık seviyesi başlığı
            this.labelLightLevelTitle.AutoSize = true;
            this.labelLightLevelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelLightLevelTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelLightLevelTitle.Location = new System.Drawing.Point(15, 10);
            this.labelLightLevelTitle.Name = "labelLightLevelTitle";
            this.labelLightLevelTitle.Size = new System.Drawing.Size(150, 21);
            this.labelLightLevelTitle.TabIndex = 0;
            this.labelLightLevelTitle.Text = "Mevcut Işık Seviyesi";

            // panelLightIndicator - Işık gösterge paneli
            this.panelLightIndicator.BackColor = System.Drawing.Color.FromArgb(255, 248, 230);
            this.panelLightIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLightIndicator.Location = new System.Drawing.Point(15, 40);
            this.panelLightIndicator.Name = "panelLightIndicator";
            this.panelLightIndicator.Size = new System.Drawing.Size(270, 130);
            this.panelLightIndicator.TabIndex = 1;

            // labelPercentValue - Işık seviyesi değeri (büyük)
            this.labelPercentValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.labelPercentValue.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.labelPercentValue.Location = new System.Drawing.Point(15, 180);
            this.labelPercentValue.Name = "labelPercentValue";
            this.labelPercentValue.Size = new System.Drawing.Size(270, 45);
            this.labelPercentValue.TabIndex = 2;
            this.labelPercentValue.Text = "850 lux";
            this.labelPercentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnLightControl - Işık kontrol butonu
            this.btnLightControl.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.btnLightControl.FlatAppearance.BorderSize = 0;
            this.btnLightControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLightControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLightControl.ForeColor = System.Drawing.Color.White;
            this.btnLightControl.Location = new System.Drawing.Point(15, 235);
            this.btnLightControl.Name = "btnLightControl";
            this.btnLightControl.Size = new System.Drawing.Size(270, 40);
            this.btnLightControl.TabIndex = 3;
            this.btnLightControl.Text = "Manuel Işık Kontrolü";
            this.btnLightControl.UseVisualStyleBackColor = false;

            // panelLightNotifications - Işık bildirimleri paneli
            this.panelLightNotifications.BackColor = System.Drawing.Color.White;
            this.panelLightNotifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLightNotifications.Location = new System.Drawing.Point(325, 65);
            this.panelLightNotifications.Name = "panelLightNotifications";
            this.panelLightNotifications.Size = new System.Drawing.Size(560, 215);
            this.panelLightNotifications.TabIndex = 2;

            // labelNotificationsTitle - Bildirimler başlığı
            this.labelNotificationsTitle.AutoSize = true;
            this.labelNotificationsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelNotificationsTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelNotificationsTitle.Location = new System.Drawing.Point(15, 10);
            this.labelNotificationsTitle.Name = "labelNotificationsTitle";
            this.labelNotificationsTitle.Size = new System.Drawing.Size(150, 21);
            this.labelNotificationsTitle.TabIndex = 0;
            this.labelNotificationsTitle.Text = "Işık Bildirimleri";

            // dataGridNotifications - Bildirimler tablosu
            this.dataGridNotifications.AllowUserToAddRows = false;
            this.dataGridNotifications.AllowUserToDeleteRows = false;
            this.dataGridNotifications.BackgroundColor = System.Drawing.Color.White;
            this.dataGridNotifications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNotifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colType,
            this.colStatus,
            this.colDetail});
            this.dataGridNotifications.Location = new System.Drawing.Point(15, 40);
            this.dataGridNotifications.Name = "dataGridNotifications";
            this.dataGridNotifications.ReadOnly = true;
            this.dataGridNotifications.RowHeadersVisible = false;
            this.dataGridNotifications.Size = new System.Drawing.Size(530, 160);
            this.dataGridNotifications.TabIndex = 1;

            // colDate - Tarih/Saat sütunu
            this.colDate.HeaderText = "Tarih/Saat";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 120;

            // colType - Tip sütunu
            this.colType.HeaderText = "Tip";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 80;

            // colStatus - Durum sütunu
            this.colStatus.HeaderText = "Durum";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 80;

            // colDetail - Detay sütunu
            this.colDetail.HeaderText = "Detay";
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            this.colDetail.Width = 250;

            // panelLightEvents - Işık sistemi olayları paneli
            this.panelLightEvents.BackColor = System.Drawing.Color.White;
            this.panelLightEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLightEvents.Location = new System.Drawing.Point(15, 305);
            this.panelLightEvents.Name = "panelLightEvents";
            this.panelLightEvents.Size = new System.Drawing.Size(870, 250);
            this.panelLightEvents.TabIndex = 3;

            // labelEventsTitle - Olaylar başlığı
            this.labelEventsTitle.AutoSize = true;
            this.labelEventsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelEventsTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelEventsTitle.Location = new System.Drawing.Point(15, 10);
            this.labelEventsTitle.Name = "labelEventsTitle";
            this.labelEventsTitle.Size = new System.Drawing.Size(150, 21);
            this.labelEventsTitle.TabIndex = 0;
            this.labelEventsTitle.Text = "Işık Sistemi Olayları";

            // dataGridEvents - Olaylar tablosu
            this.dataGridEvents.AllowUserToAddRows = false;
            this.dataGridEvents.AllowUserToDeleteRows = false;
            this.dataGridEvents.BackgroundColor = System.Drawing.Color.White;
            this.dataGridEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEventDate,
            this.colEventType,
            this.colEventInitiator,
            this.colEventStatus,
            this.colEventResult});
            this.dataGridEvents.Location = new System.Drawing.Point(15, 40);
            this.dataGridEvents.Name = "dataGridEvents";
            this.dataGridEvents.ReadOnly = true;
            this.dataGridEvents.RowHeadersVisible = false;
            this.dataGridEvents.Size = new System.Drawing.Size(840, 190);
            this.dataGridEvents.TabIndex = 1;

            // colEventDate - Olay tarihi sütunu
            this.colEventDate.HeaderText = "Tarih/Saat";
            this.colEventDate.Name = "colEventDate";
            this.colEventDate.ReadOnly = true;
            this.colEventDate.Width = 120;

            // colEventType - Olay tipi sütunu
            this.colEventType.HeaderText = "Olay Tipi";
            this.colEventType.Name = "colEventType";
            this.colEventType.ReadOnly = true;
            this.colEventType.Width = 150;

            // colEventInitiator - Tetikleyen sütunu
            this.colEventInitiator.HeaderText = "Tetikleyen";
            this.colEventInitiator.Name = "colEventInitiator";
            this.colEventInitiator.ReadOnly = true;
            this.colEventInitiator.Width = 150;

            // colEventStatus - Olay durumu sütunu
            this.colEventStatus.HeaderText = "Durum";
            this.colEventStatus.Name = "colEventStatus";
            this.colEventStatus.ReadOnly = true;
            this.colEventStatus.Width = 100;

            // colEventResult - Sonuç sütunu
            this.colEventResult.HeaderText = "Sonuç";
            this.colEventResult.Name = "colEventResult";
            this.colEventResult.ReadOnly = true;
            this.colEventResult.Width = 320;

            // labelLastUpdate - Son güncelleme bilgisi
            this.labelLastUpdate.AutoSize = true;
            this.labelLastUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelLastUpdate.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.labelLastUpdate.Location = new System.Drawing.Point(650, 565);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(240, 15);
            this.labelLastUpdate.TabIndex = 4;
            this.labelLastUpdate.Text = "Son Güncelleme: 09.05.2025 10:15";

            // Ana kontrol - panellerin birleştirilmesi
            this.panelLightLevel.Controls.Add(this.labelLightLevelTitle);
            this.panelLightLevel.Controls.Add(this.panelLightIndicator);
            this.panelLightLevel.Controls.Add(this.labelPercentValue);
            this.panelLightLevel.Controls.Add(this.btnLightControl);

            this.panelLightNotifications.Controls.Add(this.labelNotificationsTitle);
            this.panelLightNotifications.Controls.Add(this.dataGridNotifications);

            this.panelLightEvents.Controls.Add(this.labelEventsTitle);
            this.panelLightEvents.Controls.Add(this.dataGridEvents);

            this.panelHeader.Controls.Add(this.labelTitle);

            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelLightLevel);
            this.panelMain.Controls.Add(this.panelLightNotifications);
            this.panelMain.Controls.Add(this.panelLightEvents);
            this.panelMain.Controls.Add(this.labelLastUpdate);

            // LightControlPage
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "LightControlPage";
            this.Size = new System.Drawing.Size(900, 600);

            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelLightLevel.ResumeLayout(false);
            this.panelLightLevel.PerformLayout();
            this.panelLightIndicator.ResumeLayout(false);
            this.panelLightNotifications.ResumeLayout(false);
            this.panelLightNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotifications)).EndInit();
            this.panelLightEvents.ResumeLayout(false);
            this.panelLightEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEvents)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;

        private System.Windows.Forms.Panel panelLightLevel;
        private System.Windows.Forms.Label labelLightLevelTitle;
        private System.Windows.Forms.Panel panelLightIndicator;
        private System.Windows.Forms.Label labelPercentValue;
        private System.Windows.Forms.Button btnLightControl;

        private System.Windows.Forms.Panel panelLightNotifications;
        private System.Windows.Forms.Label labelNotificationsTitle;
        private System.Windows.Forms.DataGridView dataGridNotifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetail;

        private System.Windows.Forms.Panel panelLightEvents;
        private System.Windows.Forms.Label labelEventsTitle;
        private System.Windows.Forms.DataGridView dataGridEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventInitiator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventResult;

        private System.Windows.Forms.Label labelLastUpdate;

        // Uygulamaya özel olay işleyicileri için metodlar eklenebilir
        private void btnLightControl_Click(object sender, System.EventArgs e)
        {
            // Manuel ışık kontrol penceresi açılabilir
            System.Windows.Forms.Form lightControlForm = new System.Windows.Forms.Form();
            lightControlForm.Text = "Işık Kontrolü";
            lightControlForm.Size = new System.Drawing.Size(400, 300);
            lightControlForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            lightControlForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            lightControlForm.MaximizeBox = false;
            lightControlForm.MinimizeBox = false;

            // Işık kontrol formu içeriği burada tanımlanabilir

            lightControlForm.ShowDialog();
        }

        // Bildirim ve olay verileriyle tabloları dolduracak metod
        public void LoadTableData()
        {
            // Bildirimleri tabloya ekle
            dataGridNotifications.Rows.Clear();
            dataGridNotifications.Rows.Add("09.05.2025 09:15", "Uyarı", "Yüksek", "Işık seviyesi 950 lux'a çıktı");
            dataGridNotifications.Rows.Add("09.05.2025 06:30", "Bilgi", "Normal", "Sabah ışık programı başladı");
            dataGridNotifications.Rows.Add("08.05.2025 22:15", "Bilgi", "Düşük", "Işıklar kapatıldı (gece modu)");
            dataGridNotifications.Rows.Add("08.05.2025 18:30", "Hata", "Kritik", "Işık sensörü bağlantı hatası");

            // Olayları tabloya ekle
            dataGridEvents.Rows.Clear();
            dataGridEvents.Rows.Add("09.05.2025 09:00", "Işık Ayarı Değişimi", "Zaman Programı", "Tamamlandı", "Işık seviyesi 850 lux'a ayarlandı");
            dataGridEvents.Rows.Add("09.05.2025 06:00", "Işık Aktivasyonu", "Zaman Programı", "Tamamlandı", "Sabah ışık programı aktif edildi");
            dataGridEvents.Rows.Add("08.05.2025 22:00", "Işık Deaktivasyonu", "Zaman Programı", "Tamamlandı", "Işıklar kapatıldı");
            dataGridEvents.Rows.Add("08.05.2025 18:00", "Sensör Problemi", "Sistem", "Çözüldü", "Sensör bağlantısı yeniden kuruldu");
            dataGridEvents.Rows.Add("08.05.2025 16:30", "Parlaklık Ayarı", "Manuel", "Tamamlandı", "Işık parlaklığı %75'e düşürüldü");

            // Görsel stilleri uygula
            FormatTables();

            // Işık göstergesini güncelle
            UpdateLightIndicator(850);
        }

        // Tablolardaki satırları formatlama
        private void FormatTables()
        {
            // Bildirimler tablosunda durum hücreleri için renk ayarları
            foreach (System.Windows.Forms.DataGridViewRow row in dataGridNotifications.Rows)
            {
                string status = row.Cells["colStatus"].Value.ToString();

                if (status == "Düşük")
                {
                    row.Cells["colStatus"].Style.BackColor = System.Drawing.Color.FromArgb(209, 231, 221);
                    row.Cells["colStatus"].Style.ForeColor = System.Drawing.Color.FromArgb(15, 81, 50);
                }
                else if (status == "Normal")
                {
                    row.Cells["colStatus"].Style.BackColor = System.Drawing.Color.FromArgb(209, 231, 221);
                    row.Cells["colStatus"].Style.ForeColor = System.Drawing.Color.FromArgb(15, 81, 50);
                }
                else if (status == "Yüksek")
                {
                    row.Cells["colStatus"].Style.BackColor = System.Drawing.Color.FromArgb(255, 243, 205);
                    row.Cells["colStatus"].Style.ForeColor = System.Drawing.Color.FromArgb(133, 100, 4);
                }
                else if (status == "Kritik")
                {
                    row.Cells["colStatus"].Style.BackColor = System.Drawing.Color.FromArgb(248, 215, 218);
                    row.Cells["colStatus"].Style.ForeColor = System.Drawing.Color.FromArgb(132, 32, 41);
                }
            }

            // Olaylar tablosunda durum hücreleri için renk ayarları
            foreach (System.Windows.Forms.DataGridViewRow row in dataGridEvents.Rows)
            {
                string status = row.Cells["colEventStatus"].Value.ToString();

                if (status == "Tamamlandı")
                {
                    row.Cells["colEventStatus"].Style.BackColor = System.Drawing.Color.FromArgb(209, 231, 221);
                    row.Cells["colEventStatus"].Style.ForeColor = System.Drawing.Color.FromArgb(15, 81, 50);
                }
                else if (status == "İşleniyor")
                {
                    row.Cells["colEventStatus"].Style.BackColor = System.Drawing.Color.FromArgb(255, 243, 205);
                    row.Cells["colEventStatus"].Style.ForeColor = System.Drawing.Color.FromArgb(133, 100, 4);
                }
                else if (status == "Çözüldü")
                {
                    row.Cells["colEventStatus"].Style.BackColor = System.Drawing.Color.FromArgb(207, 226, 255);
                    row.Cells["colEventStatus"].Style.ForeColor = System.Drawing.Color.FromArgb(0, 64, 133);
                }
            }
        }

        // Işık göstergesini güncellemek için metod
        private void UpdateLightIndicator(int luxValue)
        {
            // Lux değerini göster
            labelPercentValue.Text = luxValue.ToString() + " lux";

            // Lux değerine göre gösterge paneli rengini ayarla
            if (luxValue < 200)
            {
                panelLightIndicator.BackColor = System.Drawing.Color.FromArgb(220, 220, 220); // Gri (çok düşük)
            }
            else if (luxValue < 500)
            {
                panelLightIndicator.BackColor = System.Drawing.Color.FromArgb(225, 245, 254); // Açık mavi (düşük)
            }
            else if (luxValue < 800)
            {
                panelLightIndicator.BackColor = System.Drawing.Color.FromArgb(255, 248, 230); // Açık sarı (orta)
            }
            else if (luxValue < 1000)
            {
                panelLightIndicator.BackColor = System.Drawing.Color.FromArgb(255, 236, 179); // Koyu sarı (yüksek)
            }
            else
            {
                panelLightIndicator.BackColor = System.Drawing.Color.FromArgb(255, 224, 178); // Turuncu (çok yüksek)
            }

            // Son güncelleme zamanını güncelle
            labelLastUpdate.Text = "Son Güncelleme: " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        // Işık kontrol formunu oluşturur
        private System.Windows.Forms.Panel CreateLightControlForm(System.Windows.Forms.Form parentForm)
        {
            System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Padding = new System.Windows.Forms.Padding(20);

            // Parlaklık ayarı
            System.Windows.Forms.Label lblBrightness = new System.Windows.Forms.Label();
            lblBrightness.Text = "Parlaklık:";
            lblBrightness.AutoSize = true;
            lblBrightness.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblBrightness.Location = new System.Drawing.Point(20, 20);

            System.Windows.Forms.TrackBar trackBrightness = new System.Windows.Forms.TrackBar();
            trackBrightness.Minimum = 0;
            trackBrightness.Maximum = 100;
            trackBrightness.Value = 85;
            trackBrightness.Width = 350;
            trackBrightness.Location = new System.Drawing.Point(20, 50);

            System.Windows.Forms.Label lblBrightnessValue = new System.Windows.Forms.Label();
            lblBrightnessValue.Text = "85%";
            lblBrightnessValue.AutoSize = true;
            lblBrightnessValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblBrightnessValue.Location = new System.Drawing.Point(360, 50);

            // Açma/kapama butonları
            System.Windows.Forms.Button btnOn = new System.Windows.Forms.Button();
            btnOn.Text = "Işıkları Aç";
            btnOn.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            btnOn.ForeColor = System.Drawing.Color.White;
            btnOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOn.FlatAppearance.BorderSize = 0;
            btnOn.Size = new System.Drawing.Size(150, 40);
            btnOn.Location = new System.Drawing.Point(20, 100);

            System.Windows.Forms.Button btnOff = new System.Windows.Forms.Button();
            btnOff.Text = "Işıkları Kapat";
            btnOff.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            btnOff.ForeColor = System.Drawing.Color.White;
            btnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOff.FlatAppearance.BorderSize = 0;
            btnOff.Size = new System.Drawing.Size(150, 40);
            btnOff.Location = new System.Drawing.Point(180, 100);

            // Mod seçimi
            System.Windows.Forms.Label lblMode = new System.Windows.Forms.Label();
            lblMode.Text = "Işık Modu:";
            lblMode.AutoSize = true;
            lblMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblMode.Location = new System.Drawing.Point(20, 160);

            System.Windows.Forms.ComboBox comboMode = new System.Windows.Forms.ComboBox();
            comboMode.Items.AddRange(new object[] { "Normal", "Gece Modu", "Sabah Modu", "Akşam Modu" });
            comboMode.SelectedIndex = 0;
            comboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboMode.Size = new System.Drawing.Size(150, 25);
            comboMode.Location = new System.Drawing.Point(20, 190);

            // Kaydet butonu
            System.Windows.Forms.Button btnSave = new System.Windows.Forms.Button();
            btnSave.Text = "Kaydet ve Uygula";
            btnSave.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Size = new System.Drawing.Size(150, 40);
            btnSave.Location = new System.Drawing.Point(230, 190);

            // Kontrolleri panele ekle
            panel.Controls.Add(lblBrightness);
            panel.Controls.Add(trackBrightness);
            panel.Controls.Add(lblBrightnessValue);
            panel.Controls.Add(btnOn);
            panel.Controls.Add(btnOff);
            panel.Controls.Add(lblMode);
            panel.Controls.Add(comboMode);
            panel.Controls.Add(btnSave);

            // Olaylar
            trackBrightness.ValueChanged += (s, e) => {
                lblBrightnessValue.Text = trackBrightness.Value + "%";
            };

            btnOn.Click += (s, e) => {
                MessageBox.Show("Işıklar açıldı ve parlaklık %" + trackBrightness.Value + " olarak ayarlandı.",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parentForm.Close();
            };

            btnOff.Click += (s, e) => {
                MessageBox.Show("Işıklar kapatıldı.",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parentForm.Close();
            };

            btnSave.Click += (s, e) => {
                MessageBox.Show("Işık ayarları kaydedildi ve uygulandı:\n\nParlaklık: %" + trackBrightness.Value +
                    "\nMod: " + comboMode.SelectedItem.ToString(),
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parentForm.Close();
            };

            return panel;
        }

        // Örnek ışık durumu verilerini oluşturmak için metod
        private void GenerateSampleData()
        {
            // Burada gerçek sensörlerden veri okuma kodları olabilir
            // Şimdilik örnek veriler kullanıyoruz

            // 24 saatlik lux değerleri
            int[] hourlyLuxValues = {
                0, 0, 0, 0, 0, 0,          // 00:00 - 05:00 (gece)
                200, 400, 650, 800, 850, 900,  // 06:00 - 11:00 (sabah)
                950, 980, 920, 880, 800, 750,  // 12:00 - 17:00 (öğle ve akşamüstü)
                500, 200, 100, 0, 0, 0     // 18:00 - 23:00 (akşam ve gece)
            };

            // Şu anki saate göre ışık seviyesini belirle
            int currentHour = System.DateTime.Now.Hour;
            int currentLux = hourlyLuxValues[currentHour];

            // Görsel güncelleme
            UpdateLightIndicator(currentLux);
        }


    }
}
