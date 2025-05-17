using GreenByte;
using GreenByte.DataAccess;
using GreenByte.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace greenByte.Forms
{
    public partial class FormSelectGreenHouse : Form
    {
        public GreenHouseModel SelectedGreenhouse { get; private set; }

        public FormSelectGreenHouse()
        {
            InitializeComponent();
            fillGreenHouseCombo();
            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Kullanıcı sera seçimi sayfasına yönlendirildi.",
                LogTime = DateTime.Now
            });
        }

        private void fillGreenHouseCombo()
        {
            try
            {
                var user = CurrentUser.User;
                if (user == null)
                    return;

                var greenhouseDal = new GreenHouseDataAccess();
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = "Kullanıcıya ait seralar çekildi.",
                    LogTime = DateTime.Now
                });
                var greenhouses = greenhouseDal.GetAll()
                                               .Where(g => g.UserId == user.Id)
                                               .ToList();

                comboBoxGreenHouse.DataSource = greenhouses;
                comboBoxGreenHouse.DisplayMember = "Name";
                comboBoxGreenHouse.ValueMember = "Id";
                if (greenhouses.Count > 0)
                    comboBoxGreenHouse.SelectedIndex = 0;
            } catch(Exception ex)
            {
                MessageBox.Show("Seralar yüklenirken bir hata oluştu: " + ex.Message);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Seralar yüklenirken hata: " + ex.Message,
                    LogTime = DateTime.Now
                });
            }

        }

        private void buttonDevam_Click(object sender, EventArgs e)
        {
            SelectedGreenhouse = comboBoxGreenHouse.SelectedItem as GreenHouseModel;
            if (SelectedGreenhouse == null)
            {
                MessageBox.Show("Lütfen bir sera seçiniz!");
                return;
            }

            CurrentGreenhouse.Selected = SelectedGreenhouse;
            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Kullanıcı seçili serayı global olarak atandı.",
                LogTime = DateTime.Now
            });
 
            var mainForm = new FormMain();
            mainForm.Show();
            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Kullanıcı ana forma yönlendirildi.",
                LogTime = DateTime.Now
            });
            this.Hide();
        }

        private void buttonBackToLogin_Click(object sender, EventArgs e)
        {
            // Login sayfasına geri git
            var loginForm = new FormLogin();
            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Kullanıcı giriş sayfasına geri yönlendirildi.",
                LogTime = DateTime.Now
            });
            loginForm.Show();
            this.Hide();
        }
    }
}
