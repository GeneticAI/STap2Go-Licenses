using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace STap2Go_Licenses.Entities
{
	[Table("licenciastest")]
	public record License
	{
		[Key]
		[Column("IdLicencia")]
		public int Id { get; set; }
		[Column("IdCliente")]
		[ForeignKey("Client")]
		public int ClientId { get; set; }
		[Column("Licencia")]
		public string? LicenseCode { get; set; }
		[Column("Estado")]
		public string? Status { get; set; }
		[Column("FechaCreacion")]
		public DateTime CreationDate { get; set; }
		[Column("FechaAsignacion")]
		public DateTime? AssignmentDate { get; set; }
		[Column("FechaUso")]
		public DateTime? UsageDate { get; set; }
		[ForeignKey("Product")]
		public int ProductId { get; set; }
		public string? Metadata { get; set; }
		
		[JsonIgnore]
		public virtual Client? Client { get; set; }
		[JsonIgnore]
		public virtual Product? Product { get; set; }

		public License toDto()
		{
			return new License()
			{
				Id = this.Id,
				ClientId = this.ClientId,
				LicenseCode = this.LicenseCode,
				Status = this.Status,
				CreationDate = this.CreationDate,
				AssignmentDate = this.AssignmentDate,
				UsageDate = this.UsageDate,
				ProductId = this.ProductId,
				Metadata = this.Metadata
			};
		}
	}
}
