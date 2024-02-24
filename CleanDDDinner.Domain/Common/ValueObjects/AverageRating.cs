using CleanDDDinner.Domain.Common.Models;

namespace CleanDDDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    public double Value { get; private set; }
    public int NumRatings { get; private set; }

    private AverageRating(double value, int numRatings)
        => (Value, NumRatings) = (value, numRatings);

    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
        => new(rating, numRatings);

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
    }

    public void RemoveRating(Rating rating)
    {
        Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}