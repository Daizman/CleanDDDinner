using System.Net;

namespace CleanDDDinner.Application.Error;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "User with given email already exists.";
}