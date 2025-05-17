namespace greenByte.Pages
{
    partial class DataControlPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewDatas = new System.Windows.Forms.DataGridView();
            this.labelBaslik = new System.Windows.Forms.Label();
            this.panelButonlar = new System.Windows.Forms.Panel();
            this.dateTimePickerDatas = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSensorType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatas)).BeginInit();
            this.panelButonlar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewDatas);
            this.panel1.Controls.Add(this.labelBaslik);
            this.panel1.Controls.Add(this.panelButonlar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.panel1.Size = new System.Drawing.Size(1200, 738);
            this.panel1.TabIndex = 1;
            // 
            // dataGridViewDatas
            // 
            this.dataGridViewDatas.AllowUserToAddRows = false;
            this.dataGridViewDatas.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewDatas.ColumnHeadersHeight = 29;
            this.dataGridViewDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDatas.Location = new System.Drawing.Point(20, 67);
            this.dataGridViewDatas.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewDatas.MultiSelect = false;
            this.dataGridViewDatas.Name = "dataGridViewDatas";
            this.dataGridViewDatas.ReadOnly = true;
            this.dataGridViewDatas.RowHeadersWidth = 51;
            this.dataGridViewDatas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDatas.Size = new System.Drawing.Size(1160, 591);
            this.dataGridViewDatas.TabIndex = 4;
            // 
            // labelBaslik
            // 
            this.labelBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelBaslik.Location = new System.Drawing.Point(20, 18);
            this.labelBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBaslik.Name = "labelBaslik";
            this.labelBaslik.Size = new System.Drawing.Size(1160, 49);
            this.labelBaslik.TabIndex = 3;
            this.labelBaslik.Text = "Geçmiş Veri Ölçümleri";
            // 
            // panelButonlar
            // 
            this.panelButonlar.Controls.Add(this.dateTimePickerDatas);
            this.panelButonlar.Controls.Add(this.label2);
            this.panelButonlar.Controls.Add(this.label1);
            this.panelButonlar.Controls.Add(this.comboBoxSensorType);
            this.panelButonlar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButonlar.Location = new System.Drawing.Point(20, 658);
            this.panelButonlar.Margin = new System.Windows.Forms.Padding(4);
            this.panelButonlar.Name = "panelButonlar";
            this.panelButonlar.Size = new System.Drawing.Size(1160, 62);
            this.panelButonlar.TabIndex = 5;
            // 
            // dateTimePickerDatas
            // 
            this.dateTimePickerDatas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerDatas.Location = new System.Drawing.Point(421, 16);
            this.dateTimePickerDatas.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerDatas.Name = "dateTimePickerDatas";
            this.dateTimePickerDatas.Size = new System.Drawing.Size(159, 29);
            this.dateTimePickerDatas.TabIndex = 7;
            this.dateTimePickerDatas.ValueChanged += new System.EventHandler(this.dateTimePickerDatas_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(322, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tarih Seçin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sensör Seçin";
            // 
            // comboBoxSensorType
            // 
            this.comboBoxSensorType.FormattingEnabled = true;
            this.comboBoxSensorType.Location = new System.Drawing.Point(147, 21);
            this.comboBoxSensorType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSensorType.Name = "comboBoxSensorType";
            this.comboBoxSensorType.Size = new System.Drawing.Size(160, 24);
            this.comboBoxSensorType.TabIndex = 3;
            this.comboBoxSensorType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSensorType_SelectedIndexChanged);
            // 
            // DataControlPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataControlPage";
            this.Size = new System.Drawing.Size(1200, 738);
            this.Load += new System.EventHandler(this.DataControlPage_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatas)).EndInit();
            this.panelButonlar.ResumeLayout(false);
            this.panelButonlar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewDatas;
        private System.Windows.Forms.Label labelBaslik;
        private System.Windows.Forms.Panel panelButonlar;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSensorType;
    }
}
