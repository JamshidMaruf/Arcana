using Arcana.Service.Configurations;
using Arcana.WebApi.Models.CourseCategories;

namespace Arcana.WebApi.ApiServices.CourseCategories;

public interface ICourseCategoryApiService
{
    ValueTask<CourseCategoryViewModel> PostAsync(CourseCategoryCreateModel createModel);
    ValueTask<CourseCategoryViewModel> PutAsync(long id, CourseCategoryUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseCategoryViewModel> GetAsync(long id);
    ValueTask<IEnumerable<CourseCategoryViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
