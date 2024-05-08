using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.QuizApplications;
using Arcana.Domain.Entities.StudentCourses;
using Arcana.Domain.Entities.Users;

namespace Arcana.Domain.Entities.Students;

public class Student : Auditable
{
    public long DetailId { get; set; }
    public User Detail { get; set; }
    public long? PictureId { get; set; }
    public Asset Picture { get; set; }
    public IEnumerable<StudentCourse> Courses { get; set; }
    public IEnumerable<QuizApplication> QuizApplications { get; set; }
}