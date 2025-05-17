using System;

namespace GreenByte.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public int Sera_Id { get; set; }
        public string Baslik { get; set; }
        public string Mesaj { get; set; }
        public string Tur { get; set; }
        public bool Okundu { get; set; }
        public DateTime Olusturma_Zamani { get; set; }

        // Renk için yardımcı metot
        public System.Drawing.Color GetColor()
        {
            switch (Tur?.ToLower())
            {
                case "warning":
                    return System.Drawing.Color.LightYellow;
                case "error":
                    return System.Drawing.Color.LightPink;
                case "success":
                    return System.Drawing.Color.LightGreen;
                case "info":
                    return System.Drawing.Color.LightBlue;
                default:
                    return System.Drawing.Color.White;
            }
        }
    }
}