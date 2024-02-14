using System.Net;

namespace CleanDDDinner.Application.Error;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}