using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.InstructorStars;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.InstructorStars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class InstructorStarsController(IInstructorStarApiService instructorStarApiService) : BaseController
{
    [HttpPost]
    [AllowAnonymous]
    public async ValueTask<IActionResult> PostAsync(InstructorStarCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await instructorStarApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, InstructorStarUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await instructorStarApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await instructorStarApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await instructorStarApiService.GetAsync(id)
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
            Data = await instructorStarApiService.GetAsync(@params, filter, search)
        });
    }
}