namespace Arcana.WebApi.Models.Lessons;

public class LessonUpdateModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long FileId { get; set; }
    public long ModuleId { get; set; }
}
