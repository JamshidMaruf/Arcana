using Arcana.Domain.Entities.QuizQuestions;
using Arcana.Domain.Entities.Quizzes;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.Quizzes;

public interface IQuizService
{
    ValueTask<Quiz> CreateAsync(Quiz quiz);
    ValueTask<Quiz> UpdateAsync(long id, Quiz quiz);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Quiz> GetByIdAsync(long id);
    ValueTask<IEnumerable<Quiz>> GetAllAsync(
        PaginationParams @params, 
        Filter filter, 
        string search = null, 
        long? moduleId = null);
    ValueTask<Quiz> GenerateQuestionsAsync(long quizId, long moduleId);
}