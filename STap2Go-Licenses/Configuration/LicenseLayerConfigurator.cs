using STap2Go_Licenses.Context;

namespace STap2Go_Licenses.Configuration;

public static class LicenseLayerConfigurator
{
    public static void Configure(IServiceCollection services)
    {
        // AutoMapper configuration
        services.AddAutoMapper(typeof(LicensesMapperConfig));
        // Configure licenses database context
        services.AddDbContext<LicensesContext>();
    }
}