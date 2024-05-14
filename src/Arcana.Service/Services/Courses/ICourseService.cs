using Microsoft.AspNetCore.Http;
using Arcana.Service.Configurations;
using Arcana.Domain.Entities.Courses;

namespace Arcana.Service.Services.Courses;

public interface ICourseService
{
    ValueTask<Course> CreateAsync(Course course);
    ValueTask<Course> UpdateAsync(long id, Course course);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Course> GetByIdAsync(long id);
    ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<Course> UploadFileAsync(long id, IFormFile file, FileType fileType);
    ValueTask<Course> DeleteFileAsync(long id);
}
