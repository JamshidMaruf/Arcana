using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Questions;

namespace Arcana.Domain.Entities.QuestionAnswers;

public class QuestionAnswer : Auditable
{
    public string Content {  get; set; }
    public long QuestionId {  get; set; }
    public Question Question { get; set; }
    public bool IsCorrect { get; set; }
}