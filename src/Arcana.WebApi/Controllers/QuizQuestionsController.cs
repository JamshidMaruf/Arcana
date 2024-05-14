using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.QuizQuestions;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.QuizQuestions;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class QuizQuestionsController(IQuizQuestionApiService quizQuestionApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(QuizQuestionCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await quizQuestionApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, QuizQuestionUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await quizQuestionApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await quizQuestionApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await quizQuestionApiService.GetAsync(id)
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
            Data = await quizQuestionApiService.GetAsync(@params, filter, search)
        });
    }
}