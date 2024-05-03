namespace Arcana.WebApi.Models.QuestionAnswers;

public class QuestionAnswersCreateModel
{
    public string Content { get; set; }
    public long QuestionId { get; set; }
    public bool IsCorrect { get; set; }
}
