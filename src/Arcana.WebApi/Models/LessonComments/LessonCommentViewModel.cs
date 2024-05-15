using Arcana.WebApi.Models.Lessons;
using Arcana.WebApi.Models.Users;

namespace Arcana.WebApi.Models.LessonComments;

public class LessonCommentViewModel
{
    public long Id { get; set; }
    public string Content { get; set; }
    public UserViewModel User { get; set; }
    public LessonViewModel Lesson { get; set; }
    public LessonCommentViewModel Parent { get; set; }
}
