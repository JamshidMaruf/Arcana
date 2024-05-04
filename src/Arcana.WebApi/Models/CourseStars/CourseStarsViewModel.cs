using Arcana.WebApi.Models.Courses;
using Arcana.WebApi.Models.Students;

namespace Arcana.WebApi.Models.CourseStars;

public class CourseStarsViewModel
{
    public StudentViewModel Student { get; set; }
    public CourseViewModel Course { get; set; }
    public byte Stars { get; set; }
}
