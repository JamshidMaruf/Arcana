using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;
using Arcana.Service.Services.InstructorComments;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.InstructorComments;
using Arcana.WebApi.Validators.InstructorComments;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.InstructorComments;

public class InstructorCommentApiService(IMapper mapper, 
    IInstructorCommentService service, 
    InstructorCommentCreateModelValidator instructorCommentCreateModelValidator,
    InstructorCommentUpdateModelValidator instructorCommentUpdateModelValidator)
    : IInstructorCommentApiService
{

    public async ValueTask<InstructorCommentViewModel> PostAsync(InstructorCommentCreateModel model)
    {

        await instructorCommentCreateModelValidator.EnsureValidatedAsync(model);
        var createdInstructorComment = await service.CreateAsync(mapper.Map<InstructorComment>(model));
        return mapper.Map<InstructorCommentViewModel>(createdInstructorComment);
    }

    public async ValueTask<InstructorCommentViewModel> PutAsync(long id, InstructorCommentUpdateModel model)
    {
        await instructorCommentUpdateModelValidator.EnsureValidatedAsync(model);
        var updatedInstructorComment = await service.UpdateAsync(id, mapper.Map<InstructorComment>(model));
        return mapper.Map<InstructorCommentViewModel>(updatedInstructorComment);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await service.DeleteAsync(id);
    }

    public async ValueTask<InstructorCommentViewModel> GetAsync(long id)
    {
        var InstructorComment = await service.GetByIdAsync(id);
        return mapper.Map<InstructorCommentViewModel>(InstructorComment);
    }

    public async ValueTask<IEnumerable<InstructorCommentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var instructorComments = await service.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<InstructorCommentViewModel>>(instructorComments);
    }
}
