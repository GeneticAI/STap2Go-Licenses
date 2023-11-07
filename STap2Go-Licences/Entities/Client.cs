using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STap2Go_Licenses.Entities
{
	[Table("cliente")]
	public record Client
	{
		[Key]
		[Column("IdCliente")]
		public int Id { get; set; }
		[Column("EmailCliente")]
		public string Email { get; set; }
		[Column("NombreContacto")]
		public string FirstName { get; set; }
		[Column("ApellidoContacto")]
		public string LastName { get; set; }
		[Column("EsEmpresa")]
		public bool IsCompany { get; set; }
		[Column("NIFContacto")]
		public string ContactNIF { get; set; }
		[Column("NombreEmpresa")]
		public string CompanyName { get; set; }
		[Column("NIFEmpresa")]
		public string CompanyNIF { get; set; }
		[Column("Direccion1")]
		public string Address1 { get; set; }
		[Column("Direccion2")]
		public string Address2 { get; set; }
		[Column("CodigoPostal")]
		public string PostalCode { get; set; }
		[Column("Provincia")]
		public string Province { get; set; }
		[Column("Ciudad")]
		public string City { get; set; }
		[Column("Pais")]
		public string Country { get; set; }

		public virtual ICollection<License> Licenses { get; set; }
	}
}
