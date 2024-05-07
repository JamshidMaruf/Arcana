using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.Courses;

namespace Arcana.Domain.Entities.Lessons;

public class Lesson : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long FileId { get; set; }
    public long ModuleId { get; set; }
    public Asset File { get; set; }
    public CourseModule Module { get; set; }
}
