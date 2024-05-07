using Arcana.Domain.Entities.Questions;
using Arcana.Service.Configurations;
using Arcana.Service.Services.Questions;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.Questions;
using Arcana.WebApi.Validators.Questions;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.Questions;

public class QuestionApiService(
    IMapper mapper,
    IQuestionService questionService,
    QuestionCreateModelValidator questionCreateModelValidator,
    QuestionUpdateModelValidator questionUpdateModelValidator) : IQuestionApiService
{
    public async ValueTask<QuestionViewModel> PostAsync(QuestionCreateModel createModel)
    {
        await questionCreateModelValidator.EnsureValidatedAsync(createModel);
        var mappedQuestion = mapper.Map<Question>(createModel);
        var createdQuestion = await questionService.CreateAsync(mappedQuestion);
        return mapper.Map<QuestionViewModel>(createdQuestion);
    }

    public async ValueTask<QuestionViewModel> PutAsync(long id, QuestionUpdateModel updateModel)
    {
        await questionUpdateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedQuestion = mapper.Map<Question>(updateModel);
        var updatedQuestion = await questionService.UpdateAsync(id, mappedQuestion);
        return mapper.Map<QuestionViewModel>(updatedQuestion);
    }
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await questionService.DeleteAsync(id);
    }

    public async ValueTask<QuestionViewModel> GetAsync(long id)
    {
        var existQuestion = await questionService.GetByIdAsync(id);
        return mapper.Map<QuestionViewModel>(existQuestion);
    }

    public async ValueTask<IEnumerable<QuestionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var questions = await questionService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<QuestionViewModel>>(questions);
    }

    public async ValueTask<QuestionViewModel> UploadPictureAsync(long id, IFormFile picture)
    {
        var existQuestion = await questionService.UploadFileAsync(id, picture);
        return mapper.Map<QuestionViewModel>(existQuestion);
    }

    public async ValueTask<QuestionViewModel> DeletePictureAsync(long id)
    {
        var existQuestion = await questionService.DeleteFileAsync(id);
        return mapper.Map<QuestionViewModel>(existQuestion);
    }
}