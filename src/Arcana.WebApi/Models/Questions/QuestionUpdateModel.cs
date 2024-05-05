using Arcana.Domain.Entities.Commons;

namespace Arcana.WebApi.Models.Questions;

public class QuestionUpdateModel
{
    public string Content { get; set; }
    public long FileId { get; set; }
}
