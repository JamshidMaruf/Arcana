using Arcana.Service.Services.QuizResults.Models;

namespace Arcana.Service.Services.QuizResults;

public class QuizResultService : IQuizResultService
{
    public ValueTask<QuizResult> GetResultByApplicationId(long applicationId)
    {
        throw new NotImplementedException();
    }
}