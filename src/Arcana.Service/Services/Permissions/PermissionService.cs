using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Users;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.Permissions;

public class PermissionService(IUnitOfWork unitOfWork) : IPermissionService
{
    public async ValueTask<Permission> CreateAsync(Permission permission)
    {
        var existPermission = await unitOfWork.Permissions.SelectAsync(p =>
            p.Action.ToLower() == permission.Action.ToLower() &&
            p.Controller.ToLower() == permission.Controller.ToLower());

        if (existPermission is not null)
            throw new AlreadyExistException($"This permission already exists | Method={permission.Action} Controller={permission.Controller}");

        permission.CreatedByUserId = HttpContextHelper.UserId;
        var createdPermission = await unitOfWork.Permissions.InsertAsync(permission);
        await unitOfWork.SaveAsync();

        return createdPermission;
    }

    public async ValueTask<Permission> UpdateAsync(long id, Permission permission)
    {
        var existPermission = await unitOfWork.Permissions.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"Role is not found with this ID={id}");

        var alreadyExistPermission = await unitOfWork.Permissions.SelectAsync(p =>
           p.Action.ToLower() == permission.Action.ToLower() &&
           p.Controller.ToLower() == permission.Controller.ToLower());

        if (alreadyExistPermission is not null)
            throw new AlreadyExistException($"This permission already exists | Method={permission.Action} Controller={permission.Controller}");

        existPermission.Action = permission.Action;
        existPermission.Controller = permission.Controller;
        existPermission.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Permissions.UpdateAsync(permission);
        await unitOfWork.SaveAsync();

        return existPermission;
    }
    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existPermission = await unitOfWork.Permissions.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"Role is not found with this ID={id}");

        await unitOfWork.Permissions.DropAsync(existPermission);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<Permission> GetByIdAsync(long id)
    {
        var existPermission = await unitOfWork.Permissions.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"Role is not found with this ID={id}");

        return existPermission;
    }

    public async ValueTask<IEnumerable<Permission>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var permissions = unitOfWork.Permissions.SelectAsQueryable().OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            permissions = permissions.Where(role =>
                role.Action.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                role.Controller.Contains(search, StringComparison.OrdinalIgnoreCase));

        return await permissions.ToPaginateAsQueryable(@params).ToListAsync();
    }
}