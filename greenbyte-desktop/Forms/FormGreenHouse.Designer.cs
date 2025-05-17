namespace greenByte.Forms
{
    partial class FormGreenhouse
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGHLocation = new System.Windows.Forms.TextBox();
            this.txtKonum = new System.Windows.Forms.Label();
            this.txtGHName = new System.Windows.Forms.TextBox();
            this.txtSeraAdi = new System.Windows.Forms.Label();
            this.dateTimePickerKurulusTarihi = new System.Windows.Forms.DateTimePicker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panel1.Size = new System.Drawing.Size(499, 36);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "GreenByte  - Sera Ekleme/Düzenleme";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(463, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.buttonClose.Size = new System.Drawing.Size(31, 36);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(209, 203);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 31);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGHLocation
            // 
            this.txtGHLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGHLocation.Location = new System.Drawing.Point(232, 159);
            this.txtGHLocation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGHLocation.Name = "txtGHLocation";
            this.txtGHLocation.Size = new System.Drawing.Size(166, 25);
            this.txtGHLocation.TabIndex = 34;
            // 
            // txtKonum
            // 
            this.txtKonum.AutoSize = true;
            this.txtKonum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKonum.Location = new System.Drawing.Point(141, 163);
            this.txtKonum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtKonum.Name = "txtKonum";
            this.txtKonum.Size = new System.Drawing.Size(76, 15);
            this.txtKonum.TabIndex = 33;
            this.txtKonum.Text = "Konum Girin";
            // 
            // txtGHName
            // 
            this.txtGHName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGHName.Location = new System.Drawing.Point(232, 114);
            this.txtGHName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGHName.Name = "txtGHName";
            this.txtGHName.Size = new System.Drawing.Size(166, 25);
            this.txtGHName.TabIndex = 32;
            // 
            // txtSeraAdi
            // 
            this.txtSeraAdi.AutoSize = true;
            this.txtSeraAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSeraAdi.Location = new System.Drawing.Point(135, 124);
            this.txtSeraAdi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtSeraAdi.Name = "txtSeraAdi";
            this.txtSeraAdi.Size = new System.Drawing.Size(82, 15);
            this.txtSeraAdi.TabIndex = 31;
            this.txtSeraAdi.Text = "Sera Adı Girin";
            // 
            // dateTimePickerKurulusTarihi
            // 
            this.dateTimePickerKurulusTarihi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerKurulusTarihi.Location = new System.Drawing.Point(232, 74);
            this.dateTimePickerKurulusTarihi.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerKurulusTarihi.Name = "dateTimePickerKurulusTarihi";
            this.dateTimePickerKurulusTarihi.Size = new System.Drawing.Size(164, 23);
            this.dateTimePickerKurulusTarihi.TabIndex = 38;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::greenByte.Properties.Resources.icon21;
            this.pictureBox2.Location = new System.Drawing.Point(284, 103);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(267, 248);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(105, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "Sera Kuruluş Tarihi";
            // 
            // FormGreenhouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 293);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerKurulusTarihi);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGHLocation);
            this.Controls.Add(this.txtKonum);
            this.Controls.Add(this.txtGHName);
            this.Controls.Add(this.txtSeraAdi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormGreenhouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGreenhouse";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtGHLocation;
        private System.Windows.Forms.Label txtKonum;
        private System.Windows.Forms.TextBox txtGHName;
        private System.Windows.Forms.Label txtSeraAdi;
        private System.Windows.Forms.DateTimePicker dateTimePickerKurulusTarihi;
        private System.Windows.Forms.Label label2;
    }
}