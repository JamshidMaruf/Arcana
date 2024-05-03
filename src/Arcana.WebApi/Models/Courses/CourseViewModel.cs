using Arcana.Domain.Enums.Levels;

namespace Arcana.WebApi.Models.Courses;

public class CourseViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public int CountOfLessons { get; set; }
    public Level Level { get; set; }
    // public CourseCategoryViewModel Category { get; set; }
    // public InstructorViewModel Instructor { get; set; }
    // public AssetViewModel File { get; set; }
    //public LanguageViewModel Language {  get; set; }
}
