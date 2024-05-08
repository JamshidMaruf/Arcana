using Arcana.Domain.Entities.Lessons;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.LessonComments;

public interface ILessonCommentService
{
    ValueTask<LessonComment> CreateAsync(LessonComment lessonComment);
    ValueTask<LessonComment> UpdateAsync(long id, LessonComment lessonComment);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<LessonComment> GetByIdAsync(long id);
    ValueTask<IEnumerable<LessonComment>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}