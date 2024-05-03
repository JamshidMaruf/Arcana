using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Lessons;
using Arcana.Domain.Entities.Users;

namespace Arcana.WebApi.Models.LessonComments;

public class LessonCommentViewModel : Auditable
{
    public long Id { get; set; }
    public string Content { get; set; }
    // public LessonViewModel Lesson { get; set; }
    // public UserViewModel User { get; set; }
    // public InstructorViewModel Instructor { get; set; }
    // public LessonCommentViewModel Parent { get; set; }
}
