namespace Arcana.WebApi.Models.QuestionOptions;

public class QuestionOptionCreateModel
{
    public string Content { get; set; }
    public long QuestionId { get; set; }
    public bool IsCorrect { get; set; }
}
