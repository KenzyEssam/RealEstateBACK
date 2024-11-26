using System.ComponentModel.DataAnnotations;

namespace RealEstate.DTO
{
    public class CategoryRequest
    {
        [Required]
        public string InvestmentType { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string CategoryCode { get; set; }
    }
}
