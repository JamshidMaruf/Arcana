using Arcana.WebApi.Models.Assets;

namespace Arcana.WebApi.Models.Questions;

public class QuestionViewModel
{
    public long Id { get; set; }
    public string Content { get; set; }
    public AssetViewModel File { get; set; }
}
