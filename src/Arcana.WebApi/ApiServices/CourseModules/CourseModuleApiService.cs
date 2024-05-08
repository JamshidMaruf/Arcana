using Arcana.Domain.Entities.Courses;
using Arcana.Service.Configurations;
using AutoMapper;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.CourseModules;
using Arcana.Service.Services.CourseModules;
using Arcana.WebApi.Validators.CourseModules;

namespace Arcana.WebApi.ApiServices.CourseModules;

public class CourseModuleApiService(
    IMapper mapper,
    ICourseModuleService courseModuleService,
    CourseModuleCreateModelValidator createModelValidator,
    CourseModuleUpdateModelValidator updateModelValidator) : ICourseModuleApiService
{ 
    public async ValueTask<CourseModuleViewModel> PostAsync(CourseModuleCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var createdCourseModule = await courseModuleService.CreateAsync(mapper.Map<CourseModule>(createModel));
        return mapper.Map<CourseModuleViewModel>(createdCourseModule);
    }

    public async ValueTask<CourseModuleViewModel> PutAsync(long id, CourseModuleUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var updatedCourseModule = await courseModuleService.UpdateAsync(id, mapper.Map<CourseModule>(updateModel));
        return mapper.Map<CourseModuleViewModel>(updatedCourseModule);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await courseModuleService.DeleteAsync(id);
    }

    public async ValueTask<CourseModuleViewModel> GetAsync(long id)
    {
        var courseModule = await courseModuleService.GetByIdAsync(id);
        return mapper.Map<CourseModuleViewModel>(courseModule);
    }

    public async ValueTask<IEnumerable<CourseModuleViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var courseModules = await courseModuleService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CourseModuleViewModel>>(courseModules);
    }
}