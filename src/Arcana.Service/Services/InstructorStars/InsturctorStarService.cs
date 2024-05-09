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
        var existInstructorStars = await unitOfWork.InstructorStars.SelectAsync(i => i.InstructorId == instructorStars.InstructorId && i.StudentId == instructorStars.StudentId);
        if (existInstructorStars is not null)
            throw new AlreadyExistException($"This instructorStar already exists with this id={instructorStars.Id}");
        instructorStars.CreatedByUserId = HttpContextHelper.UserId;
        var createdInstructorStars = await unitOfWork.InstructorStars.InsertAsync(instructorStars);

        await unitOfWork.SaveAsync();

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
            .SelectAsQueryable(expression: InstructorStars => !InstructorStars.IsDeleted, isTracked: false)
            .OrderBy(filter);
        return await instructorStars.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<InstructorStar> GetByIdAsync(long id)
    {
        var existInstructorStars = await unitOfWork.InstructorStars.SelectAsync(i => i.Id == id)
            ?? throw new NotFoundException($"InstructorStars is not found with this ID={id}");
        return existInstructorStars;
    }

    public async ValueTask<InstructorStar> UpdateAsync(long id, InstructorStar instructorStars)
    {
        var existInstructorStars = await unitOfWork.InstructorStars.SelectAsync(i => id == i.Id)
            ?? throw new NotFoundException($"InstructorStars is not found with this ID={id}");
        existInstructorStars.InstructorId = instructorStars.Id;
        existInstructorStars.StudentId = instructorStars.StudentId;
        existInstructorStars.Stars = instructorStars.Stars;
        existInstructorStars.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.InstructorStars.UpdateAsync(existInstructorStars);
        await unitOfWork.SaveAsync();

        return existInstructorStars;
    }
}
