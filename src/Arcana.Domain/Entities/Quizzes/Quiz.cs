using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.Questions;
using Arcana.Domain.Entities.QuizQuestions;

namespace Arcana.Domain.Entities.Quizzes;

public class Quiz : Auditable
{
    public string Name { get; set; }
    public int QuestionCount { get; set; }
    public long ModuleId { get; set; }
    public CourseModule Module { get; set; }
    public IEnumerable<QuizQuestion> Questions { get; set; }
}