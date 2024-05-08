using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.QuestionAnswers;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.QuestionAnswers;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class QuestionAnswersController(IQuestionAnswerApiService questionAnswerService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(QuestionAnswerCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionAnswerService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, QuestionAnswerUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionAnswerService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionAnswerService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionAnswerService.GetAsync(id)
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
            Data = await questionAnswerService.GetAsync(@params, filter, search)
        });
    }
}