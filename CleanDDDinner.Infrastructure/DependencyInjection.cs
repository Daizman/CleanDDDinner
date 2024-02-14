using CleanDDDinner.Application.Interfaces.Authentication;
using CleanDDDinner.Application.Interfaces.Persistence;
using CleanDDDinner.Application.Interfaces.Services;
using CleanDDDinner.Infrastructure.Authentication;
using CleanDDDinner.Infrastructure.Persistence;
using CleanDDDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanDDDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
            
        return services;
    }
}