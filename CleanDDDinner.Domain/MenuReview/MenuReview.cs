using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.MenuReview.ValueObjects;

namespace CleanDDDinner.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    private MenuReview(MenuReviewId id) : base(id)
    {
    }

    public static MenuReview Create() => new(MenuReviewId.CreateUnique());
}