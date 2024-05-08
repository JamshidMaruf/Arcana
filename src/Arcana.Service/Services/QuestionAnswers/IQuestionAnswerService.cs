using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Arcana.Service.Services.QuestionAnswers;

public interface IQuestionAnswer1Service
{
    ValueTask<QuestionAnswer> CreateAsync(QuestionAnswer questionAnswer);
    ValueTask<QuestionAnswer> UpdateAsync(long id, QuestionAnswer questionAnswer);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<QuestionAnswer> GetByIdAsync(long id);
    ValueTask<IEnumerable<QuestionAnswer>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}