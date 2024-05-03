using Arcana.WebApi.Models.Quizzes;
using Arcana.WebApi.Models.Students;

namespace Arcana.WebApi.Models.QuizApplications;

public class QuizApplicationViewModel
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public StudentViewModel Student { get; set; }
    public long QuizId { get; set; }
    public QuizViewModel Quiz { get; set; }
}