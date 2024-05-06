
using Arcana.Domain.Entities.StudentCourses;
using Arcana.Domain.Entities.Users;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.StudentCourses;

public interface IStudentCourseService
{
    ValueTask<StudentCourse> CreateAsync(StudentCourse studentCourse);
    ValueTask<StudentCourse> UpdateAsync(long id, StudentCourse studentCourse);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<StudentCourse> GetByIdAsync(long id);
    ValueTask<IEnumerable<StudentCourse>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
