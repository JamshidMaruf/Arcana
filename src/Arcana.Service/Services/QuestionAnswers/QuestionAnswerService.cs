using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Arcana.Service.Services.QuestionAnswers;

public class QuestionAnswerService : IQuestionAnswerService
{
    public ValueTask<QuestionAnswer> CreateAsync(QuestionAnswer questionAnswer)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<QuestionAnswer> DeleteFileAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<QuestionAnswer>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<QuestionAnswer> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<QuestionAnswer> UpdateAsync(long id, QuestionAnswer questionAnswer)
    {
        throw new NotImplementedException();
    }

    public ValueTask<QuestionAnswer> UploadFileAsync(long id, IFormFile file)
    {
        throw new NotImplementedException();
    }
}