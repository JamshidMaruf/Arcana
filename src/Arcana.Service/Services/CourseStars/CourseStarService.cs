using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Courses;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Arcana.Service.Services.Courses;
using Arcana.Service.Services.Students;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.CourseStars;

public class CourseStarService(IUnitOfWork unitOfWork,
                               ICourseService courseService,
                               IStudentService studentService) : ICourseStarService
{
    public async ValueTask<CourseStar> CreateAsync(CourseStar courseStar)
    {
        var course = await courseService.GetByIdAsync(courseStar.CourseId);
        var student = await studentService.GetByIdAsync(courseStar.StudentId);
        var existStart = await unitOfWork.CourseStars.SelectAsync(cs => 
            cs.StudentId == courseStar.StudentId && cs.CourseId == courseStar.CourseId);

        if (existStart is not null)
            throw new AlreadyExistException($"CourseStar already exists");

        courseStar.CreatedByUserId = HttpContextHelper.UserId;
        var createdCourseStar = await unitOfWork.CourseStars.InsertAsync(courseStar);
        await unitOfWork.SaveAsync();

        createdCourseStar.Course = course;
        createdCourseStar.Student = student;

        return createdCourseStar;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var courseStar = await unitOfWork.CourseStars.SelectAsync(cs => cs.Id == id)
            ?? throw new NotFoundException($"Course star is not found with this id: {id}");

        await unitOfWork.CourseStars.DropAsync(courseStar);

        return await unitOfWork.SaveAsync();
    }

    public async ValueTask<IEnumerable<CourseStar>> GetAllAsync(PaginationParams @params,
                                                          Filter filter,
                                                          string search = null)
    {
        var courseStars = unitOfWork.CourseStars
            .SelectAsQueryable(includes: ["Course", "Student"])
            .OrderBy(filter);
        if (!string.IsNullOrWhiteSpace(search))
            courseStars = courseStars.Where(cs => cs.Course.Name.ToLower() == search.ToLower());

        return await courseStars.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<CourseStar> GetByIdAsync(long id)
    {
        var courseStar = await unitOfWork.CourseStars.SelectAsync(cs => cs.Id == id, ["Course", "Student"])
             ?? throw new NotFoundException($"Course star is not found with this id: {id}");

        return courseStar;
    }

    public async ValueTask<CourseStar> UpdateAsync(long id, CourseStar courseStar)
    {
        var course = await courseService.GetByIdAsync(courseStar.CourseId);
        var student = await studentService.GetByIdAsync(courseStar.StudentId);
        var alreadyExistStart = await unitOfWork.CourseStars.SelectAsync(cs =>
            cs.StudentId == courseStar.StudentId && cs.CourseId == courseStar.CourseId);

        if (alreadyExistStart is not null)
            throw new AlreadyExistException($"CourseStar already exists");

        var existCourseStar = await unitOfWork.CourseStars.SelectAsync(cs => cs.Id == courseStar.Id)
            ?? throw new NotFoundException($"Course star is not found with this id: {id}");

        existCourseStar.Stars = courseStar.Stars;
        existCourseStar.CourseId = courseStar.CourseId;
        existCourseStar.StudentId = courseStar.StudentId;
        existCourseStar.UpdatedByUserId = HttpContextHelper.UserId;

        var updatedCourseStar = await unitOfWork.CourseStars.UpdateAsync(courseStar);
        await unitOfWork.SaveAsync();

        updatedCourseStar.Course = course;
        updatedCourseStar.Student = student;

        return updatedCourseStar;
    }
}
