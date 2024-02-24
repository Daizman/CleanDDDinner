using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.Host.ValueObjects;

namespace CleanDDDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private Host(HostId id) : base(id)
    {
    }

    public static Host Create() => new(HostId.CreateUnique());
}