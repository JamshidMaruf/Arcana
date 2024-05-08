using Arcana.Service.Configurations;
using Arcana.WebApi.Models.CourseModules;

namespace Arcana.WebApi.ApiServices.CourseModules;

public interface ICourseModuleApiService
{
    ValueTask<CourseModuleViewModel> PostAsync(CourseModuleCreateModel createModel);
    ValueTask<CourseModuleViewModel> PutAsync(long id, CourseModuleUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseModuleViewModel> GetAsync(long id);
    ValueTask<IEnumerable<CourseModuleViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}