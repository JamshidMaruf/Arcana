using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Users;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.RolePermissions;

public class RolePermissionService(IUnitOfWork unitOfWork) : IRolePermissionService
{
    public async ValueTask<RolePermission> CreateAsync(RolePermission rolePermission)
    {
        var existUserRole = await unitOfWork.UserRoles.SelectAsync(ur => ur.Id == rolePermission.RoleId)
            ?? throw new NotFoundException($"User Role not found with this ID={rolePermission.RoleId}");

        var existPermission = await unitOfWork.Permissions.SelectAsync(p => p.Id == rolePermission.PermissionId)
            ?? throw new NotFoundException($"Permission not found with this ID={rolePermission.PermissionId}");

        var existRolePermission = await unitOfWork.RolePermissions
            .SelectAsync(rp =>
                rp.PermissionId == rolePermission.PermissionId && rp.RoleId == rolePermission.RoleId && !rp.IsDeleted);

        if (existRolePermission is not null)
            throw new AlreadyExistException($"Role permission is already exists" +
                $"RoleId={rolePermission.RoleId}, PermissionId={rolePermission.PermissionId}");

        rolePermission.CreatedByUserId = HttpContextHelper.UserId;

        var createdRolePermission = await unitOfWork.RolePermissions.InsertAsync(rolePermission);
        createdRolePermission.Permission = existPermission;
        createdRolePermission.Role = existUserRole;
        await unitOfWork.SaveAsync();

        return createdRolePermission;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existRolePermission = await unitOfWork.RolePermissions.SelectAsync(rp => rp.Id == id && !rp.IsDeleted)
            ?? throw new NotFoundException($"Role permission is not found with this ID={id}");

        existRolePermission.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.RolePermissions.DeleteAsync(existRolePermission);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<RolePermission>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var rolePermissions = unitOfWork.RolePermissions
            .SelectAsQueryable(expression: rp => !rp.IsDeleted, includes: ["Role", "Permission"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            rolePermissions = rolePermissions.Where(rp =>
                rp.Role.Name.ToLower().Contains(search.ToLower()) ||
                rp.Permission.Action.ToLower().Contains(search.ToLower()) ||
                rp.Permission.Controller.ToLower().Contains(search.ToLower()));

        return await rolePermissions.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<RolePermission> GetByIdAsync(long id)
    {
        var existRolePermission = await unitOfWork.RolePermissions
            .SelectAsync(expression: rp => rp.Id == id && !rp.IsDeleted, includes: ["Role", "Permission"])
            ?? throw new NotFoundException($"Role permission is not found with this ID={id}");

        return existRolePermission;
    }

    public async ValueTask<IEnumerable<RolePermission>> GetAllByRoleIdAsync(long roleId)
    {
        return await unitOfWork.RolePermissions
            .SelectAsEnumerableAsync(expression: rp => rp.RoleId == roleId, includes: ["Role", "Permission"]);
    }

    public bool CheckRolePermission(string role, string action, string controller)
    {
        var rolePermissions = unitOfWork.RolePermissions.SelectAsQueryable(expression: rp =>
            rp.Role.Name.ToLower() == role.ToLower() &&
            rp.Permission.Action.ToLower() == action.ToLower() &&
            rp.Permission.Controller.ToLower() == controller.ToLower(), isTracked: false).ToList();

        if (rolePermissions.Any()) return true;

        return false;
    }
}