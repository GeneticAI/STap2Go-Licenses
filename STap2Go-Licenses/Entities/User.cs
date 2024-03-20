namespace STap2Go_Licenses.Entities
{
    public record User
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool? IsCompany { get; set; }
        public string? ContactNIF { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyNIF { get; set; }
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
