using Arcana.WebApi.Models.Courses;

namespace Arcana.WebApi.Models.CourseModules;

public class CourseModuleViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public CourseViewModel Course { get; set; }
}
