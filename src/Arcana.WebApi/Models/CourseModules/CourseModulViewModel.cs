namespace Arcana.WebApi.Models.CourseModules;

public class CourseModulViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public CourseModulViewModel Course { get; set; }
}
