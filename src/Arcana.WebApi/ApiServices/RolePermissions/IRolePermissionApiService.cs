using Arcana.Service.Configurations;
using Arcana.WebApi.Models.RolePermissions;

namespace Arcana.WebApi.ApiServices.RolePermissions;

public interface IRolePermissionApiService
{
    ValueTask<RolePermissionViewModel> PostAsync(RolePermissionCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<RolePermissionViewModel> GetAsync(long id);
    ValueTask<IEnumerable<RolePermissionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}