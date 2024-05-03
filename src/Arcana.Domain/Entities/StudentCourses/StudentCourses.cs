using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Instructors;

namespace Arcana.Domain.Entities.StudentCourses;

public class StudentCourses : Auditable
{
    public long StudentId { get; set; }
    public long CourseId { get; set; }  
    public long InstructorId {  get; set; }
    
    public Student Student { get; set; }
    public Course Course { get; set; }
    public Instructor Instructor { get; set; }
}
