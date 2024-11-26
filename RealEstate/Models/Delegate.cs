using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    public class Delegate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public string phoneNumber { get; set; }

        public string address { get; set; }

        public string commissionPercent { get; set; }
    }
}
