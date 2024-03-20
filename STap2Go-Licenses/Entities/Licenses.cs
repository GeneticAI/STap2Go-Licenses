namespace STap2Go_Licenses.Entities
{
    public record Licenses
    {
        public int LicenseId { get; set; }
        public string? LicenseCode { get; set; }
        public string? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public DateTime? UsageDate { get; set; }
        public string? Metadata { get; set; }

        public string ClientId { get; set; } = string.Empty;

        public int ProductId { get; set; }
    }
}
