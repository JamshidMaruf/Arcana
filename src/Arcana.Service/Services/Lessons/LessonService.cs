using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Lessons;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.Lessons;

public class LessonService(
    IUnitOfWork unitOfWork) : ILessonService
{
    public async ValueTask<Lesson> CreateAsync(Lesson lesson)
    {
        //var existModule = await unitOfWork.
        //var existFile = await unitOfWork.

        var existLesson = await unitOfWork.Lessons
            .SelectAsync(l => l.ModuleId == lesson.ModuleId && l.Title.ToLower() == lesson.Title.ToLower());

        if (existLesson is not null && !existLesson.IsDeleted)
            throw new AlreadyExistException($"This lesson is already exist with this moduleId = {lesson.ModuleId} and title = {lesson.Title}");

        if (existLesson is not null)
            return await UpdateAsync(existLesson.Id, lesson, true);

        lesson.CreatedByUserId = HttpContextHelper.UserId;
        var createdLesson = await unitOfWork.Lessons.InsertAsync(lesson);
        await unitOfWork.SaveAsync();

        //createdLesson.Module
        //createdLesson.File
        return createdLesson;
    }

    public async ValueTask<Lesson> UpdateAsync(long id, Lesson lesson, bool isLessonDeleted = false)
    {
        //var existModule = await unitOfWork.
        //var existFile = await unitOfWork.

        var existLesson = new Lesson();
        if (!isLessonDeleted)
            existLesson = await unitOfWork.Lessons.SelectAsync(expression: l => l.Id == id && !l.IsDeleted, includes: ["Module", "File"])
                ?? throw new NotFoundException($"Lesson is not found with this ID = {id}");

        var alreadyExitsLesson = await unitOfWork.Lessons
            .SelectAsync(l => l.ModuleId == lesson.ModuleId && l.Title.ToLower() == lesson.Title.ToLower() && l.Id != id);
       
        if (alreadyExitsLesson is not null)
            throw new AlreadyExistException($"This lesson is already exist with this moduleId = {lesson.ModuleId} and title = {lesson.Title}");

        existLesson.Id = id;
        existLesson.IsDeleted = false;
        existLesson.Title = lesson.Title;
        existLesson.FileId = lesson.FileId;
        existLesson.ModuleId = lesson.ModuleId;
        existLesson.Description = lesson.Description;
        existLesson.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.Lessons.UpdateAsync(existLesson);
        await unitOfWork.SaveAsync();

        return existLesson;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existLesson = await unitOfWork.Lessons.SelectAsync(lesson => lesson.Id == id && !lesson.IsDeleted)
            ?? throw new NotFoundException($"Lesson is not found with this ID = {id}");

        await unitOfWork.Lessons.DeleteAsync(existLesson);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<Lesson> GetByIdAsync(long id)
    {
        var existLesson = await unitOfWork.Lessons
            .SelectAsync(expression: lesson => lesson.Id == id && !lesson.IsDeleted, includes: ["Module", "File"])
            ?? throw new NotFoundException($"Lesson is not found with this ID = {id}");

        return existLesson;
    }

    public async ValueTask<IEnumerable<Lesson>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var lessons = unitOfWork.Lessons
            .SelectAsQueryable(expression: lesson => !lesson.IsDeleted, includes: ["Module", "File"])
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            lessons = lessons.Where(lesson =>
            lesson.Title.ToLower().Contains(search.ToLower()) ||
            lesson.Description.ToLower().Contains(search.ToLower()));
        //lesson.Module.Name.ToLower().Contains(search.ToLower()));

        return await lessons.ToPaginateAsQueryable(@params).ToListAsync(); ;
    }
}