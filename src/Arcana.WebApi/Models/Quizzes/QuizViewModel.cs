namespace Arcana.WebApi.Models.Quizzes;

public class QuizViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int QuestionCount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public long ModuleId { get; set; }
    //public CourseModuleViewModel Module { get; set; }
}