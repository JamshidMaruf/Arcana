using Arcana.WebApi.Models.UserRoles;

namespace Arcana.WebApi.Models.Users;

public class UserLoginViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Token { get; set; }
    public DateTime DateOfBirth { get; set; }
    public UserRoleViewModel Role { get; set; }
}