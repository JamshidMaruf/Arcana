using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.Students;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.Students;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class StudentsController(IStudentApiService studentApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(StudentCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await studentApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, StudentUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await studentApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await studentApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await studentApiService.GetAsync(id)
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAsync(
        [FromQuery] PaginationParams @params,
        [FromQuery] Filter filter,
        [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await studentApiService.GetAsync(@params, filter, search)
        });
    }

    [HttpPost("{id:long}/pictures/upload")]
    public async ValueTask<IActionResult> UploadPictureAsync(long id, IFormFile file)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await studentApiService.UploadPictureAsync(id, file)
        });
    }

    [HttpPost("{id:long}/pictures/delete")]
    public async ValueTask<IActionResult> DeletePictureAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await studentApiService.DeletePictureAsync(id)
        });
    }
}
