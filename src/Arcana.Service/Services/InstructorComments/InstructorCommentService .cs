using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.InstructorComments;

public class InstructorCommentService(IUnitOfWork unitOfWork) : IInstructorCommentService
{
    public async ValueTask<InstructorComment> CreateAsync(InstructorComment instructorComment)
    {
        var existInstructor = await unitOfWork.Instructors.SelectAsync(i => i.Id == instructorComment.InstructorId && !i.IsDeleted, includes: ["Detail"])
            ??throw new NotFoundException($"Instructor is not found with this ID = {instructorComment.InstructorId}");
        var existStudent = await unitOfWork.Students.SelectAsync(i => i.Id == instructorComment.StudentId && !i.IsDeleted, includes: ["Detail"])
            ?? throw new NotFoundException($"Instructor is not found with this ID = {instructorComment.InstructorId}");
        
        instructorComment.CreatedByUserId = HttpContextHelper.UserId;
        var createdInstructorComment = await unitOfWork.InstructorComments.InsertAsync(instructorComment);
        await unitOfWork.SaveAsync();

        createdInstructorComment.Instructor = existInstructor;
        createdInstructorComment.Student = existStudent;
        
        return createdInstructorComment;
    }

    public async ValueTask<InstructorComment> UpdateAsync(long id, InstructorComment model)
    {
        var existInstructor = await unitOfWork.InstructorComments.SelectAsync(c => c.Id == model.InstructorId && !c.IsDeleted)
            ??throw new NotFoundException($"Instructor is not found with this ID = {id}");
       
        var existInstructorComment = await unitOfWork.InstructorComments.SelectAsync(ic => ic.Id == id && !ic.IsDeleted, ["Student", "Instructor"])
            ??throw new NotFoundException($"Instructor comment is not found with this ID = {id}");

        existInstructorComment.Content = model.Content;
        existInstructorComment.CreatedByUserId= HttpContextHelper.UserId;

        await unitOfWork.InstructorComments.UpdateAsync(existInstructorComment);
        await unitOfWork.SaveAsync();
        return existInstructorComment;

    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existInstructorComment = await unitOfWork.InstructorComments.SelectAsync(ic => ic.Id == id && !ic.IsDeleted)
            ?? throw new NotFoundException($"Instructor comment is not found with this ID = {id}");

        existInstructorComment.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.InstructorComments.DeleteAsync(existInstructorComment);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<InstructorComment> GetByIdAsync(long id)
    {
        var existInstructorComment = await unitOfWork.InstructorComments.
            SelectAsync(expression: ic => ic.Id == id && !ic.IsDeleted, includes: ["Student.Detail", "Instructor.Detail"])
            ?? throw new NotFoundException($"Instructor comment is not found with this ID = {id}");

        return existInstructorComment;
    }

    public async ValueTask<IEnumerable<InstructorComment>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var instructorComments = unitOfWork.InstructorComments.
            SelectAsQueryable(expression: ic => !ic.IsDeleted,
            includes: ["Student.Detail", "Instructor.Detail"],
            isTracked: false).OrderBy(filter);


        if (!string.IsNullOrEmpty(search))
            instructorComments = instructorComments.Where(lc => lc.Content.ToLower().Contains(search.ToLower()));

        return await instructorComments.ToPaginateAsQueryable(@params).ToListAsync();
    }
}
