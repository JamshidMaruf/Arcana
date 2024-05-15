using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.InstructorComments;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.InstructorComments;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers;

public class InstructorCommentsController(IInstructorCommentApiService apiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(InstructorCommentCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await apiService.PostAsync(createModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await apiService.DeleteAsync(id)
        });
    }
    

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, InstructorCommentUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await apiService.PutAsync(id, updateModel)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await apiService.GetAsync(id)
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
            Data = await apiService.GetAsync(@params, filter, search)
        });
    }
}
