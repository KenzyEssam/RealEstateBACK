namespace RealEstate.DTO
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? PhoneNumber3 { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string RelativesPhoneNumber { get; set; }
        public string RelatedDelegates { get; set; }
        public string RelatedUnit { get; set; }
        public IFormFile? Attachments { get; set; }
    }
}
