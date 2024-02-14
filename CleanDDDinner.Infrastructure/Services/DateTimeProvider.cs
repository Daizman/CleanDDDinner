using CleanDDDinner.Application.Interfaces.Services;

namespace CleanDDDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}