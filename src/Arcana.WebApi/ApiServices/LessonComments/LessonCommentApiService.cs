using AutoMapper;
using Arcana.WebApi.Extensions;
using Arcana.Service.Configurations;
using Arcana.Domain.Entities.Lessons;
using Arcana.WebApi.Models.LessonComments;
using Arcana.Service.Services.LessonComments;
using Arcana.WebApi.Validators.LessonComments;

namespace Arcana.WebApi.ApiServices.LessonComments;

public class LessonCommentApiService(
    IMapper mapper, 
    ILessonCommentService lessonCommentService,
    LessonCommentCreateModelValidator createModelValidator,
    LessonCommentUpdateModelValidator updateModelValidator) : ILessonCommentApiService
{
    public async ValueTask<LessonCommentViewModel> PostAsync(LessonCommentCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var createdLessonComment = await lessonCommentService.CreateAsync(mapper.Map<LessonComment>(createModel));
        return mapper.Map<LessonCommentViewModel>(createdLessonComment);
    }

    public async ValueTask<LessonCommentViewModel> PutAsync(long id, LessonCommentUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var updatedLessonComment = await lessonCommentService.UpdateAsync(id, mapper.Map<LessonComment>(updateModel));
        return mapper.Map<LessonCommentViewModel>(updatedLessonComment);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await lessonCommentService.DeleteAsync(id);
    }

    public async ValueTask<LessonCommentViewModel> GetAsync(long id)
    {
        var lessonComment = await lessonCommentService.GetByIdAsync(id);
        return mapper.Map<LessonCommentViewModel>(lessonComment);
    }

    public async ValueTask<IEnumerable<LessonCommentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var lessonComments = await lessonCommentService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<LessonCommentViewModel>>(lessonComments);
    }
}