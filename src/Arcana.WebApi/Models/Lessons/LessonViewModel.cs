using Arcana.WebApi.Models.Assets;

namespace Arcana.WebApi.Models.Lessons;

public class LessonViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AssetViewModel File { get; set; }
    //public Module Module { get; set; }
}
