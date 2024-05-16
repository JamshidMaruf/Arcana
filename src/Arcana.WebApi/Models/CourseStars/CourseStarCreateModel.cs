namespace Arcana.WebApi.Models.CourseStars;

public class CourseStarCreateModel
{
    public long StudentId { get; set; }
    public long CourseId { get; set; }
    public byte Stars { get; set; }
}
