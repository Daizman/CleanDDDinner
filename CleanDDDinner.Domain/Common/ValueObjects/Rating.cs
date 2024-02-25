using CleanDDDinner.Domain.Common.Models;

namespace CleanDDDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public double Value { get; }
    
    private Rating(double value) => Value = value;

    public static Rating Create(double rating = 0)
        => new(rating);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}