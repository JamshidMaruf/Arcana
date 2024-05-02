using Arcana.Domain.Commons;

namespace Arcana.Domain.Entities.Commons;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
}
