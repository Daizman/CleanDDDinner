using System.Net;

namespace CleanDDDinner.Application.Error;

public class UserWithEmailNotExistsException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "User with given email does not exists.";
}