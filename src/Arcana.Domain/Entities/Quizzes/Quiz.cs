using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.Questions;

namespace Arcana.Domain.Entities.Quizzes;

public class Quiz : Auditable
{
    public string Name { get; set; }
    public int QuestionCount { get; set; }
    public long ModuleId { get; set; }
    public CourseModule Module { get; set; }
    public ICollection<Question> Questions { get; set; }
}