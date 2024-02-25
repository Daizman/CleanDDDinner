using FluentValidation;

namespace CleanDDDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(200);
        RuleFor(command => command.Description)
            .NotEmpty();
        RuleFor(command => command.Sections)
            .NotEmpty();
    }
}