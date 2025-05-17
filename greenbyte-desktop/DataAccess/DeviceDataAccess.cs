using Dapper;
using GreenByte.Models;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class DeviceDataAccess
    {
        public List<Device> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, sera_id AS GreenhouseId, ad AS Name, durum AS Status, eklenme_tarihi AS AddedDate FROM cihazlar";
                return connection.Query<Device>(sql).ToList();
            }
        }

        public Device GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, sera_id AS GreenhouseId, ad AS Name, durum AS Status, eklenme_tarihi AS AddedDate FROM cihazlar WHERE id = @Id";
                return connection.QueryFirstOrDefault<Device>(sql, new { Id = id });
            }
        }

        public void Add(Device device)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "INSERT INTO cihazlar (sera_id, ad, durum) VALUES (@GreenhouseId, @Name, @Status)";
                connection.Execute(sql, device);
            }
        }

        public void Update(Device device)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "UPDATE cihazlar SET sera_id = @GreenhouseId, ad = @Name, durum = @Status WHERE id = @Id";
                connection.Execute(sql, device);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM cihazlar WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}