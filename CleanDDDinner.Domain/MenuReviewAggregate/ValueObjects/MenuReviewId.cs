﻿using CleanDDDinner.Domain.Common.Models;

namespace CleanDDDinner.Domain.MenuReviewAggregate.ValueObjects;

public class MenuReviewId : ValueObject
{
    public Guid Value { get; }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}