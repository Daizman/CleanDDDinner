using System.Net;

namespace CleanDDDinner.Application.Error;

public sealed class InvalidPasswordException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Invalid password.";
}