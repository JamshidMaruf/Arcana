using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Lessons;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Arcana.Service.Services.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.Lessons;

public class LessonService(
    IUnitOfWork unitOfWork,
    IAssetService assetService) : ILessonService
{
    public async ValueTask<Lesson> CreateAsync(Lesson lesson)
    {
        var existModule = await unitOfWork.CourseModules.SelectAsync(module => module.Id == lesson.ModuleId && !module.IsDeleted)
            ?? throw new NotFoundException($"Module is not found with this ID = {lesson.ModuleId}");

        var existLesson = await unitOfWork.Lessons
            .SelectAsync(l => l.ModuleId == lesson.ModuleId && l.Title.ToLower() == lesson.Title.ToLower());

        if (existLesson is not null && !existLesson.IsDeleted)
            throw new AlreadyExistException($"This lesson is already exist with this moduleId = {lesson.ModuleId} and title = {lesson.Title}");

        lesson.CreatedByUserId = HttpContextHelper.UserId;
        var createdLesson = await unitOfWork.Lessons.InsertAsync(lesson);
        await unitOfWork.SaveAsync();

        createdLesson.Module = existModule;
        return createdLesson;
    }

    public async ValueTask<Lesson> UpdateAsync(long id, Lesson lesson)
    {
        var existModule = await unitOfWork.CourseModules.SelectAsync(module => module.Id == lesson.ModuleId && !module.IsDeleted)
            ?? throw new NotFoundException($"Module is not found with this ID = {lesson.ModuleId}");

        var existLesson = await unitOfWork.Lessons.SelectAsync(expression: l => l.Id == id && !l.IsDeleted, includes: ["Module", "File", "Comments"])
                ?? throw new NotFoundException($"Lesson is not found with this ID = {id}");

        var alreadyExitsLesson = await unitOfWork.Lessons
            .SelectAsync(l => l.ModuleId == lesson.ModuleId && l.Title.ToLower() == lesson.Title.ToLower() && l.Id != id);

        if (alreadyExitsLesson is not null)
            throw new AlreadyExistException($"This lesson is already exist with this moduleId = {lesson.ModuleId} and title = {lesson.Title}");

        existLesson.Id = id;
        existLesson.Title = lesson.Title;
        existLesson.ModuleId = lesson.ModuleId;
        existLesson.Description = lesson.Description;
        existLesson.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.Lessons.UpdateAsync(existLesson);
        await unitOfWork.SaveAsync();
        existLesson.Module = existModule;

        return existLesson;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existLesson = await unitOfWork.Lessons.SelectAsync(lesson => lesson.Id == id && !lesson.IsDeleted)
            ?? throw new NotFoundException($"Lesson is not found with this ID = {id}");

        existLesson.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Lessons.DeleteAsync(existLesson);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<Lesson> GetByIdAsync(long id)
    {
        var existLesson = await unitOfWork.Lessons
            .SelectAsync(expression: lesson => lesson.Id == id && !lesson.IsDeleted, includes: ["Module", "File", "Comments"])
            ?? throw new NotFoundException($"Lesson is not found with this ID = {id}");

        return existLesson;
    }

    public async ValueTask<IEnumerable<Lesson>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var lessons = unitOfWork.Lessons
            .SelectAsQueryable(expression: lesson => !lesson.IsDeleted, includes: ["Module", "File", "Comments"])
            .OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            lessons = lessons.Where(lesson =>
            lesson.Title.ToLower().Contains(search.ToLower()) ||
            lesson.Description.ToLower().Contains(search.ToLower()) ||
            lesson.Module.Name.ToLower().Contains(search.ToLower()));

        return await lessons.ToPaginateAsQueryable(@params).ToListAsync(); ;
    }

    public async ValueTask<Lesson> UploadFileAsync(long id, IFormFile file, FileType fileType)
    {
        await unitOfWork.BeginTransactionAsync();

        var existLesson = await unitOfWork.Lessons
           .SelectAsync(expression: lesson => lesson.Id == id && !lesson.IsDeleted, includes: ["Module", "File", "Comments"])
           ?? throw new NotFoundException($"Lesson is not found with this ID = {id}");

        var createdFile = await assetService.UploadAsync(file, fileType);

        existLesson.File = createdFile;
        existLesson.FileId = createdFile.Id;
        existLesson.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.Lessons.UpdateAsync(existLesson);
        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return existLesson;
    }

    public async ValueTask<Lesson> DeleteFileAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();

        var existLesson = await unitOfWork.Lessons
           .SelectAsync(expression: lesson => lesson.Id == id && !lesson.IsDeleted, includes: ["Module", "File", "Comments"])
           ?? throw new NotFoundException($"Lesson is not found with this ID = {id}");

        await assetService.DeleteAsync(Convert.ToInt64(existLesson.FileId));
        existLesson.FileId = null;
        await unitOfWork.Lessons .UpdateAsync(existLesson);
        await unitOfWork.SaveAsync();

        return existLesson;
    }
}