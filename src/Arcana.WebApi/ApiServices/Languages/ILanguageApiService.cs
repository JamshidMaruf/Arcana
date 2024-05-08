using Arcana.Service.Configurations;
using Arcana.WebApi.Models.Languages;

namespace Arcana.WebApi.ApiServices.Languages;

public interface ILanguageApiService
{
    ValueTask<LanguageViewModel> PostAsync(LanguageCreateModel createModel);
    ValueTask<LanguageViewModel> PutAsync(long id, LanguageUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<LanguageViewModel> GetAsync(long id);
    ValueTask<IEnumerable<LanguageViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
