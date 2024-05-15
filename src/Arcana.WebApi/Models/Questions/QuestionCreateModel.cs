namespace Arcana.WebApi.Models.Questions;

public class QuestionCreateModel
{
    public string Content { get; set; }
    public long ModuleId { get; set; }
    public long? FileId { get; set; }
}
