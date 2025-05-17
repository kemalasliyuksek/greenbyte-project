using GreenByte.DataAccess;
using GreenByte.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace greenByte.Pages
{
    public partial class DataControlPage : UserControl
    {
        private SensorDataDataAccess sensordal = new SensorDataDataAccess();
        public DataControlPage()
        {
            InitializeComponent();
            Utils.StyleDataGrid(dataGridViewDatas);
            LoadSensorTypes();
            LoadDatas();
        }
        private void LoadSensorTypes()
        {
            try
            {
                var sensorDal = new SensorDataAccess();
                var seraId = CurrentGreenhouse.Selected?.Id ?? 0;
                List<Sensor> sensors = sensorDal.GetByGreenhouseId(seraId);

                sensors.Insert(0, new Sensor { Id = 0, SensorName = "Tüm Sensörler" });

                comboBoxSensorType.DataSource = sensors;
                comboBoxSensorType.DisplayMember = "SensorName";
                comboBoxSensorType.ValueMember = "Id";

                comboBoxSensorType.SelectedIndex = 0;

                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = "Sensör listesi başarıyla yüklendi.",
                    LogTime = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sensör listesi yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = $"Sensör listesi yüklenirken hata oluştu: {ex.Message}",
                    LogTime = DateTime.Now
                });
            }
        }
        private void LoadDatas()
        {
            try
            {
                if (CurrentGreenhouse.Selected == null)
                {
                    CurrentGreenhouse.Selected = new GreenHouseModel
                    {
                        Id = 1,
                        Name = "Test Sera",
                        Location = "Test",
                        UserId = 1,
                        CreationDate = DateTime.Now
                    };
                }

                int seraId = CurrentGreenhouse.Selected.Id;
                int selectedSensorId = 0;

                if (comboBoxSensorType.SelectedIndex > 0 && comboBoxSensorType.SelectedValue != null)
                {
                    if (comboBoxSensorType.SelectedValue is int)
                        selectedSensorId = (int)comboBoxSensorType.SelectedValue;
                    else if (comboBoxSensorType.SelectedValue is Sensor)
                        selectedSensorId = ((Sensor)comboBoxSensorType.SelectedValue).Id;
                    else
                        int.TryParse(comboBoxSensorType.SelectedValue.ToString(), out selectedSensorId);
                }

                DateTime selectedDate = dateTimePickerDatas.Value.Date;
                List<SensorData> filteredDatas;

                if (selectedSensorId > 0)
                {
                    filteredDatas = sensordal.GetBySensorIdAndDate(selectedSensorId, selectedDate);

                    LogDataAccess.Add(new LogModel
                    {
                        UserId = CurrentUser.Id,
                        LogType = LogType.Info,
                        Message = $"'{selectedSensorId}' sensörüne ait veriler {selectedDate:dd.MM.yyyy} tarihi için yüklendi.",
                        LogTime = DateTime.Now
                    });
                }
                else
                {
                    filteredDatas = sensordal.GetDatasByGreenhouseIdAndDate(seraId, selectedDate);

                    LogDataAccess.Add(new LogModel
                    {
                        UserId = CurrentUser.Id,
                        LogType = LogType.Info,
                        Message = $"Tüm sensör verileri {selectedDate:dd.MM.yyyy} tarihi için yüklendi.",
                        LogTime = DateTime.Now
                    });
                }

                dataGridViewDatas.DataSource = filteredDatas;

                if (dataGridViewDatas.Columns.Count > 0)
                {
                    dataGridViewDatas.Columns["Id"].Visible = false;
                    dataGridViewDatas.Columns["SensorId"].Visible = false;

                    if (dataGridViewDatas.Columns.Contains("SensorName"))
                        dataGridViewDatas.Columns["SensorName"].HeaderText = "Sensör";

                    dataGridViewDatas.Columns["Value"].HeaderText = "Değer";

                    dataGridViewDatas.Columns["RecordTime"].HeaderText = "Kayıt Zamanı";
                    dataGridViewDatas.Columns["RecordTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dataGridViewDatas.Columns["RecordTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = $"Veriler yüklenirken hata oluştu: {ex.Message}",
                    LogTime = DateTime.Now
                });
            }
        }

        private void comboBoxSensorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDatas();
        }

        private void DataControlPage_Load(object sender, EventArgs e)
        {
            LoadDatas();
        }

        private void dateTimePickerDatas_ValueChanged(object sender, EventArgs e)
        {
            LoadDatas();
        }
    }
}