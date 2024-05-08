using Arcana.Domain.Entities.QuestionAnswer1;
using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Arcana.Service.Services.QuestionAnswers1;

public interface IQuestionAnswer1Service
{
    ValueTask<QuestionAnswer1> CreateAsync(QuestionAnswer1 questionAnswer);
    ValueTask<QuestionAnswer1> UpdateAsync(long id, QuestionAnswer1 questionAnswer);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<QuestionAnswer1> GetByIdAsync(long id);
    ValueTask<IEnumerable<QuestionAnswer1>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}