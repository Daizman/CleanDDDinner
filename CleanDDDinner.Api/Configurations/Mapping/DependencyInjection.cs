namespace CleanDDDinner.Api.Configurations.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddMaps(typeof(DependencyInjection).Assembly);
        });
        return services;
    }
}