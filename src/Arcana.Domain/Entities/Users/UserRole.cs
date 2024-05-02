using Arcana.Domain.Commons;

namespace Arcana.Domain.Entities.Users;

public class UserRole : Auditable
{
    public string Name { get; set; }
}