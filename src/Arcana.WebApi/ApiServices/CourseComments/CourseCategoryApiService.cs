using Arcana.Domain.Entities.CourseComments;
using Arcana.Service.Configurations;
using Arcana.Service.Services.CourseComments;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.CourseComments;
using Arcana.WebApi.Validators.CourseComments;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.CourseComments;

public class CourseCommentApiService(
    IMapper mapper,
    ICourseCommentService courseCommentService,
    CourseCommentCreateModelValidator createModelValidator,
    CourseCommentUpdateModelValidator updateModelValidator) : ICourseCommentApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await courseCommentService.DeleteAsync(id);
    }

    public async ValueTask<CourseCommentViewModel> GetAsync(long id)
    {
        var CourseComment = await courseCommentService.GetByIdAsync(id);
        return mapper.Map<CourseCommentViewModel>(CourseComment);
    }

    public async ValueTask<IEnumerable<CourseCommentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var courseComment = await courseCommentService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CourseCommentViewModel>>(courseComment);
    }

    public async ValueTask<CourseCommentViewModel> PostAsync(CourseCommentCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedCourseComment = mapper.Map<CourseComment>(createModel);
        var createdCourseComment = await courseCommentService.CreateAsync(mappedCourseComment);
        var returnalble = mapper.Map<CourseCommentViewModel>(createdCourseComment);

        returnalble.Student.FirstName = createdCourseComment.Student.Detail.FirstName;
        returnalble.Student.LastName = createdCourseComment.Student.Detail.LastName;
        returnalble.Student.Email = createdCourseComment.Student.Detail.Email;
        returnalble.Student.Phone = createdCourseComment.Student.Detail.Phone;
        returnalble.Student.DateOfBirth = createdCourseComment.Student.Detail.DateOfBirth;

        returnalble.Course.Instructor.Detail.FirstName = createdCourseComment.Student.Detail.FirstName;
        returnalble.Course.Instructor.Detail.LastName = createdCourseComment.Student.Detail.LastName;
        returnalble.Course.Instructor.Detail.Email = createdCourseComment.Student.Detail.Email;
        returnalble.Course.Instructor.Detail.Phone = createdCourseComment.Student.Detail.Phone;
        returnalble.Course.Instructor.Detail.DateOfBirth = createdCourseComment.Student.Detail.DateOfBirth;

        return returnalble;
    }

    public async ValueTask<CourseCommentViewModel> PutAsync(long id, CourseCommentUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var mappedCourseComment = mapper.Map<CourseComment>(updateModel);
        var updatedCourseComment = await courseCommentService.UpdateAsync(id, mappedCourseComment);
        var returnable = mapper.Map<CourseCommentViewModel>(updatedCourseComment);

        returnable.Student.FirstName = updatedCourseComment.Student.Detail.FirstName;
        returnable.Student.LastName = updatedCourseComment.Student.Detail.LastName;
        returnable.Student.Email = updatedCourseComment.Student.Detail.Email;
        returnable.Student.Phone = updatedCourseComment.Student.Detail.Phone;
        returnable.Student.DateOfBirth = updatedCourseComment.Student.Detail.DateOfBirth;

        returnable.Course.Instructor.Detail.FirstName = updatedCourseComment.Student.Detail.FirstName;
        returnable.Course.Instructor.Detail.LastName = updatedCourseComment.Student.Detail.LastName;
        returnable.Course.Instructor.Detail.Email = updatedCourseComment.Student.Detail.Email;
        returnable.Course.Instructor.Detail.Phone = updatedCourseComment.Student.Detail.Phone;
        returnable.Course.Instructor.Detail.DateOfBirth = updatedCourseComment.Student.Detail.DateOfBirth;

        return returnable;
    }
}
