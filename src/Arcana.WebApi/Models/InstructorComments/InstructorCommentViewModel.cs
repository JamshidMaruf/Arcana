using Arcana.WebApi.Models.Instructors;
using Arcana.WebApi.Models.Students;

namespace Arcana.WebApi.Models.InstructorComments;

public class InstructorCommentViewModel
{
    public long Id { get; set; }
    public StudentViewModel Student { get; set; }
    public InstructorViewModel Instructor { get; set; }
    public string Content { get; set; }
}
