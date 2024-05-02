using Arcana.Service.Helpers;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Microsoft.AspNetCore.Http;
using Arcana.Service.Configurations;
using Arcana.DataAccess.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Arcana.Service.Services.Assets;
using Arcana.Domain.Entities.Students;
using Arcana.Service.Services.Users;

namespace Arcana.Service.Services.Students;

public class StudentService(IUnitOfWork unitOfWork, IAssetService assetService, IUserService userService) : IStudentService
{
    public async ValueTask<Student> CreateAsync(Student student)
    {
        await unitOfWork.BeginTransactionAsync();

        student.Detail.RoleId = await GetRoleId();
        await userService.CreateAsync(student.Detail);

        student.CreatedByUserId = HttpContextHelper.UserId;
        var createdStudent = await unitOfWork.Students.InsertAsync(student);
        
        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return createdStudent;
    }

    public async ValueTask<Student> UpdateAsync(long id, Student student)
    {
        var existStudent = await unitOfWork.Students.SelectAsync(student => student.Id == id)
            ?? throw new NotFoundException($"User is not found with this ID={id}");

        await userService.UpdateAsync(existStudent.DetailId, student.Detail);
        return existStudent;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();

        var existStudent = await unitOfWork.Students.SelectAsync(student => student.Id == id)
            ?? throw new NotFoundException($"Student is not found with this ID={id}");

        await userService.DeleteAsync(existStudent.DetailId);
        existStudent.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Students.DeleteAsync(existStudent);
        
        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return true;
    }

    public async ValueTask<Student> GetByIdAsync(long id)
    {
        var existStudent = await unitOfWork.Students
            .SelectAsync(student => student.Id == id && !student.IsDeleted, includes: ["Detail.Role", "Picture"])
            ?? throw new NotFoundException($"Student is not found with this ID={id}");

        return existStudent;
    }

    public async ValueTask<IEnumerable<Student>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var students = unitOfWork.Students
            .SelectAsQueryable(expression: student => !student.IsDeleted, includes: ["Detail.Role", "Picture"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            students = students.Where(student =>
                student.Detail.FirstName.ToLower().Contains(search.ToLower()) ||
                student.Detail.LastName.ToLower().Contains(search.ToLower()));

        return await students.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Student> UploadPictureAsync(long id, IFormFile picture)
    {
        var existStudent = await unitOfWork.Students
            .SelectAsync(student => student.Id == id && !student.IsDeleted, includes: ["Detail.Role", "Picture"])
            ?? throw new NotFoundException($"Student is not found with this ID={id}");

        var createdPicture = await assetService.UploadAsync(picture, FileType.Pictures);

        existStudent.Picture = createdPicture;
        existStudent.PictureId = createdPicture.Id;
        existStudent.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Students.UpdateAsync(existStudent);
        await unitOfWork.SaveAsync();

        return existStudent;
    }

    public async ValueTask<Student> DeletePictureAsync(long id)
    {
        var existStudent = await unitOfWork.Students
            .SelectAsync(instructor => instructor.Id == id && !instructor.IsDeleted, includes: ["Detail.Role"])
            ?? throw new NotFoundException($"Student is not found with this ID={id}");

        await assetService.DeleteAsync(Convert.ToInt64(existStudent.PictureId));

        existStudent.PictureId = null;
        await unitOfWork.Students.UpdateAsync(existStudent);
        await unitOfWork.SaveAsync();

        return existStudent;
    }

    private async ValueTask<long> GetRoleId()
    {
        var role = await unitOfWork.UserRoles.SelectAsync(role => role.Name.ToLower() == Constants.StudentRoleName.ToLower())
            ?? throw new NotFoundException($"Role is not found with this name {Constants.StudentRoleName}");

        return role.Id;
    }
}