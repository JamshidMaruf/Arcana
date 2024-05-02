using FluentValidation;
using Arcana.WebApi.Models.RolePermissions;
using Arcana.Domain.Entities.Users;

namespace Arcana.WebApi.Validators.RolePermissions;

public class RolePermissionCreateModelValidator : AbstractValidator<RolePermissionCreateModel>
{
    public RolePermissionCreateModelValidator()
    {
        RuleFor(rolePermission => rolePermission.RoleId)
            .NotNull()
            .WithMessage(rolePermission => $"{nameof(rolePermission.RoleId)} is not specified");

        RuleFor(rolePermission => rolePermission.PermissionId)
            .NotNull()
            .WithMessage(rolePermission => $"{nameof(rolePermission.PermissionId)} is not specified");
    }
}