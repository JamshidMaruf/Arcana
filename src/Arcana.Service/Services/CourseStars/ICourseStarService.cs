using Arcana.Domain.Entities.Courses;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.CourseStars;

public interface ICourseStarService
{
    ValueTask<CourseStar> CreateAsync(CourseStar courseStar);
    ValueTask<CourseStar> UpdateAsync(long id, CourseStar courseStar);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseStar> GetByIdAsync(long id);
    ValueTask<IEnumerable<CourseStar>> GetAllAsync(PaginationParams @params,
                                                   Filter filter,
                                                   string search = null);
}
