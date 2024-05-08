using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Lessons;

namespace Arcana.Domain.Entities.Courses;

public class CourseModule : Auditable
{
    public string Name { get; set; }
    public long CourseId { get; set; }
    public Course Course { get; set; }
    public IEnumerable<Lesson> Lessons { get; set; }
}