namespace Arcana.WebApi.Models.QuestionAnswers;

public class QuestionAnswerCreateModel
{
    public long QuizId { get; set; }
    public long StudentId { get; set; }
    public long QuestionId { get; set; }
    public long OptionId { get; set; }
}
