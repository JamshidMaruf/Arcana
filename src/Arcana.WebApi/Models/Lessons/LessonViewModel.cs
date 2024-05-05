using Arcana.WebApi.Models.Assets;
using Arcana.WebApi.Models.CourseModules;

namespace Arcana.WebApi.Models.Lessons;

public class LessonViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AssetViewModel File { get; set; }
    public CourseModuleViewModel Module { get; set; }
}
