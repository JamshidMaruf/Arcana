﻿using Arcana.Domain.Entities.Courses;
using Arcana.Service.Configurations;
using Arcana.Service.Services.Courses;
using Arcana.Service.Services.Lessons;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.Assets;
using Arcana.WebApi.Models.Courses;
using Arcana.WebApi.Models.Lessons;
using Arcana.WebApi.Validators.Assets;
using Arcana.WebApi.Validators.Courses;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.Courses;

public class CourseApiService(IMapper mapper,
    ICourseService courseService,
    CourseCreateModelValidator createValidator,
    CourseUpdateModelValidator updateValidator,
    AssetCreateModelValidator assetValidator) : ICourseApiService
{
    public async ValueTask<CourseViewModel> PostAsync(CourseCreateModel createModel)
    {
        await createValidator.EnsureValidatedAsync(createModel);
        var mappedCourse = mapper.Map<Course>(createModel);
        var createdCourse = await courseService.CreateAsync(mappedCourse);
        return mapper.Map<CourseViewModel>(createdCourse);
    }

    public async ValueTask<CourseViewModel> PutAsync(long id, CourseUpdateModel updateModel)
    {
        await updateValidator.EnsureValidatedAsync(updateModel);
        var mappedCourse = mapper.Map<Course>(updateModel);
        var updatedCourse = await courseService.UpdateAsync(id, mappedCourse);
        return mapper.Map<CourseViewModel>(updatedCourse);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await courseService.DeleteAsync(id);
    }

    public async ValueTask<CourseViewModel> GetAsync(long id)
    {
        var course = await courseService.GetByIdAsync(id);
        return mapper.Map<CourseViewModel>(course);
    }

    public async ValueTask<IEnumerable<CourseViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var courses = await courseService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CourseViewModel>>(courses);
    }

    public async ValueTask<CourseViewModel> UploadFileAsync(long id, AssetCreateModel assetCreateModel)
    {
        await assetValidator.EnsureValidatedAsync(assetCreateModel);
        var lesson = await courseService.UploadFileAsync(id, assetCreateModel.File, assetCreateModel.FileType);
        return mapper.Map<CourseViewModel>(lesson);
    }

    public async ValueTask<CourseViewModel> DeleteFileAsync(long id)
    {
        var lesson = await courseService.DeleteFileAsync(id);
        return mapper.Map<CourseViewModel>(lesson);
    }
}
