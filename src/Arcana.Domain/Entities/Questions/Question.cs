using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.QuestionOptions;

namespace Arcana.Domain.Entities.Questions;

public class Question : Auditable
{
    public string Content { get; set; }
    public long ModuleId { get; set; }
    public CourseModule Module { get; set; }
    public long? FileId { get; set; }
    public Asset File { get; set; }
    public IEnumerable<QuestionOption> Options { get; set; }
}