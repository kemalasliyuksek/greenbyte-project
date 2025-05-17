using System;

namespace GreenByte.Models
{
    public class PlantTypeModel
    {
        public int Id { get; set; } // Bitki türü ID'si
        public string TypeName { get; set; } // Bitki türü adı
        public float? MinTemperature { get; set; } // Minimum sıcaklık
        public float? MaxTemperature { get; set; } // Maksimum sıcaklık
        public float? MinHumidity { get; set; } // Nem oranı
        public float? MaxHumidity { get; set; } // Maksimum nem oranı
        public float? MinDailyLightHours { get; set; } // Gün içindeki en düşük ışık saati
        public float? MaxDailyLightHours { get; set; } // Gün içindeki en yüksek ışık saati
        public int? MinLightIntensity { get; set; } // En düşük ışık şiddeti
        public int? MaxLightIntensity { get; set; } // En yüksek ışık şiddeti
        public float? MinSoilMoisture { get; set; } // En düşük toprak nemi
        public float? MaxSoilMoisture { get; set; } // En yüksek toprak nemi
        public int? IrrigationFrequency { get; set; } // Sulama sıklığı
        public int? GrowingPeriod { get; set; } // Yetişme süresi
        public string Notes { get; set; } // Notlar
        public DateTime AddedDate { get; set; } // Eklendiği tarih  
    }
}