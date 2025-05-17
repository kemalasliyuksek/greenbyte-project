using System;

namespace GreenByte.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public int GreenhouseId { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float WindSpeed { get; set; }
        public bool IsRaining { get; set; }
        public string WeatherDescription { get; set; }
        public DateTime RecordTime { get; set; }
    }
}