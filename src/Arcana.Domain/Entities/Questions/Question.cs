using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Commons;

namespace Arcana.Domain.Entities.Questions;

public class Question : Auditable
{
    public string Content { get; set; }
    public long FileId { get; set; }
    public Asset File { get; set; }    
}
