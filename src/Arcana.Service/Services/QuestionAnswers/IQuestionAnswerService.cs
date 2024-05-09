
using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.QuestionAnswers;

public interface IQuestionAnswerService
{
    ValueTask CreateAsync(List<QuestionAnswer> questionAnswers);
    ValueTask<IEnumerable<QuestionAnswer>> GetAllByQuizIdAsync(long quizId);
}