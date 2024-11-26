using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    public class BookingPermission
    {
        [Key]
        public int Id { get; set; }

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
