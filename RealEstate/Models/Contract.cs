using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string unit { get; set; }

        [Required]
        public string client { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public decimal rentalValue { get; set; }

        [Required]
        public decimal deposit { get; set; }

        [Required]
        public decimal insuranceValue { get; set; }

        [Required]
        public DateTime rentalEndDate { get; set; }

        [Required]
        public DateTime rentalStartDate { get; set; }
    }
}
