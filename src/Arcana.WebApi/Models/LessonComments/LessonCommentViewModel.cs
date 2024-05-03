using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Lessons;
using Arcana.Domain.Entities.Users;

namespace Arcana.WebApi.Models.LessonComments;

public class LessonCommentViewModel : Auditable
{
    public long Id { get; set; }
    public string Content { get; set; }
    public Lesson Lesson { get; set; }
    public User User { get; set; }
    public Instructor Instructor { get; set; }
    public LessonComment Parent { get; set; }
}