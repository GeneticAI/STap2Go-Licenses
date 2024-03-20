
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STap2Go_Licenses.Entities;

namespace STap2Go_Licenses.Context
{
	public class LicensesContext : IdentityDbContext<User>
	{
		public LicensesContext(DbContextOptions<LicensesContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// License

			builder.Entity<Licenses>()
				.HasKey(l => l.LicenseId);

			builder.Entity<Licenses>()
				.HasOne(l => l.Client)
				.WithMany(c => c.Licenses)
				.HasForeignKey(l => l.ClientId);

			builder.Entity<Licenses>()
				.HasOne(l => l.Product)
				.WithMany(p => p.Licenses)
				.HasForeignKey(l => l.ProductId);
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

		// OLD ONES
		public DbSet<Client> Clients { get; set; }
		public DbSet<License> Licenses { get; set; }


        public DbSet<Licenses> License { get; set; }
        public DbSet<Product> Products { get; set; }
	}
}
