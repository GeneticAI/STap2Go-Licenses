using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STap2Go_Licenses.Entities
{
	[Table("licenciastest")]
	public record License
	{
		[Key]
		[Column("IdLicencia")]
		public int Id { get; set; }
		[Column("IdCliente")]
		public int ClientId { get; set; }
		[Column("Licencia")]
		public string LicenseCode { get; set; }
		[Column("Estado")]
		public string Status { get; set; }
		[Column("FechaCreacion")]
		public DateTime CreationDate { get; set; }
		[Column("FechaAsignacion")]
		public DateTime? AssignmentDate { get; set; }
		[Column("FechaUso")]
		public DateTime? UsageDate { get; set; }

		[ForeignKey("ClientId")]
		public virtual Client Client { get; set; }
	}
}
