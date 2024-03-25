using System.ComponentModel.DataAnnotations;

namespace STap2Go_Licenses.DTOs.License
{
    public class TestLicenseReserveDTO
    {
        [Required]
        public string TargetEmail { get; set; } = string.Empty;
    }
}
