using Dapper;
using GreenByte.Models;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class PlantTypeDataAccess
    {
        public List<PlantTypeModel> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"SELECT id AS Id, tur_adi AS TypeName, min_sicaklik AS MinTemperature, max_sicaklik AS MaxTemperature,
                               min_nem AS MinHumidity, max_nem AS MaxHumidity, min_gunluk_isik_saati AS MinDailyLightHours,
                               max_gunluk_isik_saati AS MaxDailyLightHours, min_isik_yogunlugu AS MinLightIntensity,
                               max_isik_yogunlugu AS MaxLightIntensity, min_toprak_nemi AS MinSoilMoisture, 
                               max_toprak_nemi AS MaxSoilMoisture, sulama_sikligi AS IrrigationFrequency, 
                               yetistirme_suresi AS GrowingPeriod, notlar AS Notes, eklenme_tarihi AS AddedDate 
                               FROM bitki_turleri";
                return connection.Query<PlantTypeModel>(sql).ToList();
            }
        }

        public PlantTypeModel GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"SELECT id AS Id, tur_adi AS TypeName, min_sicaklik AS MinTemperature, max_sicaklik AS MaxTemperature,
                               min_nem AS MinHumidity, max_nem AS MaxHumidity, min_gunluk_isik_saati AS MinDailyLightHours,
                               max_gunluk_isik_saati AS MaxDailyLightHours, min_isik_yogunlugu AS MinLightIntensity,
                               max_isik_yogunlugu AS MaxLightIntensity, min_toprak_nemi AS MinSoilMoisture, 
                               max_toprak_nemi AS MaxSoilMoisture, sulama_sikligi AS IrrigationFrequency, 
                               yetistirme_suresi AS GrowingPeriod, notlar AS Notes, eklenme_tarihi AS AddedDate 
                               FROM bitki_turleri WHERE id = @Id";
                return connection.QueryFirstOrDefault<PlantTypeModel>(sql, new { Id = id });
            }
        }

        public void Add(PlantTypeModel plantType)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"INSERT INTO bitki_turleri (tur_adi, min_sicaklik, max_sicaklik, min_nem, max_nem, 
                               min_gunluk_isik_saati, max_gunluk_isik_saati, min_isik_yogunlugu, max_isik_yogunlugu, 
                               min_toprak_nemi, max_toprak_nemi, sulama_sikligi, yetistirme_suresi, notlar) 
                               VALUES (@TypeName, @MinTemperature, @MaxTemperature, @MinHumidity, @MaxHumidity, 
                               @MinDailyLightHours, @MaxDailyLightHours, @MinLightIntensity, @MaxLightIntensity, 
                               @MinSoilMoisture, @MaxSoilMoisture, @IrrigationFrequency, @GrowingPeriod, @Notes)";
                connection.Execute(sql, plantType);
            }
        }

        public void Update(PlantTypeModel plantType)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"UPDATE bitki_turleri SET tur_adi = @TypeName, min_sicaklik = @MinTemperature, 
                               max_sicaklik = @MaxTemperature, min_nem = @MinHumidity, max_nem = @MaxHumidity, 
                               min_gunluk_isik_saati = @MinDailyLightHours, max_gunluk_isik_saati = @MaxDailyLightHours, 
                               min_isik_yogunlugu = @MinLightIntensity, max_isik_yogunlugu = @MaxLightIntensity, 
                               min_toprak_nemi = @MinSoilMoisture, max_toprak_nemi = @MaxSoilMoisture, 
                               sulama_sikligi = @IrrigationFrequency, yetistirme_suresi = @GrowingPeriod, 
                               notlar = @Notes WHERE id = @Id";
                connection.Execute(sql, plantType);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM bitki_turleri WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}