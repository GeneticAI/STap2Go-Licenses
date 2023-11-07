using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace STap2Go_Licenses.Context
{
	public class LicensesContextFactory : IDesignTimeDbContextFactory<LicensesContext>
	{

		public LicensesContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration =
				new ConfigurationBuilder().AddJsonFile("appsettings.licenses.json").Build();
			var builder = new DbContextOptionsBuilder<LicensesContext>();
			var connectionString = configuration.GetConnectionString("Default");

			builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			return new LicensesContext(builder.Options);
		}
	}
}
