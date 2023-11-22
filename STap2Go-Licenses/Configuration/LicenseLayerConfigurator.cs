namespace STap2Go_Licenses.Configuration;

public static class LicenseLayerConfigurator
{
    public static void Configure(IServiceCollection services)
    {
        // AutoMapper configuration
        services.AddAutoMapper(typeof(LicensesMapperConfig));
    }
}