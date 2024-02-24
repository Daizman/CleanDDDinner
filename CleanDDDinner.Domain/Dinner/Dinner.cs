using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.Dinner.ValueObjects;

namespace CleanDDDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private Dinner(DinnerId id) : base(id)
    {
    }

    public static Dinner Create() => new(DinnerId.CreateUnique());
}