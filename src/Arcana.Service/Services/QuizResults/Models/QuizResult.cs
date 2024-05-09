using Arcana.Domain.Entities.QuizApplications;
using Arcana.Domain.Entities.Quizzes;
using Arcana.Domain.Entities.Students;

namespace Arcana.Service.Services.QuizResults.Models;

public class QuizResult
{
    public QuizApplication Application { get; set; }
    public int CorrectAnswersCount { get; set; }
    public double Percentage { get; set; }
}
