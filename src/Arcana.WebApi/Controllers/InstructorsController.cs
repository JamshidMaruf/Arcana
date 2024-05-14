using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.Instructors;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.Instructors;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class InstructorsController(IInstructorApiService instructorApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(InstructorCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await instructorApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, InstructorUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await instructorApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await instructorApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await instructorApiService.GetAsync(id)
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
            Data = await instructorApiService.GetAsync(@params, filter, search)
        });
    }

    [HttpPost("{id:long}/pictures/upload")]
    public async ValueTask<IActionResult> UploadPictureAsync(long id, IFormFile file)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await instructorApiService.UploadPictureAsync(id, file)
        });
    }

    [HttpPost("{id:long}/pictures/delete")]
    public async ValueTask<IActionResult> DeletePictureAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await instructorApiService.DeletePictureAsync(id)
        });
    }
}
