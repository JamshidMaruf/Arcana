using Arcana.Service.Configurations;
using Arcana.WebApi.Models.CourseCategories;
using Arcana.WebApi.Models.CourseComments;

namespace Arcana.WebApi.ApiServices.CourseComments;

public interface ICourseCommentApiService
{
    ValueTask<CourseCommentViewModel> PostAsync(CourseCommentCreateModel createModel);
    ValueTask<CourseCommentViewModel> PutAsync(long id, CourseCommentUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseCommentViewModel> GetAsync(long id);
    ValueTask<IEnumerable<CourseCommentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}

