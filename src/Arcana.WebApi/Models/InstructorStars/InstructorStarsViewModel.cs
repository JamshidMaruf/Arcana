using Arcana.WebApi.Models.Students;
using Arcana.WebApi.Models.Instructors;

namespace Arcana.WebApi.Models.InstructorStars;

public class InstructorStarsViewModel
{
    public StudentViewModel Student { get; set; }
    public InstructorViewModel Instructor { get; set; }
    public byte Stars { get; set; }
}
