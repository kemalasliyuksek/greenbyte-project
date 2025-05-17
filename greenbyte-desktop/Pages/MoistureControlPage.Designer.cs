using System.Windows.Forms;

namespace greenByte.Pages
{
    partial class MoistureControlPage
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

            // Mevcut nem seviyesi paneli
            this.panelMoistureLevel = new System.Windows.Forms.Panel();
            this.labelMoistureLevelTitle = new System.Windows.Forms.Label();
            this.panelMoistureGauge = new System.Windows.Forms.Panel();
            this.panelMoistureIndicator = new System.Windows.Forms.Panel();
            this.labelPercentValue = new System.Windows.Forms.Label();
            this.btnManualMoistureControl = new System.Windows.Forms.Button();

            // Nem bildirimleri paneli
            this.panelMoistureNotifications = new System.Windows.Forms.Panel();
            this.labelNotificationsTitle = new System.Windows.Forms.Label();
            this.dataGridNotifications = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Nem sistemi olayları paneli
            this.panelMoistureEvents = new System.Windows.Forms.Panel();
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
            this.panelMoistureLevel.SuspendLayout();
            this.panelMoistureGauge.SuspendLayout();
            this.panelMoistureNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotifications)).BeginInit();
            this.panelMoistureEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEvents)).BeginInit();
            this.SuspendLayout();

            // panelMain
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(15);
            this.panelMain.Size = new System.Drawing.Size(900, 600);
            this.panelMain.TabIndex = 0;

            // panelHeader
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(15, 15);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(870, 40);
            this.panelHeader.TabIndex = 0;

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(320, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Nem Kontrol Paneli";

            // panelMoistureLevel
            this.panelMoistureLevel.BackColor = System.Drawing.Color.White;
            this.panelMoistureLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMoistureLevel.Location = new System.Drawing.Point(15, 65);
            this.panelMoistureLevel.Name = "panelMoistureLevel";
            this.panelMoistureLevel.Size = new System.Drawing.Size(300, 230);
            this.panelMoistureLevel.TabIndex = 1;

            // labelMoistureLevelTitle
            this.labelMoistureLevelTitle.AutoSize = true;
            this.labelMoistureLevelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelMoistureLevelTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelMoistureLevelTitle.Location = new System.Drawing.Point(15, 10);
            this.labelMoistureLevelTitle.Name = "labelMoistureLevelTitle";
            this.labelMoistureLevelTitle.Size = new System.Drawing.Size(160, 21);
            this.labelMoistureLevelTitle.TabIndex = 0;
            this.labelMoistureLevelTitle.Text = "Mevcut Nem Seviyesi";

            // panelMoistureGauge
            this.panelMoistureGauge.BackColor = System.Drawing.Color.FromArgb(255, 248, 230);
            this.panelMoistureGauge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMoistureGauge.Location = new System.Drawing.Point(15, 40);
            this.panelMoistureGauge.Name = "panelMoistureGauge";
            this.panelMoistureGauge.Size = new System.Drawing.Size(270, 130);
            this.panelMoistureGauge.TabIndex = 1;

            // panelMoistureIndicator
            this.panelMoistureIndicator.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.panelMoistureIndicator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMoistureIndicator.Location = new System.Drawing.Point(0, 65);
            this.panelMoistureIndicator.Name = "panelMoistureIndicator";
            this.panelMoistureIndicator.Size = new System.Drawing.Size(268, 65);
            this.panelMoistureIndicator.TabIndex = 0;

            // labelPercentValue
            this.labelPercentValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.labelPercentValue.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.labelPercentValue.Location = new System.Drawing.Point(15, 180);
            this.labelPercentValue.Name = "labelPercentValue";
            this.labelPercentValue.Size = new System.Drawing.Size(270, 45);
            this.labelPercentValue.TabIndex = 2;
            this.labelPercentValue.Text = "45%";
            this.labelPercentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnManualMoistureControl
            this.btnManualMoistureControl.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.btnManualMoistureControl.FlatAppearance.BorderSize = 0;
            this.btnManualMoistureControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManualMoistureControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManualMoistureControl.ForeColor = System.Drawing.Color.White;
            this.btnManualMoistureControl.Location = new System.Drawing.Point(15, 235);
            this.btnManualMoistureControl.Name = "btnManualMoistureControl";
            this.btnManualMoistureControl.Size = new System.Drawing.Size(270, 40);
            this.btnManualMoistureControl.TabIndex = 3;
            this.btnManualMoistureControl.Text = "Manuel Nem Kontrolü";
            this.btnManualMoistureControl.UseVisualStyleBackColor = false;

            // panelMoistureNotifications
            this.panelMoistureNotifications.BackColor = System.Drawing.Color.White;
            this.panelMoistureNotifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMoistureNotifications.Location = new System.Drawing.Point(325, 65);
            this.panelMoistureNotifications.Name = "panelMoistureNotifications";
            this.panelMoistureNotifications.Size = new System.Drawing.Size(560, 215);
            this.panelMoistureNotifications.TabIndex = 2;

            // labelNotificationsTitle
            this.labelNotificationsTitle.AutoSize = true;
            this.labelNotificationsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelNotificationsTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelNotificationsTitle.Location = new System.Drawing.Point(15, 10);
            this.labelNotificationsTitle.Name = "labelNotificationsTitle";
            this.labelNotificationsTitle.Size = new System.Drawing.Size(150, 21);
            this.labelNotificationsTitle.TabIndex = 0;
            this.labelNotificationsTitle.Text = "Nem Bildirimleri";

            // dataGridNotifications
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

            // colDate
            this.colDate.HeaderText = "Tarih/Saat";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 120;

            // colType
            this.colType.HeaderText = "Tip";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 80;

            // colStatus
            this.colStatus.HeaderText = "Durum";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 80;

            // colDetail
            this.colDetail.HeaderText = "Detay";
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            this.colDetail.Width = 250;

            // panelMoistureEvents
            this.panelMoistureEvents.BackColor = System.Drawing.Color.White;
            this.panelMoistureEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMoistureEvents.Location = new System.Drawing.Point(15, 305);
            this.panelMoistureEvents.Name = "panelMoistureEvents";
            this.panelMoistureEvents.Size = new System.Drawing.Size(870, 250);
            this.panelMoistureEvents.TabIndex = 3;

            // labelEventsTitle
            this.labelEventsTitle.AutoSize = true;
            this.labelEventsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelEventsTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelEventsTitle.Location = new System.Drawing.Point(15, 10);
            this.labelEventsTitle.Name = "labelEventsTitle";
            this.labelEventsTitle.Size = new System.Drawing.Size(150, 21);
            this.labelEventsTitle.TabIndex = 0;
            this.labelEventsTitle.Text = "Nem Sistemi Olayları";

            // dataGridEvents
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

            // colEventDate
            this.colEventDate.HeaderText = "Tarih/Saat";
            this.colEventDate.Name = "colEventDate";
            this.colEventDate.ReadOnly = true;
            this.colEventDate.Width = 120;

            // colEventType
            this.colEventType.HeaderText = "Olay Tipi";
            this.colEventType.Name = "colEventType";
            this.colEventType.ReadOnly = true;
            this.colEventType.Width = 150;

            // colEventInitiator
            this.colEventInitiator.HeaderText = "Tetikleyen";
            this.colEventInitiator.Name = "colEventInitiator";
            this.colEventInitiator.ReadOnly = true;
            this.colEventInitiator.Width = 150;

            // colEventStatus
            this.colEventStatus.HeaderText = "Durum";
            this.colEventStatus.Name = "colEventStatus";
            this.colEventStatus.ReadOnly = true;
            this.colEventStatus.Width = 100;

            // colEventResult
            this.colEventResult.HeaderText = "Sonuç";
            this.colEventResult.Name = "colEventResult";
            this.colEventResult.ReadOnly = true;
            this.colEventResult.Width = 320;

            // labelLastUpdate
            this.labelLastUpdate.AutoSize = true;
            this.labelLastUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelLastUpdate.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.labelLastUpdate.Location = new System.Drawing.Point(650, 565);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(240, 15);
            this.labelLastUpdate.TabIndex = 4;
            this.labelLastUpdate.Text = "Son Güncelleme: 09.05.2025 10:15";

            // Assemble controls
            this.panelMoistureGauge.Controls.Add(this.panelMoistureIndicator);
            this.panelMoistureGauge.Dock = DockStyle.None;
            this.panelMoistureLevel.Controls.Add(this.labelMoistureLevelTitle);
            this.panelMoistureLevel.Controls.Add(this.panelMoistureGauge);
            this.panelMoistureLevel.Controls.Add(this.labelPercentValue);
            this.panelMoistureLevel.Controls.Add(this.btnManualMoistureControl);
            this.panelMoistureNotifications.Controls.Add(this.labelNotificationsTitle);
            this.panelMoistureNotifications.Controls.Add(this.dataGridNotifications);
            this.panelMoistureEvents.Controls.Add(this.labelEventsTitle);
            this.panelMoistureEvents.Controls.Add(this.dataGridEvents);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelMoistureLevel);
            this.panelMain.Controls.Add(this.panelMoistureNotifications);
            this.panelMain.Controls.Add(this.panelMoistureEvents);
            this.panelMain.Controls.Add(this.labelLastUpdate);

            // MoistureControlPage
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "MoistureControlPage";
            this.Size = new System.Drawing.Size(900, 600);

            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMoistureLevel.ResumeLayout(false);
            this.panelMoistureLevel.PerformLayout();
            this.panelMoistureGauge.ResumeLayout(false);
            this.panelMoistureNotifications.ResumeLayout(false);
            this.panelMoistureNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotifications)).EndInit();
            this.panelMoistureEvents.ResumeLayout(false);
            this.panelMoistureEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEvents)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;

        private System.Windows.Forms.Panel panelMoistureLevel;
        private System.Windows.Forms.Label labelMoistureLevelTitle;
        private System.Windows.Forms.Panel panelMoistureGauge;
        private System.Windows.Forms.Panel panelMoistureIndicator;
        private System.Windows.Forms.Label labelPercentValue;
        private System.Windows.Forms.Button btnManualMoistureControl;

        private System.Windows.Forms.Panel panelMoistureNotifications;
        private System.Windows.Forms.Label labelNotificationsTitle;
        private System.Windows.Forms.DataGridView dataGridNotifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetail;

        private System.Windows.Forms.Panel panelMoistureEvents;
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
