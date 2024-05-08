using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.CourseCategories;
using Arcana.Domain.Entities.CourseComments;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Languages;
using Arcana.Domain.Enums;

namespace Arcana.Domain.Entities.Courses;

public class Course : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public int CountOfLessons { get; set; }
    public Level Level { get; set; }
    public long CategoryId { get; set; }
    public CourseCategory Category { get; set; }
    public long InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    public long FileId { get; set; }
    public Asset File { get; set; }
    public long LanguageId { get; set; }
    public Language Language { get; set; }
    public IEnumerable<CourseModule> Modules { get; set; }
    public IEnumerable<CourseStars> Stars { get; set; }
    public IEnumerable<CourseComment> Comments { get; set; }
}
