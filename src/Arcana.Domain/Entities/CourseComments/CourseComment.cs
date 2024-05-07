using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.Students;

namespace Arcana.Domain.Entities.CourseComments;

public class CourseComment : Auditable
{
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long CourseId { get; set; }
    public Course Course { get; set; }
    public string Content { get; set; }
}