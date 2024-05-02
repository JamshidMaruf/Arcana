using Arcana.Domain.Entities.Students;
using Arcana.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Arcana.Service.Services.Students;

public interface IStudentService
{
    ValueTask<Student> CreateAsync(Student student);
    ValueTask<Student> UpdateAsync(long id, Student student);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Student> GetByIdAsync(long id);
    ValueTask<IEnumerable<Student>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<Student> UploadPictureAsync(long id, IFormFile picture);
    ValueTask<Student> DeletePictureAsync(long id);
}