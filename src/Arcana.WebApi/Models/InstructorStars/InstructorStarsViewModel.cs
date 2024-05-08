using Arcana.WebApi.Models.Instructors;
using Arcana.WebApi.Models.Students;

namespace Arcana.WebApi.Models.InstructorStars;

public class InstructorStarsViewModel
{
    public long Id { get; set; }
    public StudentViewModel Student { get; set; }
    public InstructorViewModel Instructor { get; set; }
    public byte Stars { get; set; }
}
