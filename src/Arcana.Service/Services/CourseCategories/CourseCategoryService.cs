using Arcana.Domain.Entities.CourseCategories;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.CourseCategories;

public class CourseCategoryService() : ICourseCategoryService
{
    public ValueTask<CourseCategory> CreateAsync(CourseCategory courseCategory)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseCategory> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<CourseCategory>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseCategory> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseCategory> UpdateAsync(long id, CourseCategory courseCategory)
    {
        throw new NotImplementedException();
    }
}
