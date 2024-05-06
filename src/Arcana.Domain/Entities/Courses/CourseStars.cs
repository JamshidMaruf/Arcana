using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Students;

namespace Arcana.Domain.Entities.Courses;

public class CourseStars : Auditable
{
    public long StudentId { get; set; }
    public long CourseId { get; set; }
    public byte Stars { get; set; }
    public Student Student { get; set; }
    public Course Course { get; set; }
}
