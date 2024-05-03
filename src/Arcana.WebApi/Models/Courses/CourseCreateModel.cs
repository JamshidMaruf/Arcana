using Arcana.Domain.Enums.Levels;

namespace Arcana.WebApi.Models.Courses;

public class CourseCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime Duration { get; set; }
    public int CountOfLessons { get; set; }
    public Level Level { get; set; }
    public long CategoryId { get; set; }
    public long InstructorId { get; set; }
    public long FileId { get; set; }
    //public long LanguageId {  get; set; }
}
