using Arcana.WebApi.Models.Courses;
using Arcana.WebApi.Models.Students;

namespace Arcana.WebApi.Models.CourseComments;

public class CourseCommentViewModel
{
    public long Id { get; set; }
    public StudentViewModel Student { get; set; }
    public CourseViewModel Course { get; set; }
    public string Content { get; set; }
}