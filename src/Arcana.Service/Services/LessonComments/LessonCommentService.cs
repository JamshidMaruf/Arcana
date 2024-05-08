using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Lessons;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.LessonComments;

public class LessonCommentService(IUnitOfWork unitOfWork) : ILessonCommentService
{
    public async ValueTask<LessonComment> CreateAsync(LessonComment lessonComment)
    {
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Id == lessonComment.UserId && !user.IsDeleted)
            ?? throw new NotFoundException($"User is not found with this Id = {lessonComment.UserId}");

        var existLesson = await unitOfWork.Lessons.SelectAsync(lesson => lesson.Id == lessonComment.LessonId && !lesson.IsDeleted)
             ?? throw new NotFoundException($"Lesson is not found with this ID = {lessonComment.LessonId}");

        lessonComment.CreatedByUserId = HttpContextHelper.UserId;
        var createdLessonComment = await unitOfWork.LessonComments.InsertAsync(lessonComment);
        await unitOfWork.SaveAsync();

        createdLessonComment.Lesson = existLesson;
        createdLessonComment.User = existUser;
        return createdLessonComment;
    }

    public async ValueTask<LessonComment> UpdateAsync(long id, LessonComment lessonComment)
    {
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Id == lessonComment.UserId && !user.IsDeleted)
            ?? throw new NotFoundException($"User is not found with this Id = {lessonComment.UserId}");

        var existLesson = await unitOfWork.Lessons.SelectAsync(lesson => lesson.Id == lessonComment.LessonId && !lesson.IsDeleted)
             ?? throw new NotFoundException($"Lesson is not found with this ID = {lessonComment.LessonId}");

        var existLessonComment = await unitOfWork.LessonComments.SelectAsync(lc => lc.Id == id && !lc.IsDeleted)
            ?? throw new NotFoundException($"Lesson comment is not found with this Id = {id}");

        existLessonComment.Content = lessonComment.Content;
        existLesson.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.LessonComments.UpdateAsync(existLessonComment);
        await unitOfWork.SaveAsync();
        existLessonComment.Lesson = existLesson;
        existLessonComment.User = existUser;

        return existLessonComment;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existLessonComment = await unitOfWork.LessonComments.SelectAsync(lc => lc.Id == id && !lc.IsDeleted)
            ?? throw new NotFoundException($"Lesson comment is not found with this Id = {id}");

        existLessonComment.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.LessonComments.DeleteAsync(existLessonComment);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<LessonComment> GetByIdAsync(long id)
    {
        var existLessonComment = await unitOfWork.LessonComments
            .SelectAsync(expression: lc => lc.Id == id && !lc.IsDeleted, includes: ["Lesson", "User", "Parent"])
            ?? throw new NotFoundException($"Lesson comment is not found with this Id = {id}");

        return existLessonComment;
    }

    public async ValueTask<IEnumerable<LessonComment>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var lessonComments = unitOfWork.LessonComments
            .SelectAsQueryable(expression: lc => !lc.IsDeleted, includes: ["Lesson", "User", "Parent"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            lessonComments = lessonComments.Where(lc =>
            lc.Content.ToLower().Contains(search.ToLower()));

        return await lessonComments.ToPaginateAsQueryable(@params).ToListAsync();
    }
}