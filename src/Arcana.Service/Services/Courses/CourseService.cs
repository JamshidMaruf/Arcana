using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Courses;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Arcana.Service.Services.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.Courses;

public class CourseService(
    IUnitOfWork unitOfWork,
    IAssetService assetService) : ICourseService
{
    public async ValueTask<Course> CreateAsync(Course course)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Name.ToLower() == course.Name.ToLower() && !c.IsDeleted);
        if (existCourse is not null)
            throw new AlreadyExistException("This course already exists");

        var existLanguage = await unitOfWork.Languages.SelectAsync(l => l.Id == course.LanguageId)
            ?? throw new NotFoundException($"Language is not found with this ID = {course.LanguageId}");

        var existCategory = await unitOfWork.CourseCategories.SelectAsync(c => c.Id == course.CategoryId)
             ?? throw new NotFoundException($"Category is not found with this ID = {course.CategoryId}");

        var existInstructor = await unitOfWork.Instructors.SelectAsync(i => i.Id == course.InstructorId)
             ?? throw new NotFoundException($"Instructor is not found with this ID = {course.InstructorId}");

        course.CreatedByUserId = HttpContextHelper.UserId;
        var createdCourse = await unitOfWork.Courses.InsertAsync(course);
        await unitOfWork.SaveAsync();

        return createdCourse;
    }

    public async ValueTask<Course> UpdateAsync(long id, Course course)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Id == id && !c.IsDeleted)
             ?? throw new NotFoundException($"Course is not found with this ID = {id}");

        var existLanguage = await unitOfWork.Languages.SelectAsync(l => l.Id == course.LanguageId)
             ?? throw new NotFoundException($"Language is not found with this ID = {course.LanguageId}");

        var existCategory = await unitOfWork.CourseCategories.SelectAsync(c => c.Id == course.CategoryId)
             ?? throw new NotFoundException($"Category is not found with this ID = {course.CategoryId}");

        var existInstructor = await unitOfWork.Instructors.SelectAsync(i => i.Id == course.InstructorId)
             ?? throw new NotFoundException($"Instructor is not found with this ID = {course.InstructorId}");

        existCourse.Name = course.Name;
        existCourse.Level = course.Level;
        existCourse.Price = course.Price;
        existCourse.Duration = course.Duration;
        existCourse.LanguageId = course.LanguageId;
        existCourse.CategoryId = course.CategoryId;
        existCourse.Description = course.Description;
        existCourse.InstructorId = course.InstructorId;
        existCourse.CountOfLessons = course.CountOfLessons;

        existCourse.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Courses.UpdateAsync(existCourse);
        await unitOfWork.SaveAsync();

        return existCourse;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Id == id && !c.IsDeleted)
           ?? throw new NotFoundException($"Course is not found with this ID = {id}");

        await unitOfWork.Courses.DeleteAsync(existCourse);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<Course> GetByIdAsync(long id)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Id == id && !c.IsDeleted,
            ["Category", "Instructor", "File", "Language"])
           ?? throw new NotFoundException($"Course is not found with this ID={id}");

        return existCourse;
    }

    public async ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var courses = unitOfWork.Courses
             .SelectAsQueryable(expression: course => !course.IsDeleted, includes: ["Category", "Instructor", "File", "Language"], isTracked: false)
             .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            courses = courses.Where(user =>
                user.Name.ToLower().Contains(search.ToLower()) ||
                user.Description.ToLower().Contains(search.ToLower()));

        return await courses.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Course> UploadFileAsync(long id, IFormFile file, FileType fileType)
    {
        await unitOfWork.BeginTransactionAsync();

        var existCourse = await unitOfWork.Courses
           .SelectAsync(expression: course => course.Id == id && !course.IsDeleted, includes: ["Category", "Instructor", "File", "Language"])
           ?? throw new NotFoundException($"Course is not found with this ID = {id}");

        var createdFile = await assetService.UploadAsync(file, fileType);

        existCourse.File = createdFile;
        existCourse.FileId = createdFile.Id;
        existCourse.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.Courses.UpdateAsync(existCourse);
        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return existCourse;
    }

    public async ValueTask<Course> DeleteFileAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();

        var existCourse = await unitOfWork.Courses
           .SelectAsync(expression: course => course.Id == id && !course.IsDeleted, includes: ["Category", "Instructor", "File", "Language"])
           ?? throw new NotFoundException($"Course is not found with this ID = {id}");

        await assetService.DeleteAsync(Convert.ToInt64(existCourse.FileId));
        existCourse.FileId = null;
        await unitOfWork.Courses.UpdateAsync(existCourse);
        await unitOfWork.SaveAsync();

        return existCourse;
    }
}
