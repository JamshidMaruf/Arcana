using FluentValidation;
using Arcana.WebApi.Models.UserRoles;

namespace Arcana.WebApi.Validators.UserRoles;

public class UserRoleCreateModelValidator : AbstractValidator<UserRoleCreateModel>
{
    public UserRoleCreateModelValidator()
    {
        RuleFor(userRole => userRole.Name)
            .NotNull()
            .WithMessage(userRole => $"{nameof(userRole.Name)} is not specified");
    }
}