using Arcana.Domain.Entities.Courses;
using Arcana.Service.Configurations;
using Arcana.Service.Services.CourseStars;
using Arcana.WebApi.Models.CourseStars;
using Arcana.WebApi.Validators.CourseStars;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.CourseStars;

public class CourseStarApiService(IMapper mapper,
                                  ICourseStarService courseStarService,
                                  CourseStarCreateModelValidator createModelValidator,
                                  CourseStarUpdateModelValidator updateModelValidator) : ICourseStarApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await courseStarService.DeleteAsync(id);
    }

    public async ValueTask<CourseStarViewModel> GetAsync(long id)
    {
        var courseStar = await courseStarService.GetByIdAsync(id);
        return mapper.Map<CourseStarViewModel>(courseStar);
    }

    public async ValueTask<IEnumerable<CourseStarViewModel>> GetAsync(PaginationParams @params,
                                                                Filter filter,
                                                                string search = null)
    {
        var courseStars = await courseStarService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CourseStarViewModel>>(courseStars);
    }

    public async ValueTask<CourseStarViewModel> PostAsync(CourseStarCreateModel createModel)
    {
        var mappedCourseStar = mapper.Map<CourseStar>(createModel);
        var courseStar = await courseStarService.CreateAsync(mappedCourseStar);
        return mapper.Map<CourseStarViewModel>(courseStar);
    }

    public async ValueTask<CourseStarViewModel> PutAsync(long id, CourseStarUpdateModel updateModel)
    {
        var mappedCourseStar = mapper.Map<CourseStar>(updateModel);
        var courseStar = await courseStarService.UpdateAsync(id, mappedCourseStar);
        return mapper.Map<CourseStarViewModel>(courseStar);
    }
}
