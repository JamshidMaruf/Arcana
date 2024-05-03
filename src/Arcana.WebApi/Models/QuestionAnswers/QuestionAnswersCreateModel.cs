namespace Arcana.WebApi.Models.QuestionAnswers;

public class QuestionAnswerCreateModel
{
    public string Content { get; set; }
    public long QuestionId { get; set; }
    public bool IsCorrect { get; set; }
}
