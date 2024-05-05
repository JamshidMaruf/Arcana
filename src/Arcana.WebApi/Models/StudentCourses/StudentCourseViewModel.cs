using Arcana.WebApi.Models.Courses;
using Arcana.WebApi.Models.Students;
using Arcana.WebApi.Models.Instructors;

namespace Arcana.WebApi.Models.StudentCourses;

public class StudentCourseViewModel
{
    public long Id {  get; set; }
    public CourseViewModel Course { get; set; }
    public StudentViewModel Student { get; set; }
    public InstructorViewModel Instructor { get; set; }
}
