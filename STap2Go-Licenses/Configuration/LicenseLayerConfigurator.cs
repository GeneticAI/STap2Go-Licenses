using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using STap2Go_Licenses.Context;
using STap2Go_Licenses.Entities;
using STap2Go_Licenses.Security;
using System.Text;

namespace STap2Go_Licenses.Configuration;

public static class LicenseLayerConfigurator
{
    public static void Configure(IServiceCollection services)
    {
        // AutoMapper configuration
        services.AddAutoMapper(typeof(LicensesMapperConfig));

        // Configure licenses database context
        services.AddDbContext<LicensesContext>()
            .AddIdentityCore<User>()
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole>();

        // Authentication configuration with Identity
        services.Configure<IdentityOptions>(opts =>
        {
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequireDigit = false;
            opts.Password.RequireUppercase = false;
            opts.Password.RequiredLength = 1;
            opts.User.RequireUniqueEmail = true;
        });
        services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromMinutes(10));

        // Authorization configuration with JWT and basic authentication
        IConfigurationRoot configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.licenses.json")
                    .Build();
        services
            .AddHttpContextAccessor()
            .AddAuthorization()
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            })
            .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("BasicAuthentication", null);
    }
}