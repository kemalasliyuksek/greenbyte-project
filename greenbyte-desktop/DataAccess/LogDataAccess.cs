using Dapper;
using GreenByte.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class LogDataAccess
    {
        public static void Add(LogModel log)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "INSERT INTO log_kayitlari (kullanici_id, log_tipi, mesaj, log_zamani) VALUES (@KullaniciId, @LogTipi, @Mesaj, @LogZamani)";

                var parameters = new DynamicParameters();
                parameters.Add("@KullaniciId", log.UserId);
                parameters.Add("@LogTipi", log.LogType.ToString());
                parameters.Add("@Mesaj", log.Message);
                parameters.Add("@LogZamani", log.LogTime);

                connection.Execute(sql, parameters);
            }
        }

        public List<LogModel> GetAll()
        {
            try
            {
                using (var connection = DBContext.GetConnection())
                {
                    string sql = "SELECT id AS Id, kullanici_id AS UserId, log_tipi AS LogType, mesaj AS Message, log_zamani AS LogTime FROM log_kayitlari";
                    return connection.Query<LogModel>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log kayıtlarını çekerken bir hata oluştu: " + ex.Message);
                return new List<LogModel>();
            }
        }

        public List<LogModel> GetByKullaniciId(int kullaniciId)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, kullanici_id AS KullaniciId, log_tipi AS LogTipi, mesaj AS Mesaj, log_zamani AS LogZamani FROM log_kayitlari WHERE kullanici_id = @KullaniciId";
                return connection.Query<LogModel>(sql, new { KullaniciId = kullaniciId }).ToList();
            }
        }

        // Kullanıcıları Veritabanından Getirme
        public List<UserModel> GetAllUsers()
        {
            try
            {
                using (var connection = DBContext.GetConnection())
                {
                    string sql = "SELECT id AS Id, kullanici_adi AS Username FROM kullanicilar";
                    return connection.Query<UserModel>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kullanıcıları çekerken bir hata oluştu: " + ex.Message);
                return new List<UserModel>();
            }
        }
    }
}