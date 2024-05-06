using Arcana.Service.Helpers;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Configurations;
using Microsoft.EntityFrameworkCore;
using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Courses;

namespace Arcana.Service.Services.Courses;

public class CourseService(IUnitOfWork unitOfWork) : ICourseService
{
    public async ValueTask<Course> CreateAsync(Course course)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Name.ToLower() == course.Name.ToLower());
        if (existCourse is not null)
            throw new AlreadyExistException("This course already exists");

        //var existLanguage = await unitOfWork.Language.SelectAsync(c => c.LanguageId == course.LanguageId)
        //    ?? throw new NotFoundException($"Language is not found with this ID = {id}");

        //var existCategory = await unitOfWork.Category.SelectAsync(c => c.CategoryId == course.CategoryId)
        //     ?? throw new NotFoundException($"Category is not found with this ID = {id}");

        //var existInstructor = await unitOfWork.Instructor.SelectAsync(c => c.InstructorId == course.InstructorId)
        //     ?? throw new NotFoundException($"Instructor is not found with this ID = {id}");

        course.CreatedByUserId = HttpContextHelper.UserId;
        var createdCourse = await unitOfWork.Courses.InsertAsync(course);
        await unitOfWork.SaveAsync();

        return createdCourse;
    }

    public async ValueTask<Course> UpdateAsync(long id, Course course)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Id == id)
             ?? throw new NotFoundException($"Course is not found with this ID = {id}");

        //var existLanguage = await unitOfWork.Language.SelectAsync(c => c.LanguageId == course.LanguageId)
        //     ?? throw new NotFoundException($"Language is not found with this ID = {id}");

        //var existCategory = await unitOfWork.Category.SelectAsync(c => c.CategoryId == course.CategoryId)
        //     ?? throw new NotFoundException($"Category is not found with this ID = {id}");

        //var existInstructor = await unitOfWork.Instructor.SelectAsync(c => c.InstructorId == course.InstructorId)
        //     ?? throw new NotFoundException($"Instructor is not found with this ID = {id}");

        existCourse.Name = course.Name;
        existCourse.Level = course.Level;
        existCourse.Price = course.Price;
        existCourse.FileId = course.FileId;
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
        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Id == id)
           ?? throw new NotFoundException($"Course is not found with this ID = {id}");

        await unitOfWork.Courses.DropAsync(existCourse);
        return true;
    }

    public async ValueTask<Course> GetByIdAsync(long id)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Id == id)
           ?? throw new NotFoundException($"Course is not found with this ID={id}");

        return existCourse;
    }

    public async ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var courses = unitOfWork.Courses
             .SelectAsQueryable(expression: course => !course.IsDeleted, includes: ["Category", "Intructor", "File", "Language"], isTracked: false)
             .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            courses = courses.Where(user =>
                user.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                user.Description.Contains(search, StringComparison.OrdinalIgnoreCase));

        return await courses.ToPaginateAsQueryable(@params).ToListAsync();
    }
}
