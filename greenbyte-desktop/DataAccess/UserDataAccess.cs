using Dapper;
using MySql.Data.MySqlClient;
using GreenByte.Models;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class UserDataAccess
    {
        public List<UserModel> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, kullanici_adi AS Username, sifre AS Password, email AS Email, kayit_tarihi AS RegistrationDate, sera_id AS GreenhouseId FROM kullanicilar";
                return connection.Query<UserModel>(sql).ToList();
            }
        }

        public UserModel GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id,  kullanici_adi AS Username, sifre AS Password, email AS Email, kayit_tarihi AS RegistrationDate, sera_id AS GreenhouseId FROM kullanicilar WHERE id = @Id";
                return connection.QueryFirstOrDefault<UserModel>(sql, new { Id = id });
            }
        }

        public void Add(UserModel user)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "INSERT INTO kullanicilar (kullanici_adi, sifre, email, kayit_tarihi, sera_id) VALUES (@Username, @Password, @Email, @RegistrationDate, @GreenhouseId)";
                connection.Execute(sql, user);
            }
        }

        public void Update(UserModel user)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "UPDATE kullanicilar SET kullanici_adi = @Username, sifre = @Password, email = @Email WHERE id = @Id";
                connection.Execute(sql, user);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM kullanicilar WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}