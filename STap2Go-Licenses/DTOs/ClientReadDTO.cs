using System.Text.Json.Serialization;

namespace STap2Go_Licenses.DTOs;

public record ClientReadDTO
{
    [JsonPropertyName("IdCliente")]
    public int Id { get; set; }
    [JsonPropertyName("EmailCliente")]
    public string Email { get; set; }
    [JsonPropertyName("NombreContacto")]
    public string FirstName { get; set; }
    [JsonPropertyName("ApellidoContacto")]
    public string LastName { get; set; }
    [JsonPropertyName("EsEmpresa")]
    public bool IsCompany { get; set; }
    [JsonPropertyName("NIFContacto")]
    public string ContactNIF { get; set; }
    [JsonPropertyName("NombreEmpresa")]
    public string CompanyName{ get; set; }
    [JsonPropertyName("NIFEmpresa")]
    public string CompanyNIF { get; set; }
    [JsonPropertyName("Direccion1")]
    public string Address1 { get; set; }
    [JsonPropertyName("Direccion2")]
    public string Address2 { get; set; }
    [JsonPropertyName("CodigoPostal")]
    public string PostalCode { get; set; }
    [JsonPropertyName("Provincia")]
    public string Province { get; set; }
    [JsonPropertyName("Ciudad")]
    public string City { get; set; }
    [JsonPropertyName("Pais")]
    public string Country { get; set; }
}