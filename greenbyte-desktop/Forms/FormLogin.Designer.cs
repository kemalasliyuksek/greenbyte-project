using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GreenByte
{
    partial class FormLogin : Form // Ensure FormLogin inherits from Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel mainPanel;
        private Panel topBar;
        private Label titleLabel;
        private Button closeButton;
        private Panel rightPanel;
        private Label welcomeLabel;
        private Label subTitleLabel;
        private Label userLabel;
        private TextBox userTextBox;
        private Panel userUnderlinePanel;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Panel passwordUnderlinePanel;
        private CheckBox rememberMeCheckBox;
        private Button loginButton;
        private Panel leftLine;
        private Panel rightLine;
        private Label copyrightLabel;

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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.topBar = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.backgroundImage = new System.Windows.Forms.PictureBox();
            this.gradientPanel = new System.Windows.Forms.Panel();
            this.sloganLabel = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.subTitleLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.userUnderlinePanel = new System.Windows.Forms.Panel();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordUnderlinePanel = new System.Windows.Forms.Panel();
            this.rememberMeCheckBox = new System.Windows.Forms.CheckBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.leftLine = new System.Windows.Forms.Panel();
            this.rightLine = new System.Windows.Forms.Panel();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.topBar.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).BeginInit();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.topBar);
            this.mainPanel.Controls.Add(this.leftPanel);
            this.mainPanel.Controls.Add(this.rightPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(900, 600);
            this.mainPanel.TabIndex = 0;
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.topBar.Controls.Add(this.titleLabel);
            this.topBar.Controls.Add(this.closeButton);
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(900, 35);
            this.topBar.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(15, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(245, 19);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "GreenByte Sera Yönetim Sistemi - Giriş";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(860, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 25);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.leftPanel.Controls.Add(this.backgroundImage);
            this.leftPanel.Controls.Add(this.gradientPanel);
            this.leftPanel.Controls.Add(this.sloganLabel);
            this.leftPanel.Location = new System.Drawing.Point(0, 35);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(445, 565);
            this.leftPanel.TabIndex = 1;
            // 
            // backgroundImage
            // 
            this.backgroundImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.backgroundImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backgroundImage.BackgroundImage")));
            this.backgroundImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backgroundImage.Location = new System.Drawing.Point(0, 17);
            this.backgroundImage.Name = "backgroundImage";
            this.backgroundImage.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.backgroundImage.Size = new System.Drawing.Size(469, 533);
            this.backgroundImage.TabIndex = 0;
            this.backgroundImage.TabStop = false;
            // 
            // gradientPanel
            // 
            this.gradientPanel.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanel.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel.Name = "gradientPanel";
            this.gradientPanel.Size = new System.Drawing.Size(400, 565);
            this.gradientPanel.TabIndex = 1;
            // 
            // sloganLabel
            // 
            this.sloganLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.sloganLabel.ForeColor = System.Drawing.Color.White;
            this.sloganLabel.Location = new System.Drawing.Point(65, 500);
            this.sloganLabel.Name = "sloganLabel";
            this.sloganLabel.Size = new System.Drawing.Size(270, 25);
            this.sloganLabel.TabIndex = 2;
            this.sloganLabel.Text = "Akıllı Teknoloji, Verimli Tarım";
            this.sloganLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.White;
            this.rightPanel.Controls.Add(this.welcomeLabel);
            this.rightPanel.Controls.Add(this.subTitleLabel);
            this.rightPanel.Controls.Add(this.userLabel);
            this.rightPanel.Controls.Add(this.userTextBox);
            this.rightPanel.Controls.Add(this.userUnderlinePanel);
            this.rightPanel.Controls.Add(this.passwordLabel);
            this.rightPanel.Controls.Add(this.passwordTextBox);
            this.rightPanel.Controls.Add(this.passwordUnderlinePanel);
            this.rightPanel.Controls.Add(this.rememberMeCheckBox);
            this.rightPanel.Controls.Add(this.loginButton);
            this.rightPanel.Controls.Add(this.leftLine);
            this.rightPanel.Controls.Add(this.rightLine);
            this.rightPanel.Controls.Add(this.copyrightLabel);
            this.rightPanel.Location = new System.Drawing.Point(420, 35);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(425, 565);
            this.rightPanel.TabIndex = 2;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.welcomeLabel.Location = new System.Drawing.Point(125, 50);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(250, 40);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Hoş Geldiniz";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subTitleLabel
            // 
            this.subTitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.subTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.subTitleLabel.Location = new System.Drawing.Point(75, 88);
            this.subTitleLabel.Name = "subTitleLabel";
            this.subTitleLabel.Size = new System.Drawing.Size(350, 30);
            this.subTitleLabel.TabIndex = 1;
            this.subTitleLabel.Text = "Sera yönetim sisteminize giriş yapın";
            this.subTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.userLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.userLabel.Location = new System.Drawing.Point(55, 164);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(82, 19);
            this.userLabel.TabIndex = 2;
            this.userLabel.Text = "Kullanıcı Adı";
            // 
            // userTextBox
            // 
            this.userTextBox.BackColor = System.Drawing.Color.White;
            this.userTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.userTextBox.Location = new System.Drawing.Point(55, 186);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(390, 22);
            this.userTextBox.TabIndex = 3;
            // 
            // userUnderlinePanel
            // 
            this.userUnderlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.userUnderlinePanel.Location = new System.Drawing.Point(55, 210);
            this.userUnderlinePanel.Name = "userUnderlinePanel";
            this.userUnderlinePanel.Size = new System.Drawing.Size(390, 1);
            this.userUnderlinePanel.TabIndex = 4;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.passwordLabel.Location = new System.Drawing.Point(55, 249);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(35, 19);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Şifre";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.White;
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.passwordTextBox.Location = new System.Drawing.Point(55, 271);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(390, 22);
            this.passwordTextBox.TabIndex = 6;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordUnderlinePanel
            // 
            this.passwordUnderlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.passwordUnderlinePanel.Location = new System.Drawing.Point(55, 295);
            this.passwordUnderlinePanel.Name = "passwordUnderlinePanel";
            this.passwordUnderlinePanel.Size = new System.Drawing.Size(390, 1);
            this.passwordUnderlinePanel.TabIndex = 7;
            // 
            // rememberMeCheckBox
            // 
            this.rememberMeCheckBox.AutoSize = true;
            this.rememberMeCheckBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rememberMeCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.rememberMeCheckBox.Location = new System.Drawing.Point(55, 310);
            this.rememberMeCheckBox.Name = "rememberMeCheckBox";
            this.rememberMeCheckBox.Size = new System.Drawing.Size(98, 23);
            this.rememberMeCheckBox.TabIndex = 9;
            this.rememberMeCheckBox.Text = "Beni Hatırla";            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(55, 350);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(390, 45);
            this.loginButton.TabIndex = 10;
            this.loginButton.Text = "GİRİŞ YAP";
            this.loginButton.UseVisualStyleBackColor = false;
            // 
            // leftLine
            // 
            this.leftLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.leftLine.Location = new System.Drawing.Point(55, 455);
            this.leftLine.Name = "leftLine";
            this.leftLine.Size = new System.Drawing.Size(160, 1);
            this.leftLine.TabIndex = 11;
            // 
            // rightLine
            // 
            this.rightLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rightLine.Location = new System.Drawing.Point(285, 455);
            this.rightLine.Name = "rightLine";
            this.rightLine.Size = new System.Drawing.Size(160, 1);
            this.rightLine.TabIndex = 12;
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.copyrightLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.copyrightLabel.Location = new System.Drawing.Point(100, 535);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(300, 15);
            this.copyrightLabel.TabIndex = 13;
            this.copyrightLabel.Text = "© 2025 GreenByte Ltd. Şti. Tüm hakları saklıdır.";
            this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormLogin
            // 
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GreenByte Sera Yönetim Sistemi - Giriş";
            this.mainPanel.ResumeLayout(false);
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel leftPanel;
        private PictureBox backgroundImage;
        private Panel gradientPanel;
        private Label sloganLabel;
    }
}