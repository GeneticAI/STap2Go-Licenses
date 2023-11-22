using System.Text.Json.Serialization;

namespace STap2Go_Licenses.DTOs;

public record LicenseCreateDTO
{
    [JsonPropertyName("IdCliente")]
    public int ClientId { get; set; }
    [JsonPropertyName("Cantidad")]
    public int Quantity { get; set; }
}