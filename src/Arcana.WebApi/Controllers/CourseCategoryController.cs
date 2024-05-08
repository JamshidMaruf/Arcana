using Arcana.Service.Configurations;
using Arcana.WebApi.ApiServices.CourseCategories;
using Arcana.WebApi.Models.Commons;
using Arcana.WebApi.Models.CourseCategories;
using Microsoft.AspNetCore.Mvc;

namespace Arcana.WebApi.Controllers
{
    public class CourseCategoryController(ICourseCategoryApiService courseCategoryApiService) : BaseController
    {
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(CourseCategoryCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseCategoryApiService.PostAsync(createModel)
            });
        }

        [HttpPut("{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id, CourseCategoryUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseCategoryApiService.PutAsync(id, updateModel)
            });
        }

        [HttpDelete("{id:long}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseCategoryApiService.DeleteAsync(id)
            });
        }

        [HttpGet("{id:long}")]
        public async ValueTask<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await courseCategoryApiService.GetAsync(id)
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
                Data = await courseCategoryApiService.GetAsync(@params, filter, search)
            });
        }
    }
}
