using Arcana.Service.Configurations;
using Arcana.WebApi.Models.QuizQuestions;

namespace Arcana.WebApi.ApiServices.QuizQuestions;

public interface IQuizQuestionApiService
{
    ValueTask<QuizQuestionViewModel> PostAsync(QuizQuestionCreateModel createModel);
    ValueTask<QuizQuestionViewModel> PutAsync(long id, QuizQuestionUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<QuizQuestionViewModel> GetAsync(long id);
    ValueTask<IEnumerable<QuizQuestionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}