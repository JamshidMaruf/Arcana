namespace Arcana.WebApi.Models.StudentCourses;

public class StudentCourseCreateModel
{
    public long CourseId { get; set; }
    public long StudentId { get; set; }
    public long InstructorId { get; set; }
}
