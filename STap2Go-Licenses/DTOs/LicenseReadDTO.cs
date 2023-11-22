using System.Text.Json.Serialization;

namespace STap2Go_Licenses.DTOs;

public record LicenseReadDTO
{
    [JsonPropertyName("IdLicencia")]
    public int Id { get; set; }
    [JsonPropertyName("IdCliente")]
    public int ClientId { get; set; }
    [JsonPropertyName("Licencia")]
    public string LicenseCode { get; set; }
    [JsonPropertyName("Estado")]
    public string Status { get; set; }
    [JsonPropertyName("FechaCreacion")]
    public DateTime CreationDate { get; set; }
    [JsonPropertyName("FechaAsignacion")]
    public DateTime? AssignmentDate { get; set; }
    [JsonPropertyName("FechaUso")]
    public DateTime? UsageDate { get; set; }
}