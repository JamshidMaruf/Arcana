using Microsoft.AspNetCore.Mvc;
using Arcana.WebApi.Models.Commons;
using Arcana.Service.Configurations;
using Arcana.WebApi.Models.QuizApplications;
using Arcana.WebApi.ApiServices.QuizApplications;

namespace Arcana.WebApi.Controllers;

public class QuizApplicationsController(IQuizApplicationApiService quizApplicationApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(QuizApplicationCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await quizApplicationApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, QuizApplicationUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await quizApplicationApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await quizApplicationApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await quizApplicationApiService.GetAsync(id)
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
            Data = await quizApplicationApiService.GetAsync(@params, filter, search)
        });
    }
}