using Arcana.Domain.Entities.Courses;
using Arcana.WebApi.Models.Assets;
using Arcana.WebApi.Models.CourseModules;

namespace Arcana.WebApi.Models.Questions;

public class QuestionViewModel
{
    public long Id { get; set; }
    public string Content { get; set; }
    public CourseModuleViewModel Module { get; set; }
    public AssetViewModel File { get; set; }
}
