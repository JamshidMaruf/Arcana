namespace Arcana.WebApi.Models.CourseModules;

public class CourseModuleCreateModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long CourseId { get; set; }
}
