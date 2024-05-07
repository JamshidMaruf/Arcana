using Arcana.Service.Configurations;
using Arcana.WebApi.Models.CourseCategories;

namespace Arcana.WebApi.ApiServices.CourseCategories;

public class CourseCategoryApiService : ICourseCategoryApiService
{
    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseCategoryViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<CourseCategoryViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseCategoryViewModel> PostAsync(CourseCategoryCreateModel createModel)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseCategoryViewModel> PutAsync(long id, CourseCategoryUpdateModel updateModel)
    {
        throw new NotImplementedException();
    }
}
