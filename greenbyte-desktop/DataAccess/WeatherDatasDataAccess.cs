using Dapper;
using GreenByte.Models;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class WeatherDataDataAccess
    {
        public List<WeatherData> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"SELECT id AS Id, sera_id AS GreenhouseId, sicaklik AS Temperature, nem AS Humidity, 
                               ruzgar_hizi AS WindSpeed, yagis AS IsRaining, hava_durumu_aciklama AS WeatherDescription, 
                               kayit_zamani AS RecordTime FROM hava_durumu";
                return connection.Query<WeatherData>(sql).ToList();
            }
        }

        public WeatherData GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"SELECT id AS Id, sera_id AS GreenhouseId, sicaklik AS Temperature, nem AS Humidity, 
                               ruzgar_hizi AS WindSpeed, yagis AS IsRaining, hava_durumu_aciklama AS WeatherDescription, 
                               kayit_zamani AS RecordTime FROM hava_durumu WHERE id = @Id";
                return connection.QueryFirstOrDefault<WeatherData>(sql, new { Id = id });
            }
        }

        public void Add(WeatherData weather)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"INSERT INTO hava_durumu (sera_id, sicaklik, nem, ruzgar_hizi, yagis, hava_durumu_aciklama) 
                               VALUES (@GreenhouseId, @Temperature, @Humidity, @WindSpeed, @IsRaining, @WeatherDescription)";
                connection.Execute(sql, weather);
            }
        }

        public void Update(WeatherData weather)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"UPDATE hava_durumu SET sera_id = @GreenhouseId, sicaklik = @Temperature, nem = @Humidity, 
                               ruzgar_hizi = @WindSpeed, yagis = @IsRaining, hava_durumu_aciklama = @WeatherDescription 
                               WHERE id = @Id";
                connection.Execute(sql, weather);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM hava_durumu WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}