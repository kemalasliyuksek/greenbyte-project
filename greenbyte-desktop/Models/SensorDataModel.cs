using System;

public class SensorData
{
    public int Id { get; set; }
    public int SensorId { get; set; }
    public string SensorName { get; set; }  // Bu özelliği ekleyin
    public decimal Value { get; set; }
    public DateTime RecordTime { get; set; }
}