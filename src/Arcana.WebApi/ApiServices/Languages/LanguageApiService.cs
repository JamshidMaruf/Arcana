using Arcana.Domain.Entities.Languages;
using Arcana.Service.Configurations;
using Arcana.Service.Services.Languages;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.Languages;
using Arcana.WebApi.Validators.Languages;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.Languages;

public class LanguageApiService(IMapper mapper,
ILanguageService languageService,
LanguageCreateModelValidator createModelValidator,
LanguageUpdateModelValidator updateModelValidator) : ILanguageApiService
{

    public async ValueTask<LanguageViewModel> PostAsync(LanguageCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedLanguage = mapper.Map<Language>(createModel);
        var createdLanguage = await languageService.CreateAsync(mappedLanguage);
        return mapper.Map<LanguageViewModel>(createdLanguage);
    }
    public async ValueTask<LanguageViewModel> PutAsync(long id, LanguageUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedLanguage = mapper.Map<Language>(updateModel);
        var updateLanguage = await languageService.UpdateAsync(id, mappedLanguage);
        return mapper.Map<LanguageViewModel>(updateLanguage);
    }
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await languageService.DeleteAsync(id);
    }

    public async ValueTask<LanguageViewModel> GetAsync(long id)
    {
        var language = await languageService.GetByIdAsync(id);
        return mapper.Map<LanguageViewModel>(language);
    }

    public async ValueTask<IEnumerable<LanguageViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var languages = await languageService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<LanguageViewModel>>(languages);
    }

}
