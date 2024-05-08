using Arcana.Domain.Entities.Lessons;
using Arcana.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Arcana.Service.Services.Lessons;

public interface ILessonService
{
    ValueTask<Lesson> CreateAsync(Lesson lesson);
    ValueTask<Lesson> UpdateAsync(long id, Lesson lesson);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Lesson> GetByIdAsync(long id);
    ValueTask<IEnumerable<Lesson>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<Lesson> UploadFileAsync(long id, IFormFile file, FileType fileType);
    ValueTask<Lesson> DeleteFileAsync(long id);
}