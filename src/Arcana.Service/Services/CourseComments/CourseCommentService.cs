using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.CourseComments;
using Arcana.Domain.Entities.Students;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.CourseComments;

public class CourseCommentService(IUnitOfWork unitOfWork) : ICourseCommentService
{
    public async ValueTask<CourseComment> CreateAsync(CourseComment courseComment)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Id == courseComment.CourseId && !c.IsDeleted,
            includes: ["Category", "Instructor", "File", "Language"])
            ?? throw new NotFoundException($"Course not found with Id = {courseComment.CourseId}");

        var existStudent = await unitOfWork.Students.SelectAsync(s => s.Id == courseComment.StudentId && !s.IsDeleted,
            includes: ["Detail", "Picture"])
            ?? throw new NotFoundException($"Student not found with Id = {courseComment.StudentId}");

        courseComment.CreatedByUserId = HttpContextHelper.UserId;
        var created = await unitOfWork.CourseComments.InsertAsync(courseComment);
        await unitOfWork.SaveAsync();

        created.Course = existCourse;
        created.Student = existStudent;
        created.Student.Detail = existStudent.Detail;

        return created;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existCourseComment = await unitOfWork.CourseComments.SelectAsync(c => c.Id == id && !c.IsDeleted)
            ?? throw new NotFoundException($"CourseComment not found with Id = {id}");

        existCourseComment.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.CourseComments.DeleteAsync(existCourseComment);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<CourseComment>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var CourseComments = unitOfWork.CourseComments.SelectAsQueryable
            (c => !c.IsDeleted, includes: ["Student", "Course"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            CourseComments = CourseComments.Where(c =>
               c.Content.ToLower().Contains(search.ToLower()));

        return await CourseComments.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<CourseComment> GetByIdAsync(long id)
    {
        var existCourseComment = await unitOfWork.CourseComments.SelectAsync(c => c.Id == id && !c.IsDeleted,
            includes: ["Student", "Course"])
            ?? throw new NotFoundException($"CourseComment not found with Id = {id}");

        return existCourseComment;
    }

    public async ValueTask<CourseComment> UpdateAsync(long id, CourseComment courseComment)
    {
        await unitOfWork.BeginTransactionAsync();

        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Id == courseComment.CourseId && !c.IsDeleted,
           includes: ["Category", "Instructor", "File", "Language"])
           ?? throw new NotFoundException($"Course not found with Id = {courseComment.CourseId}");

        var existStudent = await unitOfWork.Students.SelectAsync(s => s.Id == courseComment.StudentId && !s.IsDeleted,
            includes: ["Detail", "Picture"])
            ?? throw new NotFoundException($"Student not found with Id = {courseComment.StudentId}");

        var existCourseComment = await unitOfWork.CourseComments.SelectAsync(c => c.Id == id && !c.IsDeleted)
           ?? throw new NotFoundException($"CourseComment not found with Id = {id}");

        existCourseComment.Course = existCourse;
        existCourseComment.Student = existStudent;
        existCourseComment.Content = courseComment.Content;
        existCourseComment.CourseId = courseComment.CourseId;
        existCourseComment.StudentId = courseComment.StudentId;
        existCourseComment.UpdatedByUserId = HttpContextHelper.UserId;

        var updated = await unitOfWork.CourseComments.UpdateAsync(existCourseComment);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return updated;
    }
}