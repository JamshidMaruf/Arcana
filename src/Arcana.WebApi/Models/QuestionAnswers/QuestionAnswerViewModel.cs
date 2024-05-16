using Arcana.WebApi.Models.QuestionOptions;
using Arcana.WebApi.Models.Questions;
using Arcana.WebApi.Models.Quizzes;
using Arcana.WebApi.Models.Students;

namespace Arcana.WebApi.Models.QuestionAnswers;

public class QuestionAnswerViewModel
{
    public long Id { get; set; }
    public QuizViewModel Quiz { get; set; }
    public StudentViewModel Student { get; set; }
    public QuestionViewModel Question { get; set; }
    public QuestionOptionViewModel Option { get; set; }
}