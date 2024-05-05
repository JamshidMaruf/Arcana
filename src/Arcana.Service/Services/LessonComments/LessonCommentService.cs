using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Lessons;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Helpers;

namespace Arcana.Service.Services.LessonComments;

public class LessonCommentService(IUnitOfWork unitOfWork) : ILessonCommentService
{
    public async ValueTask<LessonComment> CreateAsync(LessonComment lessonComment)
    {
        var existLesson = unitOfWork.Lessons.SelectAsQueryable(lc => lc.Id == lessonComment.LessonId && !lc.IsDeleted)
             ?? throw new NotFoundException($"Lesson is not found with this ID = {lessonComment.LessonId}");

        //var existInstructor = unitOfWork.Lessons.SelectAsQueryable(lc => lc.Id == lessonComment.InstructorId && !lc.IsDeleted)
        //    ?? throw new NotFoundException($"Instructor is not found with this ID = {lessonComment.InstructorId}");

        return lessonComment;
    }

    public ValueTask<LessonComment> UpdateAsync(long id, LessonComment lessonComment)
    {
        throw new NotImplementedException();
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
            .SelectAsync(expression: lc => lc.Id == id && !lc.IsDeleted , includes: [""])
            ?? throw new NotFoundException($"Lesson comment is not found with this Id = {id}");

        return existLessonComment;
    }

    public ValueTask<IEnumerable<LessonComment>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        throw new NotImplementedException();
    }
}