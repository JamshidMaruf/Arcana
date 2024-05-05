using Arcana.Domain.Entities.Questions;

namespace Arcana.WebApi.Models.QuizQuestions;

public class QuizQuestionCreateModel
{
    public long QuizId { get; set; }
    public long QuestionId { get; set; }
}
