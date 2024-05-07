using Arcana.Service.Configurations;
using Arcana.WebApi.Models.LessonComments;

namespace Arcana.WebApi.ApiServices.LessonComments;

public interface ILessonCommentApiService
{
    ValueTask<LessonCommentViewModel> PostAsync(LessonCommentCreateModel createModel);
    ValueTask<LessonCommentViewModel> PutAsync(long id, LessonCommentUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<LessonCommentViewModel> GetAsync(long id);
    ValueTask<IEnumerable<LessonCommentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}