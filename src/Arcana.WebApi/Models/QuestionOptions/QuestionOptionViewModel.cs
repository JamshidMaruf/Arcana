using Arcana.WebApi.Models.Questions;

namespace Arcana.WebApi.Models.QuestionOptions;

public class QuestionOptionViewModel
{
    public long Id { get; set; }
    public string Content { get; set; }
    //public QuestionViewModel Question { get; set; }
    public bool IsCorrect { get; set; }
}
