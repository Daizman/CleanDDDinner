namespace CleanDDDinner.Api.Endpoints;

public static class UseEndpointsExtension
{
    public static void UseEndpoints(this WebApplication app)
    {
        app.MapErrorEndpoints();
        app.MapAuthenticationEndpoints();
        app.MapDinnersEndpoints();
        app.MapMenuEndpoints();
    }
}