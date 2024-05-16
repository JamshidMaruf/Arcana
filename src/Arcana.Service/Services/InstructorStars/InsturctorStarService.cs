using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.InstructorStars;

public class InstructorStarService(IUnitOfWork unitOfWork) : IInstructorStarService
{
    public async ValueTask<InstructorStar> CreateAsync(InstructorStar instructorStars)
    {
        var existStudent = await unitOfWork.Students.SelectAsync(student => student.Id == instructorStars.StudentId && ! student.IsDeleted)
            ?? throw new NotFoundException($"Student is not found with this Id {instructorStars.StudentId}");

        var existInstructor = await unitOfWork.Instructors.SelectAsync(Instructor => Instructor.Id == instructorStars.InstructorId && !Instructor.IsDeleted, ["Detail"])
            ?? throw new NotFoundException($"Instructor is not found with this Id {instructorStars.InstructorId}");

        var existInstructorStars = await unitOfWork.InstructorStars.SelectAsync(i => i.InstructorId == instructorStars.InstructorId && i.StudentId == instructorStars.StudentId && !i.IsDeleted);
        if (existInstructorStars is not null)
            throw new AlreadyExistException($"This instructorStar already exists with this id={instructorStars.Id}");
        instructorStars.CreatedByUserId = HttpContextHelper.UserId;
        var createdInstructorStars = await unitOfWork.InstructorStars.InsertAsync(instructorStars);

        await unitOfWork.SaveAsync();
        createdInstructorStars.Instructor = existInstructor;
        createdInstructorStars.Student = existStudent;

        return createdInstructorStars;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existInstructorStars = await unitOfWork.InstructorStars.SelectAsync(i => i.Id == id && !i.IsDeleted)
            ?? throw new NotFoundException($"InstructorStars is not found with this ID={id}");

        existInstructorStars.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.InstructorStars.DeleteAsync(existInstructorStars);

        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<InstructorStar>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var instructorStars = unitOfWork.InstructorStars
            .SelectAsQueryable(expression: InstructorStars => !InstructorStars.IsDeleted, includes: ["Student", "Instructor.Detail"], isTracked: false)
            .OrderBy(filter);

        return await instructorStars.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<InstructorStar> GetByIdAsync(long id)
    {
        var existInstructorStars = await unitOfWork.InstructorStars.SelectAsync(i => i.Id == id && !i.IsDeleted, ["Student", "Instructor.Detail"])
            ?? throw new NotFoundException($"InstructorStars is not found with this ID={id}");
        return existInstructorStars;
    }

    public async ValueTask<InstructorStar> UpdateAsync(long id, InstructorStar instructorStars)
    {
        var existStudent = await unitOfWork.Students.SelectAsync(student => student.Id == instructorStars.StudentId && !student.IsDeleted)
           ?? throw new NotFoundException($"Student is not found with this Id {instructorStars.StudentId}");

        var existInstructor = await unitOfWork.Instructors.SelectAsync(Instructor => Instructor.Id == instructorStars.InstructorId && !Instructor.IsDeleted, ["Detail"])
            ?? throw new NotFoundException($"Instructor is not found with this Id {instructorStars.InstructorId}");

        var existInstructorStars = await unitOfWork.InstructorStars.SelectAsync(i => id == i.Id && !i.IsDeleted)
            ?? throw new NotFoundException($"InstructorStars is not found with this ID={id}");

        existInstructorStars.Stars = instructorStars.Stars;
        existInstructorStars.InstructorId = instructorStars.InstructorId;
        existInstructorStars.StudentId = instructorStars.StudentId;
        existInstructorStars.UpdatedByUserId = HttpContextHelper.UserId;

        var updatedInstructorStars = await unitOfWork.InstructorStars.UpdateAsync(existInstructorStars);
        await unitOfWork.SaveAsync();
        updatedInstructorStars.Instructor = existInstructor;
        updatedInstructorStars.Student = existStudent;

        return existInstructorStars;
    }
}