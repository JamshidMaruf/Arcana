using Arcana.Domain.Entities.QuestionOptions;
using Arcana.Service.Configurations;
using Arcana.Service.Services.QuestionOptions;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.QuestionOptions;
using Arcana.WebApi.Validators.QuestionOptions;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.QuestionOptions;

public class QuestionOptionApiService(
    IMapper mapper, IQuestionOptionService questionOptionService,
    QuestionOptionCreateModelValidator createValidator,
    QuestionOptionUpdateModelValidator updateValidator) : IQuestionOptionApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await questionOptionService.DeleteAsync(id);
    }

    public async ValueTask<QuestionOptionViewModel> GetAsync(long id)
    {
        var questionOption = await questionOptionService.GetByIdAsync(id);
        return mapper.Map<QuestionOptionViewModel>(questionOption);
    }

    public async ValueTask<IEnumerable<QuestionOptionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var questionOption = await questionOptionService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<QuestionOptionViewModel>>(questionOption);
    }

    public async ValueTask<QuestionOptionViewModel> PostAsync(QuestionOptionCreateModel createModel)
    {
        await createValidator.EnsureValidatedAsync(createModel);
        var mappedQuestionOption = mapper.Map<QuestionOption>(createModel);
        var createdQuestionOption = await questionOptionService.CreateAsync(mappedQuestionOption);
        return mapper.Map<QuestionOptionViewModel>(createdQuestionOption);
    }

    public async ValueTask<QuestionOptionViewModel> PutAsync(long id, QuestionOptionUpdateModel updateModel)
    {
        await updateValidator.EnsureValidatedAsync(updateModel);
        var mappedQuestionOption = mapper.Map<QuestionOption>(updateModel);
        var updatedQuestionOption = await questionOptionService.UpdateAsync(id, mappedQuestionOption);
        return mapper.Map<QuestionOptionViewModel>(updatedQuestionOption);
    }
}
