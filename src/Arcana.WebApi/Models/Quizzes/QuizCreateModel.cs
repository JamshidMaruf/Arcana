namespace Arcana.WebApi.Models.Quizzes;

public class QuizCreateModel
{
    public string Name { get; set; }
    public int QuestionCount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public long ModuleId { get; set; }
    //public CourseModuleCreateModel Module { get; set; }
}