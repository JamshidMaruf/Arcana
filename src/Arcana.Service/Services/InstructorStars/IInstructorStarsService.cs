using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.InstructorStarsService;

public interface IInstructorStarsService
{
    ValueTask<InstructorStars> CreateAsync(InstructorStars instructorStars);
    ValueTask<InstructorStars> UpdateAsync(long id, InstructorStars instructorStars);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<InstructorStars> GetByIdAsync(long id);
    ValueTask<IEnumerable<InstructorStars>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}