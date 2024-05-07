using Arcana.Service.Configurations;
using Arcana.WebApi.Models.StudentCourses;

namespace Arcana.WebApi.ApiServices.StudentCourses;

public interface IStudentCourseApiService
{
    ValueTask<StudentCourseViewModel> PostAsync(StudentCourseCreateModel createModel);
    ValueTask<StudentCourseViewModel> PutAsync(long id, StudentCourseUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<StudentCourseViewModel> GetAsync(long id);
    ValueTask<IEnumerable<StudentCourseViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
