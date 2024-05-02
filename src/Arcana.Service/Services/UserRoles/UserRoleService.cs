using Arcana.Service.Helpers;
using Arcana.Service.Extensions;
using Arcana.Service.Exceptions;
using Arcana.Domain.Entities.Users;
using Arcana.Service.Configurations;
using Arcana.DataAccess.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.UserRoles;

public class UserRoleService(IUnitOfWork unitOfWork) : IUserRoleService
{
    public async ValueTask<UserRole> CreateAsync(UserRole userRole)
    {
        var existRole = await unitOfWork.UserRoles.SelectAsync(role => role.Name.ToLower() == userRole.Name.ToLower());
        if (existRole is not null)
            throw new AlreadyExistException("This role already exists");

        userRole.CreatedByUserId = HttpContextHelper.UserId;
        var createdUserRole = await unitOfWork.UserRoles.InsertAsync(userRole);
        await unitOfWork.SaveAsync();

        return createdUserRole;
    }

    public async ValueTask<UserRole> UpdateAsync(long id, UserRole userRole)
    {
        var existRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"Role is not found with this ID={id}");

        var alreadyExistUserRole = await unitOfWork.UserRoles.SelectAsync(role => role.Name.ToLower() == userRole.Name.ToLower());
        if (alreadyExistUserRole is not null)
            throw new AlreadyExistException("This role already exists");

        existRole.Name = userRole.Name;
        existRole.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.UserRoles.UpdateAsync(userRole);
        await unitOfWork.SaveAsync();

        return existRole;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"Role is not found with this ID={id}");

        await unitOfWork.UserRoles.DropAsync(existRole);
        return true;
    }

    public async ValueTask<UserRole> GetByIdAsync(long id)
    {
        var existRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"Role is not found with this ID={id}");

        return existRole;
    }

    public async ValueTask<IEnumerable<UserRole>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var userRoles = unitOfWork.UserRoles.SelectAsQueryable().OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            userRoles = userRoles.Where(role => role.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

        return await userRoles.ToPaginateAsQueryable(@params).ToListAsync();
    }
}