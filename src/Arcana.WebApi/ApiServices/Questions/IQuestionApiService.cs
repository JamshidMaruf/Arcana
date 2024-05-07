using Arcana.Service.Configurations;
using Arcana.WebApi.Models.Questions;

namespace Arcana.WebApi.ApiServices.Questions;

public interface IQuestionApiService
{
    ValueTask<QuestionViewModel> PostAsync(QuestionCreateModel createModel);
    ValueTask<QuestionViewModel> PutAsync(long id, QuestionUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<QuestionViewModel> GetAsync(long id);
    ValueTask<IEnumerable<QuestionViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<QuestionViewModel> UploadPictureAsync(long id, IFormFile picture);
    ValueTask<QuestionViewModel> DeletePictureAsync(long id);
}