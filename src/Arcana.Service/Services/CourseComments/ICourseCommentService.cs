using Arcana.Domain.Entities.CourseComments;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.CourseComments;

public interface ICourseCommentService
{
    ValueTask<CourseComment> CreateAsync(CourseComment courseComment);
    ValueTask<CourseComment> UpdateAsync(long id, CourseComment courseComment);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseComment> GetByIdAsync(long id);
    ValueTask<IEnumerable<CourseComment>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
