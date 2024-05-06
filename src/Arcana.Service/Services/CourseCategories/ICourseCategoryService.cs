using Arcana.Service.Configurations;

namespace Arcana.Service.Services.CourseCategories;

public interface ICourseCategoryService
{
    ValueTask<CourseCategoryService> CreateAsync(CourseCategoryService courseCategory);
    ValueTask<CourseCategoryService> UpdateAsync(long id, CourseCategoryService courseCategory);
    ValueTask<CourseCategoryService> DeleteAsync(long id);
    ValueTask<CourseCategoryService> GetByIdAsync(long id);
    ValueTask<IEnumerable<CourseCategoryService>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
