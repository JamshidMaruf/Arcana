using Arcana.Domain.Commons;

namespace Arcana.Domain.Entities.Courses;

public class CourseModul : Auditable
{
    public string Name { get; set; }
    public long CourseId { get; set; }

    public Course Course { get; set;}
}
