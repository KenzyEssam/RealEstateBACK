using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    public class InvestmentUnit
    {
        [Key]
        public int Id { get; set; }

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
