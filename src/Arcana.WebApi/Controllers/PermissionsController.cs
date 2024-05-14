using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.Permissions;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.Permissions;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class PermissionsController(IPermissionApiService permissionApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(PermissionCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await permissionApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, PermissionUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await permissionApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await permissionApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await permissionApiService.GetAsync(id)
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync(
        [FromQuery] PaginationParams @params,
        [FromQuery] Filter filter,
        [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await permissionApiService.GetAsync(@params, filter, search)
        });
    }
}