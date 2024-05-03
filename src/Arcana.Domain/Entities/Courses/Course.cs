using Arcana.Domain.Commons;
using Arcana.Domain.Enums.Levels;

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
    //public CourseCategory Category{ get; set; } //added entity
    public long InstructorId { get; set; }
    //public Instructor Intructor{ get; set; }//added entity
    public long FileId { get; set; }
    //public Asset File { get; set; }//added entity
    public long LanguageId {  get; set; }
    //public Language Language { get; set; }
}
