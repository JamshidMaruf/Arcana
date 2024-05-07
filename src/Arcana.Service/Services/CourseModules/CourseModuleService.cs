using Arcana.Service.Helpers;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.DataAccess.UnitOfWorks;
using Arcana.Service.Configurations;
using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Courses;

namespace Arcana.Service.Services.CourseModules;

public class CourseModuleService(IUnitOfWork unitOfWork) : ICourseModuleService
{
    public async ValueTask<CourseModule> CreateAsync(CourseModule courseModule)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(course => course.Id == courseModule.CourseId && !course.IsDeleted)
             ?? throw new NotFoundException($"Course is not found with this ID = {courseModule.CourseId}");

        var existCourseModule = await unitOfWork.CourseModules.SelectAsync(module => 
            module.Name.ToLower() == courseModule.Name.ToLower() && 
            module.CourseId == courseModule.CourseId);
        if (existCourseModule is not null)
            throw new AlreadyExistException("This course module already exists");

        courseModule.CreatedByUserId = HttpContextHelper.UserId;
        var createdCourseModule = await unitOfWork.CourseModules.InsertAsync(courseModule);
        await unitOfWork.SaveAsync();

        return createdCourseModule;
    }

    public async ValueTask<CourseModule> UpdateAsync(long id, CourseModule courseModule)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(course => course.Id == courseModule.CourseId && !course.IsDeleted)
            ?? throw new NotFoundException($"Course is not found with this ID = {courseModule.CourseId}");

        var existCourseModule = await unitOfWork.CourseModules.SelectAsync(cm => cm.Id == id && !cm.IsDeleted)
            ?? throw new NotFoundException($"Course module is not found with this Id = {id}");

        existCourseModule.CourseId = courseModule.CourseId;
        existCourseModule.Name = courseModule.Name;
        existCourseModule.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.CourseModules.UpdateAsync(existCourseModule);
        await unitOfWork.SaveAsync();

        return existCourseModule;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existCourseModule = await unitOfWork.CourseModules.SelectAsync(cm => cm.Id == id && !cm.IsDeleted)
           ?? throw new NotFoundException($"Course module is not found with this ID={id}");

        existCourseModule.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.CourseModules.DeleteAsync(existCourseModule);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<CourseModule> GetByIdAsync(long id)
    {
        var existCourseModule = await unitOfWork.CourseModules
            .SelectAsync(cm => cm.Id == id && !cm.IsDeleted, includes: ["Course"])
           ?? throw new NotFoundException($"Course module is not found with this ID={id}");

        return existCourseModule;
    }

    public async ValueTask<IEnumerable<CourseModule>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var courseModules = unitOfWork.CourseModules
            .SelectAsQueryable(expression: cm => !cm.IsDeleted, includes: ["Course"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            courseModules = courseModules.Where(cm =>
            cm.Name.ToLower().Contains(search.ToLower()));

        return await courseModules.ToPaginateAsQueryable(@params).ToListAsync();
    }
}
