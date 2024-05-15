namespace Arcana.WebApi.Models.LessonComments;

public class LessonCommentCreateModel
{
    public long LessonId { get; set; }
    public long? UserId { get; set; }
    public long? ParentId { get; set; }
    public string Content { get; set; }
}
