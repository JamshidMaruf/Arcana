using Arcana.Domain.Entities.Users;
using Arcana.Service.Configurations;
using Arcana.Service.Services.RolePermissions;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.RolePermissions;
using Arcana.WebApi.Validators.RolePermissions;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.RolePermissions;

public class RolePermissionApiService(
    IMapper mapper,
    IRolePermissionService rolePermissionService,
    RolePermissionCreateModelValidator createValidator) : IRolePermissionApiService
{
    public async ValueTask<RolePermissionViewModel> PostAsync(RolePermissionCreateModel createModel)
    {
        await createValidator.EnsureValidatedAsync(createModel);
        var mappedRolePermission = mapper.Map<RolePermission>(createModel);
        var createdRolePermission = await rolePermissionService.CreateAsync(mappedRolePermission);
        return mapper.Map<RolePermissionViewModel>(createdRolePermission);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await rolePermissionService.DeleteAsync(id);
    }

    public async ValueTask<RolePermissionViewModel> GetAsync(long id)
    {
        var rolePermission = await rolePermissionService.GetByIdAsync(id);
        return mapper.Map<RolePermissionViewModel>(rolePermission);
    }

    public async ValueTask<IEnumerable<RolePermissionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var rolePermissions = await rolePermissionService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<RolePermissionViewModel>>(rolePermissions);
    }
}