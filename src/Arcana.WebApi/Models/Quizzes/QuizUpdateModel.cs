namespace Arcana.WebApi.Models.Quizzes;

public class QuizUpdateModel
{
    public string Name { get; set; }
    public int QuestionCount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public long ModuleId { get; set; }
}