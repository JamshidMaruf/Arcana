using Arcana.Domain.Entities.QuizQuestions;
using Arcana.Service.Configurations;
using Arcana.Service.Services.QuizQuestions;
using Arcana.WebApi.Models.QuizQuestions;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.QuizQuestions;

public class QuizQuestionApiService(IMapper mapper, IQuizQuestionService quizQuestionService) : IQuizQuestionApiService
{
    public async ValueTask<QuizQuestionViewModel> PostAsync(QuizQuestionCreateModel createModel)
    {
        var mappedQuizQuestion = mapper.Map<QuizQuestion>(createModel);
        var createdQuizQuestion = await quizQuestionService.CreateAsync(mappedQuizQuestion);
        return mapper.Map<QuizQuestionViewModel>(createdQuizQuestion);
    }

    public async ValueTask<QuizQuestionViewModel> PutAsync(long id, QuizQuestionUpdateModel updateModel)
    {
        var mappedQuizQuestion = mapper.Map<QuizQuestion>(updateModel);
        var updatedQuizQuestion = await quizQuestionService.UpdateAsync(id, mappedQuizQuestion);
        return mapper.Map<QuizQuestionViewModel>(updatedQuizQuestion);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await quizQuestionService.DeleteAsync(id);
    }

    public async ValueTask<QuizQuestionViewModel> GetAsync(long id)
    {
        var existQuizQuestion = await quizQuestionService.GetByIdAsync(id);
        return mapper.Map<QuizQuestionViewModel>(existQuizQuestion);
    }

    public async ValueTask<IEnumerable<QuizQuestionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var quizQuestions = await quizQuestionService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<QuizQuestionViewModel>>(quizQuestions);
    }
}