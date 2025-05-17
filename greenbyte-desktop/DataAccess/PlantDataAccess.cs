using Dapper;
using GreenByte.Models;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class PlantDataAccess
    {
        public List<PlantModel> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"SELECT id AS Id, sera_id AS GreenhouseId, bitki_tur_id AS PlantTypeId, bolge_kodu AS AreaCode, 
                               ekim_tarihi AS SowingDate, gelisim_yuzdesi AS GrowthPercentage, tahmini_hasat_tarihi AS EstimatedHarvestDate, 
                               not AS Note, durum AS Status, son_guncelleme AS LastUpdate FROM bitkiler";
                return connection.Query<PlantModel>(sql).ToList();
            }
        }

        public PlantModel GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"SELECT id AS Id, sera_id AS GreenhouseId, bitki_tur_id AS PlantTypeId, bolge_kodu AS AreaCode, 
                               ekim_tarihi AS SowingDate, gelisim_yuzdesi AS GrowthPercentage, tahmini_hasat_tarihi AS EstimatedHarvestDate, 
                               not AS Note, durum AS Status, son_guncelleme AS LastUpdate FROM bitkiler WHERE id = @Id";
                return connection.QueryFirstOrDefault<PlantModel>(sql, new { Id = id });
            }
        }

        public void Add(PlantModel plant)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"INSERT INTO bitkiler (sera_id, bitki_tur_id, bolge_kodu, ekim_tarihi, gelisim_yuzdesi, tahmini_hasat_tarihi, not, durum) 
                               VALUES (@GreenhouseId, @PlantTypeId, @AreaCode, @SowingDate, @GrowthPercentage, @EstimatedHarvestDate, @Note, @Status)";
                connection.Execute(sql, plant);
            }
        }

        public void Update(PlantModel plant)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = @"UPDATE bitkiler SET sera_id = @GreenhouseId, bitki_tur_id = @PlantTypeId, bolge_kodu = @AreaCode, 
                               ekim_tarihi = @SowingDate, gelisim_yuzdesi = @GrowthPercentage, tahmini_hasat_tarihi = @EstimatedHarvestDate, 
                               not = @Note, durum = @Status WHERE id = @Id";
                connection.Execute(sql, plant);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM bitkiler WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}