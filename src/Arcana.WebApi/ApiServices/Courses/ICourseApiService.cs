using Arcana.Service.Configurations;
using Arcana.WebApi.Models.Assets;
using Arcana.WebApi.Models.Courses;

namespace Arcana.WebApi.ApiServices.Courses;

public interface ICourseApiService
{
    ValueTask<CourseViewModel> PostAsync(CourseCreateModel createModel);
    ValueTask<CourseViewModel> PutAsync(long id, CourseUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseViewModel> GetAsync(long id);
    ValueTask<IEnumerable<CourseViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<CourseViewModel> UploadFileAsync(long id, AssetCreateModel assetCreateModel);
    ValueTask<CourseViewModel> DeleteFileAsync(long id);
}
