using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.QuestionOptions;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.QuestionOptions;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class QuestionOptionsController(IQuestionOptionApiService questionOptionService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(QuestionOptionCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionOptionService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, QuestionOptionUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionOptionService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionOptionService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await questionOptionService.GetAsync(id)
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
            Data = await questionOptionService.GetAsync(@params, filter, search)
        });
    }
}