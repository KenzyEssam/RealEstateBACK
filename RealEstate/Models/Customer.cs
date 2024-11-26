using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models
{
    public class Customer
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string phoneNumber1 { get; set; }
        public string? phoneNumber2 { get; set; }
        public string? phoneNumber3 { get; set; }
        public string email { get; set; }
        public string address1 { get; set; }
        public string relativesPhoneNumber { get; set; }
        public string relatedDelegates { get; set; }
        public string relatedUnit { get; set; }
        public string? FilePath { get; set; }
        public string? FileName { get; set; }

    }
}
