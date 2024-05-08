using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.Permissions;
using Arcana.WebApi.ApiServices.StudentCourses;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.Permissions;
using Arcana.WebApi.Models.StudentCourses;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers
{
    public class StudentCoursesController(IStudentCourseApiService studentCourseApiService) : BaseController
    {
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(StudentCourseCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await studentCourseApiService.PostAsync(createModel)
            });
        }

        [HttpPut("{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id, StudentCourseUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await studentCourseApiService.PutAsync(id, updateModel)
            });
        }

        [HttpDelete("{id:long}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await studentCourseApiService.DeleteAsync(id)
            });
        }

        [HttpGet("{id:long}")]
        public async ValueTask<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await studentCourseApiService.GetAsync(id)
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
                Data = await studentCourseApiService.GetAsync(@params, filter, search)
            });
        }
    }
}
