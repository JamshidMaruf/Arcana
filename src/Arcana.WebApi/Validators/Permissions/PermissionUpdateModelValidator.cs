using Arcana.WebApi.Models.Permissions;
using FluentValidation;

namespace Arcana.WebApi.Validators.Permissions;

public class PermissionUpdateModelValidator : AbstractValidator<PermissionUpdateModel>
{
    public PermissionUpdateModelValidator()
    {
        RuleFor(permission => permission.Action)
            .NotNull()
            .WithMessage(permission => $"{nameof(permission.Action)} is not specified");

        RuleFor(permission => permission.Controller)
            .NotNull()
            .WithMessage(permission => $"{nameof(permission.Controller)} is not specified");
    }
}