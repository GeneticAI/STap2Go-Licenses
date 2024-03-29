﻿namespace STap2Go_Licenses.DTOs.License
{
    public class LicenseReadDTO
    {
        public int LicenseId { get; set; }
        public string ClientId { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string LicenseCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public DateTime? UsageDate { get; set; }
    }
}
