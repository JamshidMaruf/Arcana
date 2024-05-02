using Arcana.WebApi.Models.Assets;
using Arcana.WebApi.Models.Users;

namespace Arcana.WebApi.Models.Instructors;

public class InstructorViewModel
{
    public long Id { get; set; }
    public string About { get; set; }
    public string Profession { get; set; }
    public UserViewModel Detail { get; set; }
    public AssetViewModel Picture { get; set; }
}