using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;


public interface IInstructorStarsService
{
    ValueTask<InstructorStar> CreateAsync(InstructorStar instructorStars);
    ValueTask<InstructorStar> UpdateAsync(long id, InstructorStar instructorStars);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<InstructorStar> GetByIdAsync(long id);
    ValueTask<IEnumerable<InstructorStar>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}