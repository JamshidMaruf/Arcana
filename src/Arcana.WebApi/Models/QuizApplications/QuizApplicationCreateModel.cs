using Arcana.WebApi.Models.Quizzes;
using Arcana.WebApi.Models.Students;

namespace Arcana.WebApi.Models.QuizApplications;

public class QuizApplicationCreateModel
{
    public long StudentId { get; set; }
    public long QuizId { get; set; }
}