using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.Users;

namespace Arcana.Domain.Entities.Instructors;

public class Instructor : Auditable
{
    public string Profession { get; set; }
    public string About { get; set; }
    public long DetailId { get; set; }
    public User Detail { get; set; }
    public long? PictureId { get; set; }
    public Asset Picture { get; set; }
    public IEnumerable<InstructorStar> Stars { get; set; }
    public IEnumerable<InstructorComment> Comments { get; set; }
    public IEnumerable<Course> Courses { get; set; }
}