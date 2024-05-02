using FluentValidation;
using Arcana.WebApi.Models.UserRoles;

namespace Arcana.WebApi.Validators.UserRoles;

public class UserRoleUpdateModelValidator : AbstractValidator<UserRoleUpdateModel>
{
    public UserRoleUpdateModelValidator()
    {
        RuleFor(userRole => userRole.Name)
            .NotNull()
            .WithMessage(userRole => $"{nameof(userRole.Name)} is not specified");
    }
}