using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.LessonComments;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.LessonComments;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class LessonCommentsController(ILessonCommentApiService lessonCommentApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(LessonCommentCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await lessonCommentApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, LessonCommentUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await lessonCommentApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await lessonCommentApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await lessonCommentApiService.GetAsync(id)
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
            Data = await lessonCommentApiService.GetAsync(@params, filter, search)
        });
    }
}