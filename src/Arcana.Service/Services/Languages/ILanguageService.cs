using System.ComponentModel.DataAnnotations;
using Arcana.Domain.Entities.Languages;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.Languages;

public interface ILanguageService
{
    ValueTask<Language> CreateAsync(Language language);
    ValueTask<Language> UpdateAsync(long id, Language language);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Language> GetByIdAsync(long id);
    ValueTask<IEnumerable<Language>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
