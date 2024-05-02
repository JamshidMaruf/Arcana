using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;
using Arcana.Service.Services.Instructors;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.Instructors;
using Arcana.WebApi.Validators.Instructors;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.Instructors;

public class InstructorApiService(
    IMapper mapper,
    IInstructorService instructorService,
    InstructorCreateModelValidator instructorCreateModelValidator,
    InstructorUpdateModelValidator instructorUpdateModelValidator
    ) : IInstructorApiService
{
    public async ValueTask<InstructorViewModel> PostAsync(InstructorCreateModel createModel)
    {
        await instructorCreateModelValidator.EnsureValidatedAsync(createModel);
        var mappedInstructor = mapper.Map<Instructor>(createModel);
        var createdInstructor = await instructorService.CreateAsync(mappedInstructor);
        return mapper.Map<InstructorViewModel>(createdInstructor);
    }

    public async ValueTask<InstructorViewModel> PutAsync(long id, InstructorUpdateModel updateModel)
    {
        await instructorUpdateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedInstructor = mapper.Map<Instructor>(updateModel);
        var updateInstructor = await instructorService.UpdateAsync(id, mappedInstructor);
        return mapper.Map<InstructorViewModel>(updateInstructor);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await instructorService.DeleteAsync(id);
    }

    public async ValueTask<InstructorViewModel> GetAsync(long id)
    {
        var existInstructor = await instructorService.GetByIdAsync(id);
        return mapper.Map<InstructorViewModel>(existInstructor);
    }

    public async ValueTask<IEnumerable<InstructorViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var instructors = await instructorService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<InstructorViewModel>>(instructors);
    }

    public async ValueTask<InstructorViewModel> UploadPictureAsync(long id, IFormFile picture)
    {
        var existInstructor = await instructorService.UploadPictureAsync(id, picture);
        return mapper.Map<InstructorViewModel>(existInstructor);
    }

    public async ValueTask<InstructorViewModel> DeletePictureAsync(long id)
    {
        var existInstructor = await instructorService.DeletePictureAsync(id);
        return mapper.Map<InstructorViewModel>(existInstructor);
    }
}
