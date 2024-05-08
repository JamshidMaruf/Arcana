using Arcana.Domain.Entities.Lessons;
using Arcana.Service.Configurations;
using Arcana.WebApi.Models.InstructorComments;

namespace Arcana.WebApi.ApiServices.InstructorComments;

public class InstructorCommentApiService : IInstructorCommentsApiService
{

    public async ValueTask<InstructorCommentViewModel> PostAsync(InstructorCommentCreateModel model)
    {

        await createModelValidator.EnsureValidatedAsync(model);
        var createdLessonComment = await lessonCommentService.CreateAsync(mapper.Map<LessonComment>(createModel));
        return mapper.Map<LessonCommentViewModel>(createdLessonComment);
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InstructorCommentViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<InstructorCommentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InstructorCommentViewModel> PutAsync(long id, InstructorCommentUpdateModel model)
    {
        throw new NotImplementedException();
    }
}
