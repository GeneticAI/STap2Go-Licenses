using System.ComponentModel.DataAnnotations;

namespace STap2Go_Licenses.Entities;

public record Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}