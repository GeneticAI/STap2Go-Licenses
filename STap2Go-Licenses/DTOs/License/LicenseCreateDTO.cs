using System.ComponentModel.DataAnnotations;

namespace STap2Go_Licenses.DTOs.License
{
    public record LicenseCreateDTO
    {
        [Required]
        public string ClientId { get; set; } = String.Empty;
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public int? ProductId { get; set; }
    }
}
