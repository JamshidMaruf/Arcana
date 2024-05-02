using Arcana.WebApi.Models.Permissions;
using Arcana.WebApi.Models.UserRoles;

namespace Arcana.WebApi.Models.RolePermissions;

public class RolePermissionViewModel
{
    public long Id { get; set; }
    public UserRoleViewModel Role { get; set; }
    public PermissionViewModel Permission { get; set; }
}
