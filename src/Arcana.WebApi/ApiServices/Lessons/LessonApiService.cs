using Arcana.Domain.Entities.Lessons;
using Arcana.Service.Configurations;
using Arcana.Service.Services.Lessons;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.Assets;
using Arcana.WebApi.Models.Lessons;
using Arcana.WebApi.Validators.Assets;
using Arcana.WebApi.Validators.Lessons;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.Lessons;

public class LessonApiService(
    IMapper mapper,
    ILessonService lessonService,
    LessonCreateModelValidator createModelValidator,
    LessonUpdateModelValidator updateModelValidator,
    AssetCreateModelValidator assetValidator) : ILessonApiService
{
    public async ValueTask<LessonViewModel> PostAsync(LessonCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedLesson = mapper.Map<Lesson>(createModel);
        var createdLesson = await lessonService.CreateAsync(mappedLesson);
        return mapper.Map<LessonViewModel>(createdLesson);
    }

    public async ValueTask<LessonViewModel> PutAsync(long id, LessonUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedLesson = mapper.Map<Lesson>(updateModel);
        var updatedLesson = await lessonService.UpdateAsync(id, mappedLesson);
        return mapper.Map<LessonViewModel>(updatedLesson);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await lessonService.DeleteAsync(id);
    }

    public async ValueTask<LessonViewModel> GetAsync(long id)
    {
        var lesson = await lessonService.GetByIdAsync(id);
        return mapper.Map<LessonViewModel>(lesson);
    }

    public async ValueTask<IEnumerable<LessonViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var lessons = await lessonService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<LessonViewModel>>(lessons);
    }

    public async ValueTask<LessonViewModel> UploadFileAsync(long id, AssetCreateModel assetCreateModel)
    {
        await assetValidator.EnsureValidatedAsync(assetCreateModel);
        var lesson = await lessonService.UploadFileAsync(id, assetCreateModel.File, assetCreateModel.FileType);
        return mapper.Map<LessonViewModel>(lesson);
    }

    public async ValueTask<LessonViewModel> DeleteFileAsync(long id)
    {
        var lesson = await lessonService.DeleteFileAsync(id);
        return mapper.Map<LessonViewModel>(lesson);
    }
}