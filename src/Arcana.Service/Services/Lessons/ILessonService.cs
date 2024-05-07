using Arcana.Domain.Entities.Lessons;
using Arcana.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Arcana.Service.Services.Lessons;

public interface ILessonService
{
    ValueTask<Lesson> CreateAsync(Lesson lesson, IFormFile file, FileType fileType);
    ValueTask<Lesson> UpdateAsync(long id, Lesson lesson, bool isLessonDeleted = false);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Lesson> GetByIdAsync(long id);
    ValueTask<IEnumerable<Lesson>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}