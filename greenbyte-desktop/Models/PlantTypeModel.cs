using System;

namespace GreenByte.Models
{
    public class PlantModel
    {
        public int Id { get; set; }
        public int GreenhouseId { get; set; }
        public int PlantTypeId { get; set; }
        public string AreaCode { get; set; }
        public DateTime SowingDate { get; set; }
        public float GrowthPercentage { get; set; }
        public DateTime? EstimatedHarvestDate { get; set; }
        public string Note { get; set; }
        public string Status { get; set; } // active, harvested, cancelled
        public DateTime LastUpdate { get; set; }
    }
}