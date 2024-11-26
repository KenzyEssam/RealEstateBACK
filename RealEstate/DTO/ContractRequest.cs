using System.ComponentModel.DataAnnotations;

namespace RealEstate.DTO
{
    public class ContractRequest
    {
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
