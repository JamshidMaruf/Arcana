namespace Arcana.Domain.Commons;

public abstract class Auditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long? UpdatedByQuestionId { get; set; }
    public long CreatedByQuestionId { get; set; }
    public long? DeletedByUserId { get; set; }
}
