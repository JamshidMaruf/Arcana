using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Service.Configurations;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.QuestionAnswers;
using Arcana.WebApi.Validators.QuestionAnswers;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.QuestionAnswers;

public class QuestionAnswerApiService(
    IMapper mapper, IQuestionAnswerService questionAnswerService,
    QuestionAnswerCreateModelValidator createValidator,
    QuestionAnswerUpdateModelValidator updateValidator) : IQuestionAnswerApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await questionAnswerService.DeleteAsync(id);
    }

    public async ValueTask<QuestionAnswerViewModel> GetAsync(long id)
    {
        var questionAnswer = await questionAnswerService.GetByIdAsync(id);
        return mapper.Map<QuestionAnswerViewModel>(questionAnswer);
    }

    public async ValueTask<IEnumerable<QuestionAnswerViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var questionAnswer = await questionAnswerService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<QuestionAnswerViewModel>>(questionAnswer);
    }

    public async ValueTask<QuestionAnswerViewModel> PostAsync(QuestionAnswerCreateModel createModel)
    {
        await createValidator.EnsureValidatedAsync(createModel);
        var mappedQuestionAnswer = mapper.Map<QuestionAnswer>(createModel);
        var createdQuestionAnswer = await questionAnswerService.CreateAsync(mappedQuestionAnswer);
        return mapper.Map<QuestionAnswerViewModel>(createdQuestionAnswer);
    }

    public async ValueTask<QuestionAnswerViewModel> PutAsync(long id, QuestionAnswerUpdateModel updateModel)
    {
        await updateValidator.EnsureValidatedAsync(updateModel);
        var mappedQuestionAnswer = mapper.Map<QuestionAnswer>(updateModel);
        var updatedQuestionAnswer = await questionAnswerService.UpdateAsync(id, mappedQuestionAnswer);
        return mapper.Map<QuestionAnswerViewModel>(updatedQuestionAnswer);
    }
}
