using AutoMapper;
using Arcana.WebApi.Extensions;
using Arcana.Service.Configurations;
using Arcana.WebApi.Models.QuizApplications;
using Arcana.Domain.Entities.QuizApplications;
using Arcana.Service.Services.QuizApplications;
using Arcana.WebApi.Validators.QuizApplications;

namespace Arcana.WebApi.ApiServices.QuizApplications;

public class QuizApplicationApiService(
    IMapper mapper,
    IQuizApplicationService quizApplicationService,
    QuizApplicationCreateModelValidator createModelValidator,
    QuizApplicationUpdateModelValidator updateModelValidator) : IQuizApplicationApiService
{
    public async ValueTask<QuizApplicationViewModel> PostAsync(QuizApplicationCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var createdQuizApplication = await quizApplicationService.CreateAsync(mapper.Map<QuizApplication>(createModel));
        return mapper.Map<QuizApplicationViewModel>(createdQuizApplication);
    }

    public async ValueTask<QuizApplicationViewModel> PutAsync(long id, QuizApplicationUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var updatedQuizApplication = await quizApplicationService.UpdateAsync(id, mapper.Map<QuizApplication>(updateModel));
        return mapper.Map<QuizApplicationViewModel>(updatedQuizApplication);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await quizApplicationService.DeleteAsync(id);
    }

    public async ValueTask<QuizApplicationViewModel> GetAsync(long id)
    {
        var quizModule = await quizApplicationService.GetByIdAsync(id);
        return mapper.Map<QuizApplicationViewModel>(quizModule);
    }

    public async ValueTask<IEnumerable<QuizApplicationViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var quizApplications = await quizApplicationService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<QuizApplicationViewModel>>(quizApplications);
    }
}