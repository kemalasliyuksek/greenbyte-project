using System;
using System.Drawing;
using System.Windows.Forms;

namespace greenByte.Controls
{
    partial class AdminDashboardPage
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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel2 = new System.Windows.Forms.Panel();
            this.eventsLabel = new System.Windows.Forms.Label();
            this.notificationsListView = new System.Windows.Forms.ListView();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chartSicaklikVeNem = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.labelSuSeviyesi = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelToprakNem = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelIsik = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelSicaklik = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelNem = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSicaklikVeNem)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.eventsLabel);
            this.panel2.Controls.Add(this.notificationsListView);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.chartSicaklikVeNem);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 486);
            this.panel2.TabIndex = 2;
            // 
            // eventsLabel
            // 
            this.eventsLabel.AutoSize = true;
            this.eventsLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.eventsLabel.Location = new System.Drawing.Point(448, 41);
            this.eventsLabel.Name = "eventsLabel";
            this.eventsLabel.Size = new System.Drawing.Size(107, 20);
            this.eventsLabel.TabIndex = 11;
            this.eventsLabel.Text = "Son Bildirimler";
            // 
            // notificationsListView
            // 
            this.notificationsListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.notificationsListView.GridLines = true;
            this.notificationsListView.HideSelection = false;
            this.notificationsListView.Location = new System.Drawing.Point(445, 75);
            this.notificationsListView.Name = "notificationsListView";
            this.notificationsListView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.notificationsListView.Size = new System.Drawing.Size(523, 302);
            this.notificationsListView.TabIndex = 10;
            this.notificationsListView.UseCompatibleStateImageBehavior = false;
            this.notificationsListView.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(33, 446);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(649, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "_________________________________________________________________________________" +
    "__________________________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(36, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(230, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "24 Saatlik Sıcaklık ve Nem Grafiği";
            // 
            // chartSicaklikVeNem
            // 
            this.chartSicaklikVeNem.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chartSicaklikVeNem.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSicaklikVeNem.Legends.Add(legend1);
            this.chartSicaklikVeNem.Location = new System.Drawing.Point(23, 64);
            this.chartSicaklikVeNem.Name = "chartSicaklikVeNem";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSicaklikVeNem.Series.Add(series1);
            this.chartSicaklikVeNem.Size = new System.Drawing.Size(392, 313);
            this.chartSicaklikVeNem.TabIndex = 5;
            this.chartSicaklikVeNem.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(696, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "© GreenByte Sera Kontrol App. Tüm hakları saklıdır.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.97309F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.97309F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel1.Controls.Add(this.panel11, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(998, 143);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel11.Controls.Add(this.labelSuSeviyesi);
            this.panel11.Controls.Add(this.label12);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Location = new System.Drawing.Point(795, 23);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(180, 101);
            this.panel11.TabIndex = 4;
            // 
            // labelSuSeviyesi
            // 
            this.labelSuSeviyesi.AutoSize = true;
            this.labelSuSeviyesi.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSuSeviyesi.ForeColor = System.Drawing.Color.Black;
            this.labelSuSeviyesi.Location = new System.Drawing.Point(44, 41);
            this.labelSuSeviyesi.Name = "labelSuSeviyesi";
            this.labelSuSeviyesi.Size = new System.Drawing.Size(48, 25);
            this.labelSuSeviyesi.TabIndex = 4;
            this.labelSuSeviyesi.Text = "%72";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(16, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 21);
            this.label12.TabIndex = 2;
            this.label12.Text = "SU SEVİYESİ";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.LightBlue;
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(180, 4);
            this.panel12.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel6.Controls.Add(this.labelToprakNem);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Location = new System.Drawing.Point(602, 23);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(187, 101);
            this.panel6.TabIndex = 3;
            // 
            // labelToprakNem
            // 
            this.labelToprakNem.AutoSize = true;
            this.labelToprakNem.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelToprakNem.ForeColor = System.Drawing.Color.Black;
            this.labelToprakNem.Location = new System.Drawing.Point(44, 41);
            this.labelToprakNem.Name = "labelToprakNem";
            this.labelToprakNem.Size = new System.Drawing.Size(48, 25);
            this.labelToprakNem.TabIndex = 4;
            this.labelToprakNem.Text = "%72";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(16, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "TOPRAK NEMİ";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(187, 4);
            this.panel10.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel5.Controls.Add(this.labelIsik);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Location = new System.Drawing.Point(409, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(187, 101);
            this.panel5.TabIndex = 2;
            // 
            // labelIsik
            // 
            this.labelIsik.AutoSize = true;
            this.labelIsik.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelIsik.ForeColor = System.Drawing.Color.Black;
            this.labelIsik.Location = new System.Drawing.Point(38, 41);
            this.labelIsik.Name = "labelIsik";
            this.labelIsik.Size = new System.Drawing.Size(73, 25);
            this.labelIsik.TabIndex = 4;
            this.labelIsik.Text = "850 lux";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(14, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "IŞIK SEVİYESİ";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Khaki;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(187, 4);
            this.panel9.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.labelSicaklik);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Location = new System.Drawing.Point(23, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 101);
            this.panel3.TabIndex = 0;
            // 
            // labelSicaklik
            // 
            this.labelSicaklik.AutoSize = true;
            this.labelSicaklik.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSicaklik.ForeColor = System.Drawing.Color.Black;
            this.labelSicaklik.Location = new System.Drawing.Point(33, 43);
            this.labelSicaklik.Name = "labelSicaklik";
            this.labelSicaklik.Size = new System.Drawing.Size(53, 20);
            this.labelSicaklik.TabIndex = 2;
            this.labelSicaklik.Text = "24.5 C";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(13, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "SICAKLIK";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Brown;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(187, 4);
            this.panel7.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Controls.Add(this.labelNem);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Location = new System.Drawing.Point(216, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(187, 101);
            this.panel4.TabIndex = 1;
            // 
            // labelNem
            // 
            this.labelNem.AutoSize = true;
            this.labelNem.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelNem.ForeColor = System.Drawing.Color.Black;
            this.labelNem.Location = new System.Drawing.Point(32, 38);
            this.labelNem.Name = "labelNem";
            this.labelNem.Size = new System.Drawing.Size(48, 25);
            this.labelNem.TabIndex = 3;
            this.labelNem.Text = "%65";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(13, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "NEM";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.SteelBlue;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(187, 4);
            this.panel8.TabIndex = 1;
            // 
            // AdminDashboardPage
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "AdminDashboardPage";
            this.Size = new System.Drawing.Size(998, 616);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSicaklikVeNem)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

    

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSicaklikVeNem;
        private System.Windows.Forms.Label labelSicaklik;
        private System.Windows.Forms.Label labelToprakNem;
        private System.Windows.Forms.Label labelIsik;
        private System.Windows.Forms.Label labelNem;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label labelSuSeviyesi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label11;
        private ListView notificationsListView;
        private Label eventsLabel;
    }
}