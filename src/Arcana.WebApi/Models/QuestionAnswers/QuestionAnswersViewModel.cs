namespace Arcana.WebApi.Models.QuestionAnswers;

public class QuestionAnswerViewModel
{
    public long Id { get; set; }
    public string Content { get; set; }
    //public QuestionViewModel Question { get; set; }
    public bool IsCorrect { get; set; }
}
