using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Courses;

namespace Arcana.Domain.Entities.CourseCategories;

public class CourseCategory : Auditable
{
    public string Name { get; set; }
    public IEnumerable<Course> Courses { get; set; }
}