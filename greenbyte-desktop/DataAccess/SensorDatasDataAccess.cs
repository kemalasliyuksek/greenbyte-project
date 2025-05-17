using Dapper;
using GreenByte.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class SensorDataDataAccess
    {
        public List<SensorData> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                // sera_id sütunu kaldırıldı
                string sql = "SELECT id AS Id, sensor_id AS SensorId, deger AS Value, kayit_zamani AS RecordTime FROM sensor_verileri";
                return connection.Query<SensorData>(sql).ToList();
            }
        }

        public SensorData GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                // sera_id sütunu kaldırıldı
                string sql = "SELECT id AS Id, sensor_id AS SensorId, deger AS Value, kayit_zamani AS RecordTime FROM sensor_verileri WHERE id = @Id";
                return connection.QueryFirstOrDefault<SensorData>(sql, new { Id = id });
            }
        }

        public void Add(SensorData data)
        {
            using (var connection = DBContext.GetConnection())
            {
                // sera_id sütunu kaldırıldı
                string sql = "INSERT INTO sensor_verileri (sensor_id, deger) VALUES (@SensorId, @Value)";
                connection.Execute(sql, data);
            }
        }

        public void Update(SensorData data)
        {
            using (var connection = DBContext.GetConnection())
            {
                // sera_id sütunu kaldırıldı
                string sql = "UPDATE sensor_verileri SET sensor_id = @SensorId, deger = @Value WHERE id = @Id";
                connection.Execute(sql, data);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM sensor_verileri WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

        public List<SensorData> GetBySensorId(int sensorId)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"SELECT sv.id AS Id, sv.sensor_id AS SensorId, 
                      s.ad AS SensorName, sv.deger AS Value, 
                      sv.kayit_zamani AS RecordTime 
                      FROM sensor_verileri sv
                      JOIN sensorler s ON sv.sensor_id = s.id
                      WHERE sv.sensor_id = @SensorId 
                      ORDER BY sv.kayit_zamani DESC";
                return connection.Query<SensorData>(sql, new { SensorId = sensorId }).ToList();
            }
        }

        public List<SensorData> GetDatasByGreenhouseId(int greenhouseId)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"SELECT sv.id, sv.sensor_id, s.ad AS SensorName, sv.deger, sv.kayit_zamani
FROM sensor_verileri sv
JOIN sensorler s ON sv.sensor_id = s.id
WHERE s.sera_id = @GreenhouseId
ORDER BY sv.kayit_zamani DESC";

                return connection.Query<SensorData>(sql, new { GreenhouseId = greenhouseId }).ToList();
            }
        }

        public List<SensorData> GetBySensorIdAndDate(int sensorId, DateTime date)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"
            SELECT sv.id AS Id, sv.sensor_id AS SensorId, s.ad AS SensorName, sv.deger AS Value, sv.kayit_zamani AS RecordTime
            FROM sensor_verileri sv
            JOIN sensorler s ON sv.sensor_id = s.id
            WHERE sv.sensor_id = @SensorId
              AND CAST(sv.kayit_zamani AS DATE) = @Date
            ORDER BY sv.kayit_zamani DESC";
                return connection.Query<SensorData>(sql, new { SensorId = sensorId, Date = date.Date }).ToList();
            }
        }

        public List<SensorData> GetDatasByGreenhouseIdAndDate(int greenhouseId, DateTime date)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"
            SELECT sv.id AS Id, sv.sensor_id AS SensorId, s.ad AS SensorName, sv.deger AS Value, sv.kayit_zamani AS RecordTime
            FROM sensor_verileri sv
            JOIN sensorler s ON sv.sensor_id = s.id
            WHERE s.sera_id = @GreenhouseId
              AND CAST(sv.kayit_zamani AS DATE) = @Date
            ORDER BY sv.kayit_zamani DESC";
                return connection.Query<SensorData>(sql, new { GreenhouseId = greenhouseId, Date = date.Date }).ToList();
            }
        }

    }
}