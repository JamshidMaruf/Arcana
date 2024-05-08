using Arcana.Domain.Entities.CourseCategories;
using Arcana.Service.Configurations;
using Arcana.Service.Services.CourseCategories;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.CourseCategories;
using Arcana.WebApi.Validators.CourseCategories;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.CourseCategories;

public class CourseCategoryApiService(
    IMapper mapper,
    ICourseCategoryService courseCategoryService,
    CourseCategoryCreateModelValidator createModelValidator,
    CourseCategoryUpdateModelValidator updateModelValidator) : ICourseCategoryApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await courseCategoryService.DeleteAsync(id);
    }

    public async ValueTask<CourseCategoryViewModel> GetAsync(long id)
    {
        var courseCategory = await courseCategoryService.GetByIdAsync(id);
        return mapper.Map<CourseCategoryViewModel>(courseCategory);
    }

    public async ValueTask<IEnumerable<CourseCategoryViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var courseCategory = await courseCategoryService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CourseCategoryViewModel>>(courseCategory);
    }

    public async ValueTask<CourseCategoryViewModel> PostAsync(CourseCategoryCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedCourseCategory = mapper.Map<CourseCategory>(createModel);
        var createdCourseCategory = await courseCategoryService.CreateAsync(mappedCourseCategory);
        return mapper.Map<CourseCategoryViewModel>(createdCourseCategory);
    }

    public async ValueTask<CourseCategoryViewModel> PutAsync(long id, CourseCategoryUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedCourseCategory = mapper.Map<CourseCategory>(updateModel);
        var createdCourseCategory = await courseCategoryService.UpdateAsync(id, mappedCourseCategory);
        return mapper.Map<CourseCategoryViewModel>(createdCourseCategory);
    }
}
