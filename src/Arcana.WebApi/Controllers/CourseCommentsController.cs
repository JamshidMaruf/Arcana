using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.CourseComments;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.CourseComments;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers
{
    public class CourseCommentsController(ICourseCommentApiService courseCommentApiService) : BaseController
    {
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(CourseCommentCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseCommentApiService.PostAsync(createModel)
            });
        }

        [HttpPut("{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id, CourseCommentUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseCommentApiService.PutAsync(id, updateModel)
            });
        }

        [HttpDelete("{id:long}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseCommentApiService.DeleteAsync(id)
            });
        }

        [HttpGet("{id:long}")]
        public async ValueTask<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseCommentApiService.GetAsync(id)
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
                Data = await courseCommentApiService.GetAsync(@params, filter, search)
            });
        }
    }
}
