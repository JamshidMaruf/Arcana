using Arcana.Domain.Commons;

namespace Arcana.Domain.Entities.Quizzes;

public class Quiz : Auditable
{
    public string Name { get; set; }
    public int QuestionCount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public long ModuleId { get; set; }
    //public CourseModuleModel Module { get; set; }
}