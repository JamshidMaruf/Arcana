using Arcana.Domain.Entities.Questions;
using Arcana.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Arcana.Service.Services.Questions;

public interface IQuestionService
{
    ValueTask<Question> CreateAsync(Question question);
    ValueTask<Question> UpdateAsync(long id, Question question);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Question> GetByIdAsync(long id);
    ValueTask<IEnumerable<Question>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<Question> UploadFileAsync(long id, IFormFile file);
    ValueTask<Question> DeleteFileAsync(long id);
    ValueTask<List<Question>> GetShuffledListAsync(long moduleId, int questionCount);
}