using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;
using Arcana.Service.Services.InstructorStars;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.InstructorStars;
using Arcana.WebApi.Validators.InstructorStars;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.InstructorStars;

public class InstructorStarApiService(IMapper mapper,
IInstructorStarService instructorStarsService,
InstructorStarCreateModelValidator createModelValidator,
InstructorStarUpdateModelValidator updateModelValidator) : IInstructorStarApiService
{
    public async ValueTask<InstructorStarViewModel> PostAsync(InstructorStarCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedInstructorStars = mapper.Map<InstructorStar>(createModel);
        var createdInstructorStars = await instructorStarsService.CreateAsync(mappedInstructorStars);
        return mapper.Map<InstructorStarViewModel>(createdInstructorStars);
    }

    public async ValueTask<InstructorStarViewModel> PutAsync(long id, InstructorStarUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedInstructorStars = mapper.Map<InstructorStar>(updateModel);
        var updatedInstructorStars = await instructorStarsService.UpdateAsync(id, mappedInstructorStars);
        return mapper.Map<InstructorStarViewModel>(updatedInstructorStars);
    }
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await instructorStarsService.DeleteAsync(id);
    }

    public async ValueTask<InstructorStarViewModel> GetAsync(long id)
    {
        var instructorStar = await instructorStarsService.GetByIdAsync(id);
        return mapper.Map<InstructorStarViewModel>(instructorStar);
    }

    public async ValueTask<IEnumerable<InstructorStarViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var instructorStars = await instructorStarsService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<InstructorStarViewModel>>(instructorStars);
    }
}