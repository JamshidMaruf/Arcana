namespace Arcana.WebApi.Models.QuestionAnswers;

public class QuestionAnswerUpdateModel
{
    public long QuizId { get; set; }
    public long StudentId { get; set; }
    public long QuestionId { get; set; }
    public long OptionId { get; set; }
}
