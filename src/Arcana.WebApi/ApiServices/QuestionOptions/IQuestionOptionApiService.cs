using Arcana.Service.Configurations;
using Arcana.WebApi.Models.QuestionOptions;

namespace Arcana.WebApi.ApiServices.QuestionOptions;

public interface IQuestionOptionApiService
{
    ValueTask<QuestionOptionViewModel> PostAsync(QuestionOptionCreateModel createModel);
    ValueTask<QuestionOptionViewModel> PutAsync(long id, QuestionOptionUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<QuestionOptionViewModel> GetAsync(long id);
    ValueTask<IEnumerable<QuestionOptionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
