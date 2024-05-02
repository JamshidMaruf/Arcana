using Arcana.Service.Configurations;
using Arcana.WebApi.Models.Permissions;

namespace Arcana.WebApi.ApiServices.Permissions;

public interface IPermissionApiService
{
    ValueTask<PermissionViewModel> PostAsync(PermissionCreateModel createModel);
    ValueTask<PermissionViewModel> PutAsync(long id, PermissionUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<PermissionViewModel> GetAsync(long id);
    ValueTask<IEnumerable<PermissionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
