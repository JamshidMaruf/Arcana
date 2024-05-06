using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.CourseComments;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.CourseComments;

public class CourseCommentService(IUnitOfWork unitOfWork) : ICourseCommentService
{
    public ValueTask<CourseComment> CreateAsync(CourseComment courseComment)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<CourseComment>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseComment> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CourseComment> UpdateAsync(long id, CourseComment courseComment)
    {
        throw new NotImplementedException();
    }
}