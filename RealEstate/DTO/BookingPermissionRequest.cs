using System.ComponentModel.DataAnnotations;

namespace RealEstate.DTO
{
    public class BookingPermissionRequest
    {

        [Required]
        public string ClientCode { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Delegate { get; set; }

        [Required]
        public string PaymentPlan { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public decimal UnitValue { get; set; }

        [Required]
        public string BookingType { get; set; }

        [Required]
        public string ValidityPeriod { get; set; }
    }
}
