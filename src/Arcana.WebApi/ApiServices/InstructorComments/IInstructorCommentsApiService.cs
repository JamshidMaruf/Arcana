using Arcana.Service.Configurations;
using Arcana.WebApi.Models.InstructorComments;

namespace Arcana.WebApi.ApiServices.InstructorComments;

public interface IInstructorCommentsApiService
{

    ValueTask<InstructorCommentViewModel > PostAsync(InstructorCommentCreateModel model);
    ValueTask<InstructorCommentViewModel> PutAsync(long id, InstructorCommentUpdateModel model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<InstructorCommentViewModel> GetAsync(long id);
    ValueTask<IEnumerable<InstructorCommentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
