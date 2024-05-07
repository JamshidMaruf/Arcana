using Arcana.Domain.Entities.CourseCategories;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.CourseCategories;

public interface ICourseCategoryService
{
    ValueTask<CourseCategory> CreateAsync(CourseCategory courseCategory);
    ValueTask<CourseCategory> UpdateAsync(long id, CourseCategory courseCategory);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseCategory> GetByIdAsync(long id);
    ValueTask<IEnumerable<CourseCategory>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
