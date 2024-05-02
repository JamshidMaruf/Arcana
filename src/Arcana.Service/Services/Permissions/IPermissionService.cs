using Arcana.Domain.Entities.Users;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.Permissions;

public interface IPermissionService
{
    ValueTask<Permission> CreateAsync(Permission permission);
    ValueTask<Permission> UpdateAsync(long id, Permission permission);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Permission> GetByIdAsync(long id);
    ValueTask<IEnumerable<Permission>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}