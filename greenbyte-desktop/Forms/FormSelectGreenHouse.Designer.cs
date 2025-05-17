namespace greenByte.Forms
{
    partial class FormSelectGreenHouse
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
            this.comboBoxGreenHouse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonBackToLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonDevam = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxGreenHouse
            // 
            this.comboBoxGreenHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboBoxGreenHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxGreenHouse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxGreenHouse.FormattingEnabled = true;
            this.comboBoxGreenHouse.Location = new System.Drawing.Point(123, 123);
            this.comboBoxGreenHouse.Name = "comboBoxGreenHouse";
            this.comboBoxGreenHouse.Size = new System.Drawing.Size(189, 25);
            this.comboBoxGreenHouse.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(92, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Devam etmek için lütfen sera seçiniz";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.buttonBackToLogin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.panel1.Size = new System.Drawing.Size(424, 34);
            this.panel1.TabIndex = 12;
            // 
            // buttonBackToLogin
            // 
            this.buttonBackToLogin.FlatAppearance.BorderSize = 0;
            this.buttonBackToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToLogin.Image = global::greenByte.Properties.Resources.lets_icons__back;
            this.buttonBackToLogin.Location = new System.Drawing.Point(392, 0);
            this.buttonBackToLogin.Name = "buttonBackToLogin";
            this.buttonBackToLogin.Size = new System.Drawing.Size(32, 34);
            this.buttonBackToLogin.TabIndex = 2;
            this.buttonBackToLogin.UseVisualStyleBackColor = true;
            this.buttonBackToLogin.Click += new System.EventHandler(this.buttonBackToLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(7, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hoşgeldiniz - GreenByte Sera Kontrol Paneli";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::greenByte.Properties.Resources.icon21;
            this.pictureBox1.Location = new System.Drawing.Point(213, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 215);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // buttonDevam
            // 
            this.buttonDevam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.buttonDevam.FlatAppearance.BorderSize = 0;
            this.buttonDevam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDevam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDevam.ForeColor = System.Drawing.Color.White;
            this.buttonDevam.Location = new System.Drawing.Point(172, 164);
            this.buttonDevam.Name = "buttonDevam";
            this.buttonDevam.Size = new System.Drawing.Size(95, 34);
            this.buttonDevam.TabIndex = 14;
            this.buttonDevam.Text = "Devam";
            this.buttonDevam.UseVisualStyleBackColor = false;
            this.buttonDevam.Click += new System.EventHandler(this.buttonDevam_Click);
            // 
            // FormSelectGreenHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 299);
            this.Controls.Add(this.buttonDevam);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxGreenHouse);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSelectGreenHouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSelectGreenHouse";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxGreenHouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonBackToLogin;
        private System.Windows.Forms.Button buttonDevam;
    }
}