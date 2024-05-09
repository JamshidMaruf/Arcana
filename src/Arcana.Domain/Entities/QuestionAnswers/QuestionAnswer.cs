using Arcana.Domain.Commons;
using Arcana.Domain.Entities.QuestionOptions;
using Arcana.Domain.Entities.Questions;
using Arcana.Domain.Entities.Quizzes;
using Arcana.Domain.Entities.Students;

namespace Arcana.Domain.Entities.QuestionAnswers;

public class QuestionAnswer : Auditable
{
    public long QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long QuestionId { get; set; }
    public Question Question { get; set; }
    public long OptionId { get; set; }
    public QuestionOption Option { get; set; }
}