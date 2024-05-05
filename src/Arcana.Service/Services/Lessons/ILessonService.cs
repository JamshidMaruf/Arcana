using Arcana.Service.Configurations;
using Arcana.Domain.Entities.Lessons;

namespace Arcana.Service.Services.Lessons;

public interface ILessonService
{
    ValueTask<Lesson> CreateAsync(Lesson lesson);
    ValueTask<Lesson> UpdateAsync(long id, Lesson lesson, bool IsLessonDeleted);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Lesson> GetByIdAsync(long id);
    ValueTask<IEnumerable<Lesson>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}