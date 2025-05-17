using GreenByte.DataAccess;
using GreenByte.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace greenByte.Pages
{
    public partial class LogViewPage : UserControl
    {
        private LogDataAccess logDataAccess;
        private List<LogModel> allLogs;  
        public LogViewPage()
        {
            InitializeComponent();
            logDataAccess = new LogDataAccess();
            allLogs = new List<LogModel>();
            LoadLogs(); 
            LoadComboBoxes();
        }

        private void LoadLogs()
        {
            try
            {
                allLogs = logDataAccess.GetAll();
                DisplayLogs(allLogs);
                UpdateStatusLabel(allLogs.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Log kayıtları yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void DisplayLogs(List<LogModel> logs)
        {
            dgvLogs.DataSource = null;
            dgvLogs.DataSource = logs;

            lblStatus.Text = $"Toplam {logs.Count} kayıt gösteriliyor.";
        }

        private void ApplyFilter()
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            int selectedUser = cmbUsers.SelectedValue is int ? (int)cmbUsers.SelectedValue : -1;
            string selectedLogType = cmbLogType.SelectedIndex >= 0 ? cmbLogType.SelectedItem.ToString() : null;
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1);

            var filteredLogs = allLogs.Where(log =>
                (string.IsNullOrEmpty(searchText) || log.Message.ToLower().Contains(searchText) || log.LogType.ToString().ToLower().Contains(searchText)) &&
                (selectedUser == -1 || log.UserId == selectedUser) &&
                (string.IsNullOrEmpty(selectedLogType) || log.LogType.ToString() == selectedLogType) &&
                (log.LogTime >= startDate && log.LogTime <= endDate)
            ).ToList();

            DisplayLogs(filteredLogs);
        }

        private void DateFilter_Changed(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbUsers.SelectedIndex = -1;
            cmbLogType.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Now.AddMonths(-1); // Son bir ay
            dtpEndDate.Value = DateTime.Now;
            LoadLogs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void UpdateStatusLabel(int count)
        {
            lblStatus.Text = $"Toplam {count} kayıt gösteriliyor.";
        }

        private void LoadComboBoxes()
        {
            try
            {
                cmbLogType.Items.Clear();
                cmbLogType.Items.Add("Info");
                cmbLogType.Items.Add("Error");
                cmbLogType.SelectedIndex = -1;

                var users = logDataAccess.GetAllUsers();
                users.Insert(0, new UserModel { Id = -1, Username = "Tümü" }); 

                cmbUsers.DataSource = users;
                cmbUsers.DisplayMember = "Username"; 
                cmbUsers.ValueMember = "Id"; 
                cmbUsers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = $"Kullanıcıları yüklerken hata oluştu: {ex.Message}",
                    LogTime = DateTime.Now
                });
                MessageBox.Show("Kullanıcıları yüklerken bir hata oluştu: " + ex.Message);
            }
        }
    }
    
}
