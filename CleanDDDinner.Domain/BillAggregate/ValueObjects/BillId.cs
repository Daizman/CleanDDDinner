using CleanDDDinner.Domain.Common.Models;

namespace CleanDDDinner.Domain.BillAggregate.ValueObjects;

public sealed class BillId : ValueObject
{
    public Guid Value { get; }
    public DateTime ArrivalDateTime { get; private set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private BillId(
        Guid value,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        Value = value;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static BillId CreateUnique() => new(
        Guid.NewGuid(),
        DateTime.UtcNow,
        DateTime.UtcNow);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}