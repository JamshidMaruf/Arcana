using Arcana.Domain.Entities.QuizQuestions;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.QuizQuestions;

public interface IQuizQuestionService
{
    ValueTask<QuizQuestion> CreateAsync(QuizQuestion quizQuestion);
    ValueTask<QuizQuestion> UpdateAsync(long id, QuizQuestion quizQuestion);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<QuizQuestion> GetByIdAsync(long id);
    ValueTask<IEnumerable<QuizQuestion>> GetAllAsync(
        PaginationParams @params, 
        Filter filter, 
        string search = null, 
        long? quizId = null);
}