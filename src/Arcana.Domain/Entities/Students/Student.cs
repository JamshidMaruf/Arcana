using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.Users;

namespace Arcana.Domain.Entities.Students;

public class Student : Auditable
{
    public long DetailId { get; set; }
    public User Detail { get; set; }
    public long? PictureId { get; set; }
    public Asset Picture { get; set; }
}
