using System.Text;
using CleanDDDinner.Application.Interfaces.Authentication;
using CleanDDDinner.Application.Interfaces.Persistence;
using CleanDDDinner.Application.Interfaces.Services;
using CleanDDDinner.Infrastructure.Authentication;
using CleanDDDinner.Infrastructure.Persistence;
using CleanDDDinner.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CleanDDDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistence();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }

    private static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        JwtSettings jwtSettings = new();
        configuration.Bind(nameof(JwtSettings), jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });

        services.AddAuthorization();

        return services;
    }
}