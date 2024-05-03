using Arcana.Domain.Commons;

namespace Arcana.Domain.Entities.QuizApplications;

public class QuizApplication : Auditable
{
    public long StudentId { get; set; }
    public long QuizId { get; set; }
}