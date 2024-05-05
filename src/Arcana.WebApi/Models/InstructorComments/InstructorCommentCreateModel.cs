namespace Arcana.WebApi.Models.InstructorComments;

public class InstructorCommentCreateModel
{
    public long StudentId { get; set; }
    public long InstructorId { get; set; }
    public string Content { get; set; }
}
