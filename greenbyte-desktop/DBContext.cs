using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace GreenByte
{
    public static class DBContext
    {
        private static readonly string connectionString;

        // Static constructor without access modifier  
        static DBContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["GreenByteDB"].ConnectionString;
        }

        public static MySqlConnection GetConnection()
        {
            try
            {
                return new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Veritabanı bağlantısı oluşturulamadı: " + ex.Message);
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }

    
}
