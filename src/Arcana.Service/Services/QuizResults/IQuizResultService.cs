using Arcana.Service.Services.QuizResults.Models;

namespace Arcana.Service.Services.QuizResults;

public interface IQuizResultService
{
    ValueTask<QuizResult> GetResultByApplicationId(long applicationId);
}