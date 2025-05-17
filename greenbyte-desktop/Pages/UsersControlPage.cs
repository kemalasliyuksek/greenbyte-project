using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using greenByte.Forms;
using GreenByte.DataAccess;
using GreenByte.Models;

namespace greenByte.Pages
{
    public partial class UsersControlPage : UserControl
    {
        private UserDataAccess userDal = new UserDataAccess();

        public UsersControlPage()
        {
            
            InitializeComponent();
            LoadUsers();
            Utils.StyleDataGrid(dataGridViewUsers);
        }

        private void LoadUsers()
        {
            try
            {
                var seraId = CurrentGreenhouse.Selected?.Id ?? 0;

                var users = userDal.GetAll();

                // Filtreleme ve DataGridView doldurma
                var filteredUsers = users.Where(u => u.GreenhouseId == seraId).ToList();

                dataGridViewUsers.DataSource = filteredUsers;

                // Kolon başlıklarını düzenle
                dataGridViewUsers.Columns["Id"].HeaderText = "ID";
                dataGridViewUsers.Columns["Id"].Visible = false;
                dataGridViewUsers.Columns["Username"].HeaderText = "Kullanıcı Adı";
                dataGridViewUsers.Columns["Email"].HeaderText = "E-posta";
                dataGridViewUsers.Columns["RegistrationDate"].HeaderText = "Kayıt Tarihi";
                dataGridViewUsers.Columns["GreenhouseId"].HeaderText = "Sera ID";
                dataGridViewUsers.Columns["GreenhouseId"].Visible = false;
                dataGridViewUsers.Columns["Password"].Visible = false; // Şifreyi gizle
            }catch
            {
                MessageBox.Show("Kullanıcı listesi yüklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Kullanıcı listesi yüklenirken hata oluştu.",
                    LogTime = DateTime.Now
                });
            }
        }

       

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            var form = new FormUser();
            try{
             if (form.ShowDialog() == DialogResult.OK)
             {
                userDal.Add(form.User);
                // Log ekle
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = $"{form.User.Username} adlı kullanıcı eklendi.",
                    LogTime = DateTime.Now
                });
                LoadUsers();
             } 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Kullanıcı Ekleme Hatası: " + ex.Message,
                    LogTime = DateTime.Now
                });
            }
            
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow == null) return;
            var selectedUser = dataGridViewUsers.CurrentRow.DataBoundItem as UserModel;
            if (selectedUser == null) return;

            var userCopy = new UserModel
            {
                Id = selectedUser.Id,
                Username = selectedUser.Username,
                Email = selectedUser.Email,
                Password = selectedUser.Password,
                RegistrationDate = selectedUser.RegistrationDate,
                GreenhouseId = selectedUser.GreenhouseId
            };

            var form = new FormUser(userCopy);
            try{
            if (form.ShowDialog() == DialogResult.OK)
            {
                userDal.Update(form.User);
                // Log ekle
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = $"{form.User.Username} adlı kullanıcı güncellendi.",
                    LogTime = DateTime.Now
                });
                LoadUsers();
                MessageBox.Show("Kullanıcı başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Kullanıcı Güncelleme Hatası: " + ex.Message,
                    LogTime = DateTime.Now
                });
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow == null) return;
            var selectedUser = dataGridViewUsers.CurrentRow.DataBoundItem as UserModel;
            if (selectedUser == null) return;

            var result = MessageBox.Show("Kullanıcıyı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try{
                userDal.Delete(selectedUser.Id);
                // Log ekle
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = $"{selectedUser.Username} adlı kullanıcı silindi.",
                    LogTime = DateTime.Now
                });
                LoadUsers();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogDataAccess.Add(new LogModel
                    {
                        UserId = CurrentUser.Id,
                        LogType = LogType.Error,
                        Message = "Kullanıcı Silme Hatası: " + ex.Message,
                        LogTime = DateTime.Now
                    });
                }
            }
        }

        private void buttonRefreshData_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void textBoxSearchUser_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearchUser.Text.ToLower();
            var seraId = CurrentGreenhouse.Selected?.Id ?? 0;
            var users = userDal.GetAll();
            var filteredUsers = users.Where(u => u.GreenhouseId == seraId &&
                (u.Username.ToLower().Contains(searchText) ||
                 u.Email.ToLower().Contains(searchText)))
                .ToList();
            dataGridViewUsers.DataSource = filteredUsers;
        }
    }
}
