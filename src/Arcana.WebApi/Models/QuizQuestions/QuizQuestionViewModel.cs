using Arcana.WebApi.Models.Questions;
using Arcana.WebApi.Models.Quizzes;

namespace Arcana.WebApi.Models.QuizQuestions;

public class QuizQuestionViewModel
{
    public long Id { get; set; }
    public QuizViewModel Quiz { get; set; }
    public QuestionViewModel Question { get; set; }
}