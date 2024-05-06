using Arcana.Service.Configurations;

namespace Arcana.Service.Services.CourseCategories;

public class CourseCategoryService() : ICourseCategory
{
    public ValueTask<CourseCategoryService> CreateAsync(CourseCategoryService courseCategory)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<CourseCategoryService>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseCategoryService> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseCategoryService> UpdateAsync(long id, CourseCategoryService courseCategory)
    {
        throw new NotImplementedException();
    }
}