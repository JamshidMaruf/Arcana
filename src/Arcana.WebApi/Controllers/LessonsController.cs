using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.Lessons;
using Arcana.WebApi.Models.Assets;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.Lessons;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class LessonsController(ILessonApiService lessonApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(LessonCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await lessonApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, LessonUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await lessonApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await lessonApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await lessonApiService.GetAsync(id)
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
            Data = await lessonApiService.GetAsync(@params, filter, search)
        });
    }

    [HttpPost("{id:long}/files/upload")]
    public async Task<IActionResult> PictureUploadAsync(long id, AssetCreateModel asset)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonApiService.UploadFileAsync(id, asset)
        });
    }

    [HttpPost("{id:long}/files/delete")]
    public async Task<IActionResult> PictureDeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await lessonApiService.DeleteFileAsync(id)
        });
    }
}