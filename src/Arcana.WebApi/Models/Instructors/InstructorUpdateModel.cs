using Arcana.WebApi.Models.Users;

namespace Arcana.WebApi.Models.Instructors;

public class InstructorUpdateModel
{
    public string About { get; set; }
    public string Profession { get; set; }
    public UserUpdateModel Detail { get; set; }
}