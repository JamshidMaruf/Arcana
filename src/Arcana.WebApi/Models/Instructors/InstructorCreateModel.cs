using Arcana.WebApi.Models.Users;

namespace Arcana.WebApi.Models.Instructors;

public class InstructorCreateModel
{
    public string About { get; set; }
    public string Profession { get; set; }
    public UserCreateModel Detail { get; set; }
}