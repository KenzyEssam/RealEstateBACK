using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string InvestmentType { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string CategoryCode { get; set; }
    }
}
