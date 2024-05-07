using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.StudentCourses;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.StudentCourses;

public class StudentCourseService(IUnitOfWork unitOfWork) : IStudentCourseService
{
    public async ValueTask<StudentCourse> CreateAsync(StudentCourse studentCourse)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(c => c.Id == studentCourse.CourseId)
            ?? throw new NotFoundException($"Course is not found with this ID = {studentCourse.CourseId}");

        var existStudent = await unitOfWork.Students.SelectAsync(s => s.Id == studentCourse.StudentId)
            ?? throw new NotFoundException($"Student is not found with this ID = {studentCourse.StudentId}");

        var existInstructor = await unitOfWork.Instructors.SelectAsync(i => i.Id == studentCourse.InstructorId)
            ?? throw new NotFoundException($"Instructor is not found with this ID = {studentCourse.InstructorId}");

        var existStudentCourse = await unitOfWork.StudentCourses.SelectAsync(
            c => c.CourseId == studentCourse.CourseId
            && c.StudentId == studentCourse.StudentId
            && c.InstructorId == studentCourse.InstructorId);

        if (existStudentCourse is not null)
            throw new AlreadyExistException($"Course is already exists" +
                $"CourseId={studentCourse.CourseId}" +
                $"Student is already exists" +
                $"StudentId={studentCourse.StudentId}" +
                $"Instructor is already exists" +
                $"InstructorId={studentCourse.InstructorId}");

        studentCourse.CreatedByQuestionId = HttpContextHelper.QuestionId;

        var createdStudentCourse = await unitOfWork.StudentCourses.InsertAsync(studentCourse);
        createdStudentCourse.Student = existStudent;
        createdStudentCourse.Course = existCourse;
        createdStudentCourse.Instructor = existInstructor;
        await unitOfWork.SaveAsync();

        return createdStudentCourse;
    }

    public async ValueTask<StudentCourse> UpdateAsync(long id, StudentCourse studentCourse)
    {
        var existStudentCourse = await unitOfWork.StudentCourses.SelectAsync(s => s.Id == id && !s.IsDeleted)
            ?? throw new NotFoundException($"StudentCourse is not found with this ID={id}");

        existStudentCourse.StudentId = studentCourse.StudentId;
        existStudentCourse.CourseId = studentCourse.CourseId;
        existStudentCourse.InstructorId = studentCourse.InstructorId;
        existStudentCourse.UpdatedByQuestionId = HttpContextHelper.QuestionId;
        await unitOfWork.StudentCourses.UpdateAsync(existStudentCourse);
        await unitOfWork.SaveAsync();

        return existStudentCourse;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existStudentCourse = await unitOfWork.StudentCourses.SelectAsync(s => s.Id == id && !s.IsDeleted)
            ?? throw new NotFoundException($"StudentCourse is not found with this ID={id}");

        existStudentCourse.DeletedByUserId = HttpContextHelper.QuestionId;
        await unitOfWork.StudentCourses.DeleteAsync(existStudentCourse);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<StudentCourse> GetByIdAsync(long id)
    {
        var existStudentCourse = await unitOfWork.StudentCourses
            .SelectAsync(expression: s => s.Id == id && !s.IsDeleted, includes: ["Student", "Instructor", "Course"])
            ?? throw new NotFoundException($"StudentCourse is not found with this ID={id}");

        return existStudentCourse;
    }

    public async ValueTask<IEnumerable<StudentCourse>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var studentCourse = unitOfWork.StudentCourses
            .SelectAsQueryable(expression: s => !s.IsDeleted, includes: ["Student", "Instructor", "Course"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            studentCourse = studentCourse.Where(s =>
                s.Instructor.Profession.ToLower().Contains(search.ToLower()) ||
                s.Instructor.About.ToLower().Contains(search.ToLower()) ||
                s.Course.Name.ToLower().Contains(search.ToLower()) ||
                s.Course.Description.ToLower().Contains(search.ToLower()) ||
                s.Student.Detail.FirstName.Contains(search.ToLower()) ||
                s.Student.Detail.LastName.ToLower().Contains(search.ToLower()));

        return await studentCourse.ToPaginateAsQueryable(@params).ToListAsync();
    }
}
