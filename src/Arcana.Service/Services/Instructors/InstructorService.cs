using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Arcana.Service.Services.Assets;
using Arcana.Service.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.Instructors;

public class InstructorService(IUnitOfWork unitOfWork, IAssetService assetService, IUserService userService) : IInstructorService
{
    public async ValueTask<Instructor> CreateAsync(Instructor instructor)
    {
        await unitOfWork.BeginTransactionAsync();

        instructor.Detail.RoleId = await GetRoleId();
        await userService.CreateAsync(instructor.Detail);

        instructor.CreatedByUserId = HttpContextHelper.UserId;
        var createdInstructor = await unitOfWork.Instructors.InsertAsync(instructor);

        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return createdInstructor;
    }

    public async ValueTask<Instructor> UpdateAsync(long id, Instructor instructor)
    {
        await unitOfWork.BeginTransactionAsync();

        var existInstructor = await unitOfWork.Instructors.SelectAsync(instructor => instructor.Id == id)
            ?? throw new NotFoundException($"Instructor is not found with this ID={id}");

        await userService.UpdateAsync(existInstructor.DetailId, instructor.Detail);

        existInstructor.About = instructor.About;
        existInstructor.Profession = instructor.Profession;
        existInstructor.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Instructors.UpdateAsync(existInstructor);

        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return existInstructor;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();

        var existInstructor = await unitOfWork.Instructors.SelectAsync(instructor => instructor.Id == id)
            ?? throw new NotFoundException($"Instructor is not found with this ID={id}");

        await userService.DeleteAsync(existInstructor.DetailId);
        existInstructor.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Instructors.DeleteAsync(existInstructor);

        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return true;
    }

    public async ValueTask<Instructor> GetByIdAsync(long id)
    {
        var existInstructor = await unitOfWork.Instructors
            .SelectAsync(instructor => instructor.Id == id && !instructor.IsDeleted, includes: ["Detail.Role", "Picture"])
            ?? throw new NotFoundException($"Instructor is not found with this ID={id}");

        return existInstructor;
    }

    public async ValueTask<IEnumerable<Instructor>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var instructors = unitOfWork.Instructors
            .SelectAsQueryable(expression: instructor => !instructor.IsDeleted, includes: ["Detail.Role", "Picture"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            instructors = instructors.Where(instructor =>
                instructor.Detail.FirstName.ToLower().Contains(search.ToLower()) ||
                instructor.Detail.LastName.ToLower().Contains(search.ToLower()));

        return await instructors.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Instructor> UploadPictureAsync(long id, IFormFile picture)
    {
        var existInstructor = await unitOfWork.Instructors
            .SelectAsync(instructor => instructor.Id == id && !instructor.IsDeleted, includes: ["Detail.Role", "Picture"])
            ?? throw new NotFoundException($"Instructor is not found with this ID={id}");

        var createdPicture = await assetService.UploadAsync(picture, FileType.Pictures);

        existInstructor.Picture = createdPicture;
        existInstructor.PictureId = createdPicture.Id;
        existInstructor.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Instructors.UpdateAsync(existInstructor);
        await unitOfWork.SaveAsync();

        return existInstructor;
    }

    public async ValueTask<Instructor> DeletePictureAsync(long id)
    {
        var existInstructor = await unitOfWork.Instructors
            .SelectAsync(instructor => instructor.Id == id && !instructor.IsDeleted, includes: ["Detail.Role"])
            ?? throw new NotFoundException($"Instructor is not found with this ID={id}");

        await assetService.DeleteAsync(Convert.ToInt64(existInstructor.PictureId));

        existInstructor.PictureId = null;
        await unitOfWork.Instructors.UpdateAsync(existInstructor);
        await unitOfWork.SaveAsync();

        return existInstructor;
    }

    private async ValueTask<long> GetRoleId()
    {
        var role = await unitOfWork.UserRoles.SelectAsync(role => role.Name.ToLower() == Constants.InstructorRoleName.ToLower())
            ?? throw new NotFoundException($"Role is not found with this name {Constants.InstructorRoleName}");

        return role.Id;
    }
}