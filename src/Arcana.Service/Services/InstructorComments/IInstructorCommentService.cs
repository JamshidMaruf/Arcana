using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.InstructorComments;

public interface IInstructorCommentService
{
    ValueTask<InstructorComment> CreateAsync (InstructorComment model);
    ValueTask<InstructorComment> UpdateAsync (long id, InstructorComment model);
    ValueTask<bool> DeleteAsync (long id);
    ValueTask<InstructorComment> GetByIdAsync (long id);
    ValueTask<IEnumerable<InstructorComment>> GetAllAsync (PaginationParams @params, Filter filter, string search = null);
}
