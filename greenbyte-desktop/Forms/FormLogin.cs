using greenByte.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using GreenByte.DataAccess;
using System.Linq;
using GreenByte.Models;


namespace GreenByte
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            userTextBox.Enter += (s, e) => userUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            userTextBox.Leave += (s, e) => userUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            passwordTextBox.Enter += (s, e) => passwordUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            passwordTextBox.Leave += (s, e) => passwordUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            loginButton.Click += LoginButton_Click;

            if (greenByte.Properties.Settings.Default.rememberMe)
            {
                userTextBox.Text = greenByte.Properties.Settings.Default.savedUsername;
                passwordTextBox.Text = greenByte.Properties.Settings.Default.savedPassword;
                rememberMeCheckBox.Checked = true;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Panel rightPanel = this.Controls[0].Controls[2] as Panel;
            TextBox userTextBox = rightPanel.Controls[3] as TextBox;
            TextBox passwordTextBox = rightPanel.Controls[6] as TextBox;

            string username = userTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
                return;
            }

            try
            {
                var userDal = new UserDataAccess();
                var user = userDal.GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    CurrentUser.User = user;

                    CurrentUser.Id = user.Id;

                    this.Hide();

                    var seraSecForm = new FormSelectGreenHouse();
                    if (seraSecForm.ShowDialog() == DialogResult.OK)
                    {

                        CurrentGreenhouse.Selected = seraSecForm.SelectedGreenhouse;

                        var mainForm = new FormMain();
                        mainForm.Show();
                        LogDataAccess.Add(new LogModel
                        {
                            UserId = CurrentUser.Id,
                            LogType = LogType.Info,
                            Message = "Kullanıcı ana ekrana yönlendirildi.",
                            LogTime = DateTime.Now
                        });
                    }

                    greenByte.Properties.Settings.Default.rememberMe = rememberMeCheckBox.Checked;

                    if (rememberMeCheckBox.Checked)
                    {
                        greenByte.Properties.Settings.Default.savedUsername = username;
                        greenByte.Properties.Settings.Default.savedPassword = password;
                    }
                    else
                    {
                        greenByte.Properties.Settings.Default.savedUsername = string.Empty;
                        greenByte.Properties.Settings.Default.savedPassword = string.Empty;
                    }

                    greenByte.Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogDataAccess.Add(new LogModel
                    {
                        UserId = CurrentUser.Id,
                        LogType = LogType.Error,
                        Message = "Hatalı şifre veya kullanıcı adı denemesi yapıldı!",
                        LogTime = DateTime.Now
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Bağlantı hatası: " + ex.Message,
                    LogTime = DateTime.Now
                });
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {

            CurrentUser.User = null;
            Application.Exit();
            LogDataAccess.Add(new LogModel
            {
                LogType = LogType.Info,
                Message = "Kullanıcı uygulamadan çıktı.",
                LogTime = DateTime.Now
            });
        }

    }
}