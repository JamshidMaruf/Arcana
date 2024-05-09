using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.InstructorStars;

public interface IInstructorStarService
{
    ValueTask<InstructorStar> CreateAsync(InstructorStar instructorStars);
    ValueTask<InstructorStar> UpdateAsync(long id, InstructorStar instructorStars);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<InstructorStar> GetByIdAsync(long id);
    ValueTask<IEnumerable<InstructorStar>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}