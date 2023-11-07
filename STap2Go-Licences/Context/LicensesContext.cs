
using Microsoft.EntityFrameworkCore;
using STap2Go_Licenses.Entities;

namespace STap2Go_Licenses.Context
{
	public class LicensesContext : DbContext
	{
		public LicensesContext(DbContextOptions<LicensesContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<License> Licenses { get; set; }
	}
}
