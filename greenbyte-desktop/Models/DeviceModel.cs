using System;

namespace GreenByte.Models
{
    public class Device
    {
        public int Id { get; set; }
        public int GreenhouseId { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }
    }
}