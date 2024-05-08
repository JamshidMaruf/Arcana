using Arcana.Domain.Entities.Courses;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.CourseModules;

public interface ICourseModuleService
{
    ValueTask<CourseModule> CreateAsync(CourseModule courseModule);
    ValueTask<CourseModule> UpdateAsync(long id, CourseModule courseModule);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseModule> GetByIdAsync(long id);
    ValueTask<IEnumerable<CourseModule>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}