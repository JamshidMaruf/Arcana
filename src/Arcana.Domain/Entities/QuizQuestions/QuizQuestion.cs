using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Questions;
using Arcana.Domain.Entities.Quizzes;

namespace Arcana.Domain.Entities.QuizQuestions;

public class QuizQuestion : Auditable
{
    public long QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public long QuestionId { get; set; }
    public Question Question { get; set; }
}
