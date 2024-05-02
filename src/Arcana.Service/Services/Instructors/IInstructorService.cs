using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Arcana.Service.Services.Instructors;

public interface IInstructorService
{
    ValueTask<Instructor> CreateAsync(Instructor instructor);
    ValueTask<Instructor> UpdateAsync(long id, Instructor instructor);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Instructor> GetByIdAsync(long id);
    ValueTask<IEnumerable<Instructor>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<Instructor> UploadPictureAsync(long id, IFormFile picture);
    ValueTask<Instructor> DeletePictureAsync(long id);
}