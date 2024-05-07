using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Instructors;

namespace Arcana.Domain.Entities.StudentCourses;

public class StudentCourse : Auditable
{
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long CourseId { get; set; }  
    public Course Course { get; set; }
}
