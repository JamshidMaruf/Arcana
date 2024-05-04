using Arcana.Domain.Entities.Students;

namespace Arcana.Domain.Entities.Instructors;

public class InstructorComment
{
    public long StudentId { get; set; }
    public long InstructorId { get; set; }
    public string Content { get; set; }
    
    public Student Student { get; set; }
    public Instructor Instructor { get; set; }
}
