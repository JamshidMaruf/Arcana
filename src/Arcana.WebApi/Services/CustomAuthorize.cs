using Arcana.Service.Exceptions;
using Arcana.Service.Services.Permissions;
using Arcana.Service.Services.RolePermissions;
using Arcana.Service.Services.UserRoles;
using Arcana.Service.Services.Users;
using Arcana.WebApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Arcana.WebApi.Services;

public class CustomAuthorize : Attribute, IAuthorizationFilter
{
    private readonly IUserService userService;
    private readonly IUserRoleService userRoleService;
    private readonly IPermissionService permissionService;
    private readonly IRolePermissionService rolePermissionService;
    public CustomAuthorize()
    {
        userService = InjectHelper.UserService;
        userRoleService = InjectHelper.UserRoleService;
        permissionService = InjectHelper.PermissionService;
        rolePermissionService = InjectHelper.RolePermissionService;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(authorizationHeader))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }
            
        var actionDescriptor = context.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
        var action = actionDescriptor.ActionName;
        var controller = actionDescriptor.ControllerName;
        var userId = Convert.ToInt64(context.HttpContext?.User?.FindFirst("Id")?.Value);

        var user = userService.GetByIdAsync(Convert.ToInt64(userId))
            .ConfigureAwait(true)
            .GetAwaiter()
            .GetResult();

        var rolePermissions = rolePermissionService.GetAllByRoleIdAsync(user.RoleId)
            .ConfigureAwait(true)
            .GetAwaiter()
            .GetResult();

        foreach (var rolePermission in rolePermissions)
        {
            if (!(rolePermission.Permission.Action == action && rolePermission.Permission.Controller == controller))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }
        }
    }
}