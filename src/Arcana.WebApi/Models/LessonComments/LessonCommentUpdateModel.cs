using Arcana.Domain.Commons;

namespace Arcana.WebApi.Models.LessonComments;

public class LessonCommentUpdateModel : Auditable
{
    public long LessonId { get; set; }
    public long UserId { get; set; }
    public long InstructorId { get; set; }
    public long? ParentId { get; set; }
    public string Content { get; set; }
}
