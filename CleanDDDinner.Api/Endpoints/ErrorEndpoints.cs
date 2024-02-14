using CleanDDDinner.Application.Error;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanDDDinner.Api.Endpoints;

public static class ErrorEndpoints
{
    public static void MapErrorEndpoints(this IEndpointRouteBuilder app)
    {
        app.Map("/error", async context =>
        {
            var pds = context.RequestServices.GetRequiredService<IProblemDetailsService>();
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            var (statusCode, msg) = exception switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unhandled error occurred.")
            };

            ProblemDetailsContext problemContext = new()
            {
                HttpContext = context,
                Exception = exception,
                ProblemDetails = new()
                {
                    Status = statusCode,
                    Title = msg,
                    Extensions = new Dictionary<string, object?>
                    {
                        { "inner", exception?.InnerException }
                    }
                }
            };

            if (!await pds.TryWriteAsync(problemContext))
            {
                await context.Response.WriteAsync("Fallback: An error occurred.");
            }
        });
    }
}