using Arcana.WebApi.Models.Assets;

namespace Arcana.WebApi.Models.Students;

public class StudentViewModel
{
    public long Id { get; set; }    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public AssetViewModel Picture { get; set; }
}