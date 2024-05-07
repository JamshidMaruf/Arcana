using Arcana.Service.Configurations;
using Arcana.WebApi.Models.QuestionAnswers;

namespace Arcana.WebApi.ApiServices.QuestionAnswers;

public interface IQuestionAnswerApiService
{
    ValueTask<QuestionAnswerViewModel> PostAsync(QuestionAnswerCreateModel createModel);
    ValueTask<QuestionAnswerViewModel> PutAsync(long id, QuestionAnswerUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<QuestionAnswerViewModel> GetAsync(long id);
    ValueTask<IEnumerable<QuestionAnswerViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
