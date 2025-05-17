using System;
using Dapper;
using MySql.Data.MySqlClient;
namespace GreenByte.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int GreenhouseId { get; set; }


        // ToString metodu, ComboBox'ta doğru görünmesi için
        public override string ToString()
        {
            return Username;
        }
    }

    
        public static class CurrentUser
        {
            public static int Id { get; set; }
            public static UserModel User { get; set; }
            public static bool RememberMe { get; set; }
        }
    

}