using System.ComponentModel.DataAnnotations;

namespace RealEstate.DTO
{
    public class InvestmentUnitRequest
    {
        [Required]
        public string UnitCode { get; set; }

        [Required]
        public string UnitDescription { get; set; }

        [Required]
        public string LowestCategory { get; set; }

        [Required]
        public decimal UnitArea { get; set; }

        [Required]
        public decimal PricePerMeter { get; set; }

        [Required]
        public decimal TotalUnitValue { get; set; }

        [Required]
        public decimal MaintenancePercentage { get; set; }

        [Required]
        public decimal MaintenanceValue { get; set; }
    }
}
