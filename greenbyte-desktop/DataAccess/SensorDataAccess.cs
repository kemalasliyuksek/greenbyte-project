using Dapper;
using GreenByte.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class SensorDataAccess
    {
        public List<Sensor> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, sera_id AS GreenhouseId, ad AS Name FROM sensorler";
                return connection.Query<Sensor>(sql).ToList();
            }
        }

        public Sensor GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, sera_id AS GreenhouseId, ad AS SensorName, durum AS Status, eklenme_tarihi AS AddedDate FROM sensorler WHERE id = @Id";
                return connection.QueryFirstOrDefault<Sensor>(sql, new { Id = id });
            }
        }

        public void Add(Sensor sensor)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "INSERT INTO sensorler (sera_id, ad, durum) VALUES (@GreenhouseId, @Name, @Status)";
                connection.Execute(sql, sensor);
            }
        }

        public void Update(Sensor sensor)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "UPDATE sensorler SET sera_id = @GreenhouseId, ad = @Name, durum = @Status WHERE id = @Id";
                connection.Execute(sql, sensor);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM sensorler WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

        public List<SensorData> GetBySensorId(int sensorId) // sensörleri id ye göre getirme
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, sensor_id AS SensorId, deger AS Value, kayit_zamani AS RecordTime FROM sensor_verileri WHERE sensor_id = @SensorId ORDER BY kayit_zamani";
                return connection.Query<SensorData>(sql, new { SensorId = sensorId }).ToList();
            }
        }

        public List<Sensor> GetByGreenhouseId(int greenhouseId)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, sera_id AS GreenhouseId, ad AS SensorName FROM sensorler WHERE sera_id = @GreenhouseId";
                return connection.Query<Sensor>(sql, new { GreenhouseId = greenhouseId }).ToList();
            }
        }
    }
}