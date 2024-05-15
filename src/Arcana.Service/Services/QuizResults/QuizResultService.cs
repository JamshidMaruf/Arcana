using Arcana.DataAccess.UnitOfWorks;
using Arcana.Service.Exceptions;
using Arcana.Service.Services.QuizResults.Models;

namespace Arcana.Service.Services.QuizResults;

public class QuizResultService(IUnitOfWork unitOfWork) : IQuizResultService
{
    public async ValueTask<QuizResult> GetResultByApplicationId(long applicationId)
    {
        var existApplication = await unitOfWork.QuizApplications
            .SelectAsync(
                expression: application => application.Id == applicationId,
                includes: ["Quiz"])
            ?? throw new NotFoundException($"Application is not found with this ID={applicationId}");

        var questionAnswers = await unitOfWork.QuestionAnswers
            .SelectAsEnumerableAsync(
                expression: qa => qa.QuizId == existApplication.QuizId,
                includes: ["Option"]);

        QuizResult result = new();

        result.Application = existApplication;
        result.CorrectAnswersCount = questionAnswers.Count(qa => qa.Option.IsCorrect);
        result.Percentage = Math.Round(Convert.ToDouble(result.CorrectAnswersCount) / existApplication.Quiz.QuestionCount * 100, 2);

        return result;
    }
}