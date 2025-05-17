using greenByte.Controls;
using greenByte.Pages;
using GreenByte;
using GreenByte.DataAccess;
using GreenByte.Models;
using System;
using System.Windows.Forms;

namespace greenByte.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.buttonDashboardPage.Click += new System.EventHandler(this.buttonPage_Click);
            this.buttonUserControlPage.Click += new System.EventHandler(this.buttonPage_Click);
            this.buttonDataControlPage.Click += new System.EventHandler(this.buttonPage_Click);
            this.buttonSeraYonetimPage.Click += new System.EventHandler(this.buttonPage_Click);
            labelUsername.Text = CurrentUser.User.Username;

            clearAndAddControl(new AdminDashboardPage());
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Kullanıcı uygulamadan çıktı.",
                LogTime = DateTime.Now
            });
        }

        private void clearAndAddControl(Control control)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Padding = new Padding(5);
        }

        private void buttonPage_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                panelMain.Controls.Clear();
                switch (clickedButton.Name)
                {
                    case "buttonDashboardPage":
                        clearAndAddControl(new AdminDashboardPage());
                        LogDataAccess.Add(new LogModel
                        {
                            UserId = CurrentUser.Id,
                            LogType = LogType.Info,
                            Message = "Kullanıcı dashboard sayfasına yönlendirildi.",
                            LogTime = DateTime.Now
                        });
                        break; 
                    case "buttonUserControlPage":
                        clearAndAddControl(new UsersControlPage());
                        LogDataAccess.Add(new LogModel
                        {
                            UserId = CurrentUser.Id,
                            LogType = LogType.Info,
                            Message = "Kullanıcı kullanıcı yönetim sayfasına yönlendirildi.",
                            LogTime = DateTime.Now
                        });
                        break;
                    case "buttonSeraYonetimPage":
                        clearAndAddControl(new GreenHouseManagementPage());
                        LogDataAccess.Add(new LogModel
                        {
                            UserId = CurrentUser.Id,
                            LogType = LogType.Info,
                            Message = "Kullanıcı sera yönetim sayfasına yönlendirildi.",
                            LogTime = DateTime.Now
                        });
                        break;
                    case "buttonDataControlPage":
                       clearAndAddControl(new DataControlPage());
                       LogDataAccess.Add(new LogModel
                       {
                           UserId = CurrentUser.Id,
                           LogType = LogType.Info,
                           Message = "Kullanıcı veri yönetim sayfasına yönlendirildi.",
                           LogTime = DateTime.Now
                       });
                       break;
                    default:
                        clearAndAddControl(new AdminDashboardPage());
                        break;
                }

                //MessageBox.Show($"TablePanel kontrol sayısı: {tablePanel1.Controls.Count}");

            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;

            Properties.Settings.Default.rememberMe = false;
            Properties.Settings.Default.savedUsername = "";
            Properties.Settings.Default.savedPassword = "";
            Properties.Settings.Default.Save();

            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Kullanıcı çıkış yapıldı.",
                LogTime = DateTime.Now
            });
            FormLogin loginForm = new FormLogin();
            loginForm.Show();

            this.Close();
        }

        private void buttonLogView_Click(object sender, EventArgs e)
        {
            clearAndAddControl(new LogViewPage());
            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Kullanıcı hareket geçmişi sayfasına yönlendirildi.",
                LogTime = DateTime.Now
            });
        }
    }
}
