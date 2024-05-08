using Arcana.Domain.Entities.StudentCourses;
using Arcana.Service.Configurations;
using Arcana.Service.Services.StudentCourses;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.StudentCourses;
using Arcana.WebApi.Validators.StudentCourses;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.StudentCourses;

public class StudentCourseApiService(IMapper mapper,
    IStudentCourseService studentCourseService,
    StudentCourseCreateModelValidator createValidator,
    StudentCourseUpdateModelValidator updateValidator) : IStudentCourseApiService
{
    public async ValueTask<StudentCourseViewModel> PostAsync(StudentCourseCreateModel createModel)
    {
        await createValidator.EnsureValidatedAsync(createModel);
        var mappedStudentCourse = mapper.Map<StudentCourse>(createModel);
        var createdStudentCourse = await studentCourseService.CreateAsync(mappedStudentCourse);
        return mapper.Map<StudentCourseViewModel>(createdStudentCourse);
    }

    public async ValueTask<StudentCourseViewModel> PutAsync(long id, StudentCourseUpdateModel updateModel)
    {
        await updateValidator.EnsureValidatedAsync(updateModel);
        var mappedStudentCourse = mapper.Map<StudentCourse>(updateModel);
        var updatedStudentCourse = await studentCourseService.UpdateAsync(id, mappedStudentCourse);
        return mapper.Map<StudentCourseViewModel>(updatedStudentCourse);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await studentCourseService.DeleteAsync(id);
    }

    public async ValueTask<StudentCourseViewModel> GetAsync(long id)
    {
        var studentCourse = await studentCourseService.GetByIdAsync(id);
        return mapper.Map<StudentCourseViewModel>(studentCourse);
    }

    public async ValueTask<IEnumerable<StudentCourseViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var studentCourses = await studentCourseService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<StudentCourseViewModel>>(studentCourses);
    }
}
