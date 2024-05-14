using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.Courses;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.Courses;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers
{
    public class CoursesController(ICourseApiService courseApiService) : BaseController
    {
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(CourseCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseApiService.PostAsync(createModel)
            });
        }

        [HttpPut("{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id, CourseUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseApiService.PutAsync(id, updateModel)
            });
        }

        [HttpDelete("{id:long}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseApiService.DeleteAsync(id)
            });
        }

        [HttpGet("{id:long}")]
        public async ValueTask<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseApiService.GetAsync(id)
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
                Data = await courseApiService.GetAsync(@params, filter, search)
            });
        }
    }
}
