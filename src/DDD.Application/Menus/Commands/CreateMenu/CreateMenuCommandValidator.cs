using FluentValidation;

namespace DDD.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.HostId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleForEach(x => x.Sections).NotEmpty();
    }
}