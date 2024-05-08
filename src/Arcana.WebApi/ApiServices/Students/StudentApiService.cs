using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Users;
using Arcana.Service.Configurations;
using Arcana.Service.Services.Students;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.Assets;
using Arcana.WebApi.Models.Students;
using Arcana.WebApi.Validators.Students;

namespace Arcana.WebApi.ApiServices.Students;

public class StudentApiService(
    IStudentService studentService,
    StudentCreateModelValidator createModelValidator,
    StudentUpdateModelValidator updateModelValidator) : IStudentApiService
{
    public async ValueTask<StudentViewModel> PostAsync(StudentCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var createdStudent = await studentService.CreateAsync(Map(createModel));
        return Map(createdStudent);
    }

    public async ValueTask<StudentViewModel> PutAsync(long id, StudentUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var updatedStudent = await studentService.UpdateAsync(id, Map(updateModel));
        return Map(updatedStudent);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await studentService.DeleteAsync(id);
    }

    public async ValueTask<StudentViewModel> GetAsync(long id)
    {
        return Map(await studentService.GetByIdAsync(id));
    }

    public async ValueTask<IEnumerable<StudentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var students = await studentService.GetAllAsync(@params, filter, search);
        return students.Select(Map);
    }

    public async ValueTask<StudentViewModel> UploadPictureAsync(long id, IFormFile picture)
    {
        var existInstructor = await studentService.UploadPictureAsync(id, picture);
        return Map(existInstructor);
    }

    public async ValueTask<StudentViewModel> DeletePictureAsync(long id)
    {
        var existInstructor = await studentService.DeletePictureAsync(id);
        return Map(existInstructor);
    }

    private Student Map(StudentCreateModel createModel)
    {
        return new Student
        {
            Detail = new User
            {
                Email = createModel.Email,
                Phone = createModel.Phone,
                Password = createModel.Password,
                LastName = createModel.LastName,
                FirstName = createModel.FirstName,
                DateOfBirth = createModel.DateOfBirth
            }
        };
    }

    private Student Map(StudentUpdateModel createModel)
    {
        return new Student
        {
            Detail = new User
            {
                Email = createModel.Email,
                Phone = createModel.Phone,
                LastName = createModel.LastName,
                FirstName = createModel.FirstName,
                DateOfBirth = createModel.DateOfBirth
            }
        };
    }

    private StudentViewModel Map(Student student)
    {
        return new StudentViewModel
        {
            Id = student.Id,
            Email = student.Detail.Email,
            Phone = student.Detail.Phone,
            LastName = student.Detail.LastName,
            FirstName = student.Detail.FirstName,
            DateOfBirth = student.Detail.DateOfBirth,
            Picture = new AssetViewModel
            {
                Id = student.Picture?.Id ?? 0,
                Name = student.Picture?.Name,
                Path = student.Picture?.Path,
            }
        };
    }
}
