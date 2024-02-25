using CleanDDDinner.Domain.Common.Models;

namespace CleanDDDinner.Domain.HostAggregate.ValueObjects;

public class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique() => new(Guid.NewGuid());
    public static HostId Create(string value) => new(Guid.Parse(value));

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}