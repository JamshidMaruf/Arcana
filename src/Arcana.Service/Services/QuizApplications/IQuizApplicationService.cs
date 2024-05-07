using Arcana.Service.Configurations;
using Arcana.Domain.Entities.QuizApplications;

namespace Arcana.Service.Services.QuizApplications;

public interface IQuizApplicationService
{
    ValueTask<QuizApplication> CreateAsync(QuizApplication quizApplication);
    ValueTask<QuizApplication> UpdateAsync(long id, QuizApplication quizApplication);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<QuizApplication> GetByIdAsync(long id);
    ValueTask<IEnumerable<QuizApplication>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
