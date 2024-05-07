using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.CourseCategories;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.CourseCategories;

public class CourseCategoryService(IUnitOfWork unitOfWork) : ICourseCategoryService
{
    public async ValueTask<CourseCategory> CreateAsync(CourseCategory courseCategory)
    {
        await unitOfWork.BeginTransactionAsync();

        var existCourseCategory = await unitOfWork.CourseCategories.SelectAsync(
            cc => cc.Name.ToLower() == courseCategory.Name.ToLower() &&
            !cc.IsDeleted);

        if (existCourseCategory is not null)
            throw new AlreadyExistException("Course Category is already exists");

        courseCategory.CreatedByUserId = HttpContextHelper.UserId;

        var created = await unitOfWork.CourseCategories.InsertAsync(courseCategory);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return created;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();

        var existCourseCategory = await unitOfWork.CourseCategories.SelectAsync(
            cc => cc.Id == id &&
            !cc.IsDeleted)
            ?? throw new NotFoundException($"CourseCategory is not found with Id = {id}");

        existCourseCategory.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.CourseCategories.DeleteAsync(existCourseCategory);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return true;
    }

    public async ValueTask<IEnumerable<CourseCategory>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var CourseCategories = unitOfWork.CourseCategories
            .SelectAsQueryable(expression: cc => !cc.IsDeleted, isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            CourseCategories = CourseCategories.Where(cc =>
               cc.Name.ToLower().Contains(search.ToLower()));

        return await CourseCategories.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<CourseCategory> GetByIdAsync(long id)
    {
        var existCourseCategory = await unitOfWork.CourseCategories.SelectAsync(cc => cc.Id == id && !cc.IsDeleted)
            ?? throw new NotFoundException($"CourseCategory is not found with Id = {id}");

        return existCourseCategory;
    }

    public async ValueTask<CourseCategory> UpdateAsync(long id, CourseCategory courseCategory)
    {
        await unitOfWork.BeginTransactionAsync();

        var existCourseCategory = await unitOfWork.CourseCategories.SelectAsync(cc => cc.Id == id && !cc.IsDeleted)
            ?? throw new NotFoundException($"CourseCategory is not found with Id = {id}");

        existCourseCategory.Name = courseCategory.Name;
        existCourseCategory.UpdatedByUserId = HttpContextHelper.UserId;

        var updated = await unitOfWork.CourseCategories.UpdateAsync(existCourseCategory);
        await unitOfWork.SaveAsync();

        await unitOfWork.CommitTransactionAsync();

        return updated;
    }
}
