using System.Windows.Forms;

namespace greenByte.Pages
{
    partial class WaterControlPage
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

            // Mevcut su seviyesi paneli
            this.panelWaterLevel = new System.Windows.Forms.Panel();
            this.labelWaterLevelTitle = new System.Windows.Forms.Label();
            this.panelWaterGauge = new System.Windows.Forms.Panel();
            this.panelWaterIndicator = new System.Windows.Forms.Panel();
            this.labelPercent = new System.Windows.Forms.Label();
            this.labelPercentValue = new System.Windows.Forms.Label();
            this.btnManualFill = new System.Windows.Forms.Button();

            // Su bildirimleri paneli
            this.panelWaterNotifications = new System.Windows.Forms.Panel();
            this.labelNotificationsTitle = new System.Windows.Forms.Label();
            this.dataGridNotifications = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Su sistemi olayları paneli
            this.panelWaterEvents = new System.Windows.Forms.Panel();
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
            this.panelWaterLevel.SuspendLayout();
            this.panelWaterGauge.SuspendLayout();
            this.panelWaterNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotifications)).BeginInit();
            this.panelWaterEvents.SuspendLayout();
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
            this.labelTitle.Text = "Su Deposu Kontrol Paneli";

            // panelWaterLevel - Su seviyesi paneli
            this.panelWaterLevel.BackColor = System.Drawing.Color.White;
            this.panelWaterLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWaterLevel.Location = new System.Drawing.Point(15, 65);
            this.panelWaterLevel.Name = "panelWaterLevel";
            this.panelWaterLevel.Size = new System.Drawing.Size(300, 230);
            this.panelWaterLevel.TabIndex = 1;

            // labelWaterLevelTitle - Su seviyesi başlığı
            this.labelWaterLevelTitle.AutoSize = true;
            this.labelWaterLevelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelWaterLevelTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelWaterLevelTitle.Location = new System.Drawing.Point(15, 10);
            this.labelWaterLevelTitle.Name = "labelWaterLevelTitle";
            this.labelWaterLevelTitle.Size = new System.Drawing.Size(150, 21);
            this.labelWaterLevelTitle.TabIndex = 0;
            this.labelWaterLevelTitle.Text = "Mevcut Su Seviyesi";

            // panelWaterGauge - Su göstergesi paneli
            this.panelWaterGauge.BackColor = System.Drawing.Color.FromArgb(240, 249, 255);
            this.panelWaterGauge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWaterGauge.Location = new System.Drawing.Point(15, 40);
            this.panelWaterGauge.Name = "panelWaterGauge";
            this.panelWaterGauge.Size = new System.Drawing.Size(270, 130);
            this.panelWaterGauge.TabIndex = 1;

            // panelWaterIndicator - Su gösterge doluluk paneli
            this.panelWaterIndicator.BackColor = System.Drawing.Color.FromArgb(37, 116, 234);
            this.panelWaterIndicator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelWaterIndicator.Location = new System.Drawing.Point(0, 43);
            this.panelWaterIndicator.Name = "panelWaterIndicator";
            this.panelWaterIndicator.Size = new System.Drawing.Size(268, 85);
            this.panelWaterIndicator.TabIndex = 0;

            // labelPercent - Yüzde etiketi
            this.labelPercent.AutoSize = true;
            this.labelPercent.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.labelPercent.ForeColor = System.Drawing.Color.FromArgb(64, 64, 164);
            this.labelPercent.Location = new System.Drawing.Point(120, 10);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(40, 17);
            this.labelPercent.TabIndex = 1;
            this.labelPercent.Text = "%67";

            // labelPercentValue - Su seviyesi değeri (büyük)
            this.labelPercentValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.labelPercentValue.ForeColor = System.Drawing.Color.FromArgb(37, 116, 234);
            this.labelPercentValue.Location = new System.Drawing.Point(15, 180);
            this.labelPercentValue.Name = "labelPercentValue";
            this.labelPercentValue.Size = new System.Drawing.Size(270, 45);
            this.labelPercentValue.TabIndex = 2;
            this.labelPercentValue.Text = "67%";
            this.labelPercentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnManualFill - Manuel su doldurma butonu
            this.btnManualFill.BackColor = System.Drawing.Color.FromArgb(37, 116, 234);
            this.btnManualFill.FlatAppearance.BorderSize = 0;
            this.btnManualFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManualFill.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManualFill.ForeColor = System.Drawing.Color.White;
            this.btnManualFill.Location = new System.Drawing.Point(15, 235);
            this.btnManualFill.Name = "btnManualFill";
            this.btnManualFill.Size = new System.Drawing.Size(270, 40);
            this.btnManualFill.TabIndex = 3;
            this.btnManualFill.Text = "Manuel Su Doldurma";
            this.btnManualFill.UseVisualStyleBackColor = false;

            // panelWaterNotifications - Su bildirimleri paneli
            this.panelWaterNotifications.BackColor = System.Drawing.Color.White;
            this.panelWaterNotifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWaterNotifications.Location = new System.Drawing.Point(325, 65);
            this.panelWaterNotifications.Name = "panelWaterNotifications";
            this.panelWaterNotifications.Size = new System.Drawing.Size(560, 215);
            this.panelWaterNotifications.TabIndex = 2;

            // labelNotificationsTitle - Bildirimler başlığı
            this.labelNotificationsTitle.AutoSize = true;
            this.labelNotificationsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelNotificationsTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelNotificationsTitle.Location = new System.Drawing.Point(15, 10);
            this.labelNotificationsTitle.Name = "labelNotificationsTitle";
            this.labelNotificationsTitle.Size = new System.Drawing.Size(150, 21);
            this.labelNotificationsTitle.TabIndex = 0;
            this.labelNotificationsTitle.Text = "Su Bildirimleri";

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

            // panelWaterEvents - Su sistemi olayları paneli
            this.panelWaterEvents.BackColor = System.Drawing.Color.White;
            this.panelWaterEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWaterEvents.Location = new System.Drawing.Point(15, 305);
            this.panelWaterEvents.Name = "panelWaterEvents";
            this.panelWaterEvents.Size = new System.Drawing.Size(870, 250);
            this.panelWaterEvents.TabIndex = 3;

            // labelEventsTitle - Olaylar başlığı
            this.labelEventsTitle.AutoSize = true;
            this.labelEventsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelEventsTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelEventsTitle.Location = new System.Drawing.Point(15, 10);
            this.labelEventsTitle.Name = "labelEventsTitle";
            this.labelEventsTitle.Size = new System.Drawing.Size(150, 21);
            this.labelEventsTitle.TabIndex = 0;
            this.labelEventsTitle.Text = "Su Sistemi Olayları";

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
            this.panelWaterGauge.Controls.Add(this.panelWaterIndicator);
            this.panelWaterGauge.Controls.Add(this.labelPercent);

            this.panelWaterLevel.Controls.Add(this.labelWaterLevelTitle);
            this.panelWaterLevel.Controls.Add(this.panelWaterGauge);
            this.panelWaterLevel.Controls.Add(this.labelPercentValue);
            this.panelWaterLevel.Controls.Add(this.btnManualFill);

            this.panelWaterNotifications.Controls.Add(this.labelNotificationsTitle);
            this.panelWaterNotifications.Controls.Add(this.dataGridNotifications);

            this.panelWaterEvents.Controls.Add(this.labelEventsTitle);
            this.panelWaterEvents.Controls.Add(this.dataGridEvents);

            this.panelHeader.Controls.Add(this.labelTitle);

            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelWaterLevel);
            this.panelMain.Controls.Add(this.panelWaterNotifications);
            this.panelMain.Controls.Add(this.panelWaterEvents);
            this.panelMain.Controls.Add(this.labelLastUpdate);

            // WaterTankPage
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "WaterTankPage";
            this.Size = new System.Drawing.Size(900, 600);

            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelWaterLevel.ResumeLayout(false);
            this.panelWaterLevel.PerformLayout();
            this.panelWaterGauge.ResumeLayout(false);
            this.panelWaterGauge.PerformLayout();
            this.panelWaterNotifications.ResumeLayout(false);
            this.panelWaterNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotifications)).EndInit();
            this.panelWaterEvents.ResumeLayout(false);
            this.panelWaterEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEvents)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;

        private System.Windows.Forms.Panel panelWaterLevel;
        private System.Windows.Forms.Label labelWaterLevelTitle;
        private System.Windows.Forms.Panel panelWaterGauge;
        private System.Windows.Forms.Panel panelWaterIndicator;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Label labelPercentValue;
        private System.Windows.Forms.Button btnManualFill;

        private System.Windows.Forms.Panel panelWaterNotifications;
        private System.Windows.Forms.Label labelNotificationsTitle;
        private System.Windows.Forms.DataGridView dataGridNotifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetail;

        private System.Windows.Forms.Panel panelWaterEvents;
        private System.Windows.Forms.Label labelEventsTitle;
        private System.Windows.Forms.DataGridView dataGridEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventInitiator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventResult;

        private System.Windows.Forms.Label labelLastUpdate;

        // Uygulamaya özel olay işleyicileri için metodlar eklenebilir
        private void btnManualFill_Click(object sender, System.EventArgs e)
        {
            // Manuel su doldurma işlemi burada uygulanabilir
        }

        // Bildirim ve olay verileriyle tabloları dolduracak metod
        private void LoadTableData()
        {
            // Bildirimleri tabloya ekle
            dataGridNotifications.Rows.Clear();
            dataGridNotifications.Rows.Add("09.05.2025 08:45", "Uyarı", "Düşük", "Su seviyesi %50'nin altına düştü");
            dataGridNotifications.Rows.Add("09.05.2025 07:30", "Bilgi", "Normal", "Otomatik sulama zamanı");
            dataGridNotifications.Rows.Add("09.05.2025 06:15", "Hata", "Kritik", "Pompa basınç sensörü hatası");
            dataGridNotifications.Rows.Add("09.05.2025 00:10", "Bilgi", "Normal", "Su seviyesi optimal (%67)");

            // Olayları tabloya ekle
            dataGridEvents.Rows.Clear();
            dataGridEvents.Rows.Add("09.05.2025 08:48", "Su Pompası Çalıştırma", "Düşük Su Seviyesi", "Tamamlandı", "Su seviyesi %67'ye yükseltildi");
            dataGridEvents.Rows.Add("09.05.2025 07:32", "Sulama Başlatma", "Zaman Planı", "Tamamlandı", "5 dakika sulama gerçekleşti");
            dataGridEvents.Rows.Add("09.05.2025 06:18", "Pompa Bakım Modu", "Pompa Hatası", "İşleniyor", "Sistem teşhisi çalışıyor");
            dataGridEvents.Rows.Add("09.05.2025 00:15", "Sistem Kontrolü", "Otomatik", "Tamamlandı", "Tüm parametreler normal");
            dataGridEvents.Rows.Add("08.05.2025 22:30", "Su Doldurma", "Manuel", "Tamamlandı", "Depo manuel olarak dolduruldu");

            // Görsel stilleri uygula
            FormatTables();
        }

        // Tablolardaki satırları formatlama
        private void FormatTables()
        {
            // Bildirimler tablosunda durum hücreleri için renk ayarları
            foreach (DataGridViewRow row in dataGridNotifications.Rows)
            {
                string status = row.Cells["colStatus"].Value.ToString();

                if (status == "Düşük")
                {
                    row.Cells["colStatus"].Style.BackColor = System.Drawing.Color.FromArgb(255, 243, 205);
                    row.Cells["colStatus"].Style.ForeColor = System.Drawing.Color.FromArgb(133, 100, 4);
                }
                else if (status == "Normal")
                {
                    row.Cells["colStatus"].Style.BackColor = System.Drawing.Color.FromArgb(209, 231, 221);
                    row.Cells["colStatus"].Style.ForeColor = System.Drawing.Color.FromArgb(15, 81, 50);
                }
                else if (status == "Kritik")
                {
                    row.Cells["colStatus"].Style.BackColor = System.Drawing.Color.FromArgb(248, 215, 218);
                    row.Cells["colStatus"].Style.ForeColor = System.Drawing.Color.FromArgb(132, 32, 41);
                }
            }

            // Olaylar tablosunda durum hücreleri için renk ayarları
            foreach (DataGridViewRow row in dataGridEvents.Rows)
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
            }
        }


    }
}
