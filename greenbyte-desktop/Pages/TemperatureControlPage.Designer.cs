namespace greenByte.Pages
{
    partial class TemperatureControlPage
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

            // Mevcut sıcaklık paneli
            this.panelTemperature = new System.Windows.Forms.Panel();
            this.labelTemperatureTitle = new System.Windows.Forms.Label();
            this.panelTemperatureIndicator = new System.Windows.Forms.Panel();
            this.labelTemperatureValue = new System.Windows.Forms.Label();
            this.btnTemperatureControl = new System.Windows.Forms.Button();

            // Sıcaklık bildirimleri paneli
            this.panelTemperatureNotifications = new System.Windows.Forms.Panel();
            this.labelNotificationsTitle = new System.Windows.Forms.Label();
            this.dataGridNotifications = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Sıcaklık sistemi olayları paneli
            this.panelTemperatureEvents = new System.Windows.Forms.Panel();
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
            this.panelTemperature.SuspendLayout();
            this.panelTemperatureNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotifications)).BeginInit();
            this.panelTemperatureEvents.SuspendLayout();
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
            this.labelTitle.Text = "Sıcaklık Kontrol Paneli";

            // panelTemperature - Sıcaklık paneli
            this.panelTemperature.BackColor = System.Drawing.Color.White;
            this.panelTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTemperature.Location = new System.Drawing.Point(15, 65);
            this.panelTemperature.Name = "panelTemperature";
            this.panelTemperature.Size = new System.Drawing.Size(300, 230);
            this.panelTemperature.TabIndex = 1;

            // labelTemperatureTitle - Sıcaklık başlığı
            this.labelTemperatureTitle.AutoSize = true;
            this.labelTemperatureTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTemperatureTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelTemperatureTitle.Location = new System.Drawing.Point(15, 10);
            this.labelTemperatureTitle.Name = "labelTemperatureTitle";
            this.labelTemperatureTitle.Size = new System.Drawing.Size(150, 21);
            this.labelTemperatureTitle.TabIndex = 0;
            this.labelTemperatureTitle.Text = "Mevcut Sıcaklık";

            // panelTemperatureIndicator - Sıcaklık gösterge paneli
            this.panelTemperatureIndicator.BackColor = System.Drawing.Color.FromArgb(255, 235, 230);
            this.panelTemperatureIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTemperatureIndicator.Location = new System.Drawing.Point(15, 40);
            this.panelTemperatureIndicator.Name = "panelTemperatureIndicator";
            this.panelTemperatureIndicator.Size = new System.Drawing.Size(270, 130);
            this.panelTemperatureIndicator.TabIndex = 1;

            // labelTemperatureValue - Sıcaklık değeri (büyük)
            this.labelTemperatureValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.labelTemperatureValue.ForeColor = System.Drawing.Color.FromArgb(211, 47, 47);
            this.labelTemperatureValue.Location = new System.Drawing.Point(15, 180);
            this.labelTemperatureValue.Name = "labelTemperatureValue";
            this.labelTemperatureValue.Size = new System.Drawing.Size(270, 45);
            this.labelTemperatureValue.TabIndex = 2;
            this.labelTemperatureValue.Text = "24.5 °C";
            this.labelTemperatureValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnTemperatureControl - Sıcaklık kontrol butonu
            this.btnTemperatureControl.BackColor = System.Drawing.Color.FromArgb(211, 47, 47);
            this.btnTemperatureControl.FlatAppearance.BorderSize = 0;
            this.btnTemperatureControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemperatureControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTemperatureControl.ForeColor = System.Drawing.Color.White;
            this.btnTemperatureControl.Location = new System.Drawing.Point(15, 235);
            this.btnTemperatureControl.Name = "btnTemperatureControl";
            this.btnTemperatureControl.Size = new System.Drawing.Size(270, 40);
            this.btnTemperatureControl.TabIndex = 3;
            this.btnTemperatureControl.Text = "Manuel Sıcaklık Kontrolü";
            this.btnTemperatureControl.UseVisualStyleBackColor = false;

            // panelTemperatureNotifications - Sıcaklık bildirimleri paneli
            this.panelTemperatureNotifications.BackColor = System.Drawing.Color.White;
            this.panelTemperatureNotifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTemperatureNotifications.Location = new System.Drawing.Point(325, 65);
            this.panelTemperatureNotifications.Name = "panelTemperatureNotifications";
            this.panelTemperatureNotifications.Size = new System.Drawing.Size(560, 215);
            this.panelTemperatureNotifications.TabIndex = 2;

            // labelNotificationsTitle - Bildirimler başlığı
            this.labelNotificationsTitle.AutoSize = true;
            this.labelNotificationsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelNotificationsTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelNotificationsTitle.Location = new System.Drawing.Point(15, 10);
            this.labelNotificationsTitle.Name = "labelNotificationsTitle";
            this.labelNotificationsTitle.Size = new System.Drawing.Size(150, 21);
            this.labelNotificationsTitle.TabIndex = 0;
            this.labelNotificationsTitle.Text = "Sıcaklık Bildirimleri";

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

            // panelTemperatureEvents - Sıcaklık sistemi olayları paneli
            this.panelTemperatureEvents.BackColor = System.Drawing.Color.White;
            this.panelTemperatureEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTemperatureEvents.Location = new System.Drawing.Point(15, 305);
            this.panelTemperatureEvents.Name = "panelTemperatureEvents";
            this.panelTemperatureEvents.Size = new System.Drawing.Size(870, 250);
            this.panelTemperatureEvents.TabIndex = 3;

            // labelEventsTitle - Olaylar başlığı
            this.labelEventsTitle.AutoSize = true;
            this.labelEventsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelEventsTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelEventsTitle.Location = new System.Drawing.Point(15, 10);
            this.labelEventsTitle.Name = "labelEventsTitle";
            this.labelEventsTitle.Size = new System.Drawing.Size(150, 21);
            this.labelEventsTitle.TabIndex = 0;
            this.labelEventsTitle.Text = "Sıcaklık Sistemi Olayları";

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
            this.panelTemperature.Controls.Add(this.labelTemperatureTitle);
            this.panelTemperature.Controls.Add(this.panelTemperatureIndicator);
            this.panelTemperature.Controls.Add(this.labelTemperatureValue);
            this.panelTemperature.Controls.Add(this.btnTemperatureControl);

            this.panelTemperatureNotifications.Controls.Add(this.labelNotificationsTitle);
            this.panelTemperatureNotifications.Controls.Add(this.dataGridNotifications);

            this.panelTemperatureEvents.Controls.Add(this.labelEventsTitle);
            this.panelTemperatureEvents.Controls.Add(this.dataGridEvents);

            this.panelHeader.Controls.Add(this.labelTitle);

            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelTemperature);
            this.panelMain.Controls.Add(this.panelTemperatureNotifications);
            this.panelMain.Controls.Add(this.panelTemperatureEvents);
            this.panelMain.Controls.Add(this.labelLastUpdate);

            // TemperatureControlPage
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "TemperatureControlPage";
            this.Size = new System.Drawing.Size(900, 600);

            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelTemperature.ResumeLayout(false);
            this.panelTemperature.PerformLayout();
            this.panelTemperatureNotifications.ResumeLayout(false);
            this.panelTemperatureNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotifications)).EndInit();
            this.panelTemperatureEvents.ResumeLayout(false);
            this.panelTemperatureEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEvents)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;

        private System.Windows.Forms.Panel panelTemperature;
        private System.Windows.Forms.Label labelTemperatureTitle;
        private System.Windows.Forms.Panel panelTemperatureIndicator;
        private System.Windows.Forms.Label labelTemperatureValue;
        private System.Windows.Forms.Button btnTemperatureControl;

        private System.Windows.Forms.Panel panelTemperatureNotifications;
        private System.Windows.Forms.Label labelNotificationsTitle;
        private System.Windows.Forms.DataGridView dataGridNotifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetail;

        private System.Windows.Forms.Panel panelTemperatureEvents;
        private System.Windows.Forms.Label labelEventsTitle;
        private System.Windows.Forms.DataGridView dataGridEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventInitiator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventResult;

        private System.Windows.Forms.Label labelLastUpdate;
    }
}
