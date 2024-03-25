using System.ComponentModel.DataAnnotations;

namespace STap2Go_Licenses.DTOs.License
{
    public class LicenseReserveDTO
    {
        [Required]
        public string TargetEmail { get; set; } = string.Empty;
    }
}
