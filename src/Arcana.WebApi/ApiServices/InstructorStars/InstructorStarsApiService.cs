using Arcana.Service.Configurations;
using Arcana.Service.Services.InstructorStarsService;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.InstructorStars;
using Arcana.WebApi.Validators.InstructorStars;
using Arcana.Domain.Entities.Instructors;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.InstructorsStars;

public class InstructorStarsApiService(IMapper mapper,
IInstructorStarsService instructorStarsService,
InstructorStarsCreateModelValidator createModelValidator,
InstructorStarsUpdateModelValidator updateModelValidator) : IInsturctorStarsApiService
{
    public async ValueTask<InstructorStarsViewModel> PostAsync(InstructorStarsCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedInstructorStars = mapper.Map<InstructorStars>(createModel);
        var createdInstructorStars = await instructorStarsService.CreateAsync(mappedInstructorStars);
        return mapper.Map<InstructorStarsViewModel>(createdInstructorStars);
    }

    public async ValueTask<InstructorStarsViewModel> PutAsync(long id, InstructorStarsUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedInstructorStars = mapper.Map<InstructorStars>(updateModel);
        var updatedInstructorStars = await instructorStarsService.UpdateAsync(id,mappedInstructorStars);
        return mapper.Map<InstructorStarsViewModel>(updatedInstructorStars);
    }
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await instructorStarsService.DeleteAsync(id);
    }

    public async ValueTask<InstructorStarsViewModel> GetAsync(long id)
    {
        var instructorStar = await instructorStarsService.GetByIdAsync(id);
        return mapper.Map<InstructorStarsViewModel>(instructorStar);
    }

    public async ValueTask<IEnumerable<InstructorStarsViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var instructorStars = await instructorStarsService.GetAllAsync(@params,filter, search);
        return mapper.Map<IEnumerable<InstructorStarsViewModel>>(instructorStars);
    }

}
