using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    public class RentalUnit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UnitCode { get; set; }

        [Required]
        public string UnitDescription { get; set; }

        [Required]
        public string UnitAddress { get; set; }

        [Required]
        public string LowestCategory { get; set; }

        [Required]
        public decimal RentalValue { get; set; }

        [Required]
        public string UnitContents { get; set; }

        [Required]
        public string RenterName { get; set; }

        [Required]
        public string RenterCode { get; set; }

        [Required]
        public string UnitStatus { get; set; }
    }
}
