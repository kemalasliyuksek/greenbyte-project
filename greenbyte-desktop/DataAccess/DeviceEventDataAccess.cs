using Dapper;
using GreenByte.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class DeviceEventDataAccess
    {
        public List<DeviceEvent> GetAll()
        {
            try
            {
                using (var connection = DBContext.GetConnection())
                {
                    string query = "SELECT id, cihaz_id, islem, tetikleyici, zaman FROM cihaz_olaylari";

                    // Dapper sorgusu
                    var events = connection.Query<DeviceEvent>(query).ToList();
                    return events;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Veri çekme hatası: " + ex.Message);
                throw;
            }
        }

        public DeviceEvent GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, cihaz_id AS DeviceId, islem AS Action, tetikleyici_tipi AS TriggerEvent, zaman AS Time, durum AS Status, aciklama AS Description FROM cihaz_olaylari WHERE id = @Id";
                return connection.QueryFirstOrDefault<DeviceEvent>(sql, new { Id = id });
            }
        }

        public void Add(DeviceEvent deviceEvent)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "INSERT INTO cihaz_olaylari (cihaz_id, islem, tetikleyici_tipi, zaman, durum, aciklama) VALUES (@DeviceId, @Action, @TriggerEvent, @Time, @Status, @Description)";
                connection.Execute(sql, deviceEvent);
            }
        }

        public void Update(DeviceEvent deviceEvent)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "UPDATE cihaz_olaylari SET cihaz_id = @DeviceId, islem = @Action, tetikleyici_tipi = @TriggerEvent, zaman = @Time, durum = @Status, aciklama = @Description WHERE id = @Id";
                connection.Execute(sql, deviceEvent);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM cihaz_olaylari WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}