using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Languages;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.Languages;

public class LanguageService(IUnitOfWork unitOfWork) : ILanguageService
{
    public async ValueTask<Language> CreateAsync(Language language)
    {
        var existLanguage = await unitOfWork.Languages.SelectAsync(lan => lan.Name == language.Name && !lan.IsDeleted);
        if (existLanguage is not null)
            throw new AlreadyExistException($"This language already exist Name: {language.Name}");
        
        language.CreatedByUserId = HttpContextHelper.UserId;
        var caratedLanguage = await unitOfWork.Languages.InsertAsync(language);

        await unitOfWork.SaveAsync();

        return caratedLanguage;
    }
    public async ValueTask<Language> UpdateAsync(long id, Language language)
    {
        var existLanguage = await unitOfWork.Languages.SelectAsync(lan =>lan.Id == id && !lan.IsDeleted)
            ??throw new NotFoundException($"Language is not found with Id: {id}");

        existLanguage.Name = language.Name;
        existLanguage.ShortName = language.ShortName;
        existLanguage.CreatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.Languages.UpdateAsync(existLanguage);
        await unitOfWork.SaveAsync();

        return existLanguage;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existLanguage = await unitOfWork.Languages.SelectAsync(lan => lan.Id == id && !lan.IsDeleted)
            ??throw new NotFoundException($"Language is not found with Id: {id}");
        
        existLanguage.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Languages.DeleteAsync(existLanguage);

        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<Language>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var languages = unitOfWork.Languages
            .SelectAsQueryable(expression: lan => !lan.IsDeleted,isTracked: false)
            .OrderBy(filter);
        
        return await languages.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Language> GetByIdAsync(long id)
    {
        var existLanguage = await unitOfWork.Languages.SelectAsync(lan => lan.Id == id && !lan.IsDeleted)
            ??throw new NotFoundException($"Language is not found with Id:{id}");

        return existLanguage;
    }
}
