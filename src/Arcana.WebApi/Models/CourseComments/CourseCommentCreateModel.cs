namespace Arcana.WebApi.Models.CourseComments;

public class CourseCommentCreateModel
{
    public long StudentId { get; set; }
    public long CourseId { get; set; }
    public string Content { get; set; }
}