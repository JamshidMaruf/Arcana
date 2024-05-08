using Arcana.Domain.Entities.QuestionOptions;
using Arcana.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Arcana.Service.Services.QuestionOptions;

public interface IQuestionOptionService
{
    ValueTask<QuestionOption> CreateAsync(QuestionOption questionOption);
    ValueTask<QuestionOption> UpdateAsync(long id, QuestionOption questionOption);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<QuestionOption> GetByIdAsync(long id);
    ValueTask<IEnumerable<QuestionOption>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}