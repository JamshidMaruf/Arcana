using Arcana.Service.Configurations;
using Arcana.WebApi.Models.QuizApplications;

namespace Arcana.WebApi.ApiServices.QuizApplications;

public interface IQuizApplicationApiService
{
    ValueTask<QuizApplicationViewModel> PostAsync(QuizApplicationCreateModel createModel);
    ValueTask<QuizApplicationViewModel> PutAsync(long id, QuizApplicationUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<QuizApplicationViewModel> GetAsync(long id);
    ValueTask<IEnumerable<QuizApplicationViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
