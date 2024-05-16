using Arcana.Service.Configurations;
using Arcana.WebApi.Models.CourseStars;
using Arcana.WebApi.Models.Instructors;

namespace Arcana.WebApi.ApiServices.CourseStars;

public interface ICourseStarApiService
{
    ValueTask<CourseStarViewModel> PostAsync(CourseStarCreateModel createModel);
    ValueTask<CourseStarViewModel> PutAsync(long id, CourseStarUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseStarViewModel> GetAsync(long id);
    ValueTask<IEnumerable<CourseStarViewModel>> GetAsync(PaginationParams @params,
                                                         Filter filter,
                                                         string search = null);
}
