using System.ComponentModel.DataAnnotations;

namespace RealEstate.DTO
{
    public class DelegateRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        public string code { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string address { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Commission percent is required.")]
        public string commissionPercent { get; set; }
    }
}
