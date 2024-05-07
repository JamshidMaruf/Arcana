using Arcana.Domain.Entities.CourseComments;
using Arcana.Service.Configurations;
using Arcana.Service.Services.CourseComments;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.CourseComments;
using Arcana.WebApi.Validators.CourseComments;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.CourseComments;

public class CourseCommentApiService(
    IMapper mapper,
    ICourseCommentService courseCommentService,
    CourseCommentCreateModelValidator createModelValidator,
    CourseCommentUpdateModelValidator updateModelValidator) : ICourseCommentApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await courseCommentService.DeleteAsync(id);
    }

    public async ValueTask<CourseCommentViewModel> GetAsync(long id)
    {
        var courseComment = await courseCommentService.GetByIdAsync(id);
        return mapper.Map<CourseCommentViewModel>(courseComment);
    }

    public async ValueTask<IEnumerable<CourseCommentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var courseComment = await courseCommentService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CourseCommentViewModel>>(courseComment);
    }

    public async ValueTask<CourseCommentViewModel> PostAsync(CourseCommentCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedCourseComment = mapper.Map<CourseComment>(createModel);
        var createdCourseComment = await courseCommentService.CreateAsync(mappedCourseComment);
        return mapper.Map<CourseCommentViewModel>(createdCourseComment);
    }

    public async ValueTask<CourseCommentViewModel> PutAsync(long id, CourseCommentUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedCourseComment = mapper.Map<CourseComment>(updateModel);
        var createdCourseComment = await courseCommentService.UpdateAsync(id, mappedCourseComment);
        return mapper.Map<CourseCommentViewModel>(createdCourseComment);
    }
}
