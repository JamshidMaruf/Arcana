using Arcana.Service.Configurations;
using Arcana.WebApi.Models.Lessons;

namespace Arcana.WebApi.ApiServices.Lessons;

public interface ILessonApiService
{
    ValueTask<LessonViewModel> PostAsync(LessonCreateModel createModel);
    ValueTask<LessonViewModel> PutAsync(long id, LessonUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<LessonViewModel> GetAsync(long id);
    ValueTask<IEnumerable<LessonViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}