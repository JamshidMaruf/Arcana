using Arcana.Service.Services.Permissions;
using Arcana.Service.Services.RolePermissions;
using Arcana.Service.Services.UserRoles;
using Arcana.Service.Services.Users;

namespace Arcana.WebApi.Helpers;

public static class InjectHelper
{
    public static IUserService UserService;
    public static IUserRoleService UserRoleService;
    public static IPermissionService PermissionService;
    public static IRolePermissionService RolePermissionService;
}
