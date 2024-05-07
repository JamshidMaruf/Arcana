using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Students;

namespace Arcana.Domain.Entities.Lessons;

public class LessonComment : Auditable
{
    public long LessonId { get; set; }
    public long? StudentId { get; set; }
    public long? InstructorId { get; set; }
    public long? ParentId {  get; set; }
    public string Content { get; set; }
    public Lesson Lesson { get; set; }
    public Student Student { get; set; }
    public Instructor Instructor { get; set; }
    public LessonComment Parent {  get; set; }
}
