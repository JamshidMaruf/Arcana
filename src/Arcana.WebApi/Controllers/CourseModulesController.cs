using Microsoft.AspNetCore.Mvc;
using Arcana.WebApi.Models.Commons;
using Arcana.Service.Configurations;
using Arcana.WebApi.Models.CourseModules;
using Arcana.WebApi.ApiServices.CourseModules;

namespace Arcana.WebApi.Controllers;

public class CourseModulesController(ICourseModuleApiService courseModuleApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(CourseModuleCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await courseModuleApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, CourseModuleUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await courseModuleApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await courseModuleApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await courseModuleApiService.GetAsync(id)
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
            Data = await courseModuleApiService.GetAsync(@params, filter, search)
        });
    }
}