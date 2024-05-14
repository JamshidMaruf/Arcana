using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.Questions;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.Questions;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class QuestionsController(IQuestionApiService questionApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(QuestionCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, QuestionUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionApiService.GetAsync(id)
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
            Data = await questionApiService.GetAsync(@params, filter, search)
        });
    }

    [HttpPost("pictures/{id:long}")]
    public async ValueTask<IActionResult> UploadPictureAsync(long id, IFormFile file)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionApiService.UploadPictureAsync(id, file)
        });
    }

    [HttpDelete("pictures/{id:long}")]
    public async ValueTask<IActionResult> DeletePictureAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionApiService.DeletePictureAsync(id)
        });
    }
}