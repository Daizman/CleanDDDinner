using CleanDDDinner.Domain.Common.Models;

namespace CleanDDDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public float Value { get; }

    private Rating(float value) => Value = value;

    public static Rating Create(float rating = 0)
        => new(rating);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}