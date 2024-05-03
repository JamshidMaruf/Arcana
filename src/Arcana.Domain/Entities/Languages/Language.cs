using Arcana.Domain.Commons;

namespace Arcana.Domain.Entities.Languages;

public class Language:Auditable
{
    public string Name { get; set; }
    public string ShortName { get; set; }
}