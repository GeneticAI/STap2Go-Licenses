
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
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot configuration = new ConfigurationBuilder()
					.AddJsonFile("appsettings.licenses.json")
					.Build();
				var connectionString = configuration.GetConnectionString("Default");
				optionsBuilder
					.UseLazyLoadingProxies()
					.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

			}

		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<License> Licenses { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
