using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.QuestionOptions;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.QuestionOptions;

public class QuestionOptionService(IUnitOfWork unitOfWork) : IQuestionOptionService
{
    public async ValueTask<QuestionOption> CreateAsync(QuestionOption questionOption)
    {
        questionOption.CreatedByUserId = HttpContextHelper.UserId;
        var createdQuestionAnswer = await unitOfWork.QuestionOptions.InsertAsync(questionOption);
        await unitOfWork.SaveAsync();

        return createdQuestionAnswer;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existQuestionOption = await unitOfWork.QuestionOptions.SelectAsync(questionOption => questionOption.Id == id && !questionOption.IsDeleted)
           ?? throw new NotFoundException($"Question option is not found with this ID={id}");

        existQuestionOption.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.QuestionOptions.DeleteAsync(existQuestionOption);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<QuestionOption>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var questionOptions = unitOfWork.QuestionOptions.
            SelectAsQueryable(expression: questionOption => !questionOption.IsDeleted, includes: ["Question"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            questionOptions = questionOptions.Where(questionOption =>
            questionOption.Content.ToLower().Contains(search.ToLower()));

        return await questionOptions.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<QuestionOption> GetByIdAsync(long id)
    {
        var existQuestionOption = await unitOfWork.QuestionOptions
           .SelectAsync(questionOption => questionOption.Id == id && !questionOption.IsDeleted, includes: ["Question"])
           ?? throw new NotFoundException($"Question option is not found with this ID={id}");

        return existQuestionOption;
    }

    public async ValueTask<QuestionOption> UpdateAsync(long id, QuestionOption questionOption)
    {
        var existQuestionOption = await unitOfWork.QuestionOptions.SelectAsync(questionOption => questionOption.Id == id && !questionOption.IsDeleted)
            ?? throw new NotFoundException($"Question option is not found with this ID={id}");

        existQuestionOption.Content = questionOption.Content;

        existQuestionOption.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.QuestionOptions.UpdateAsync(existQuestionOption);
        await unitOfWork.SaveAsync();

        return existQuestionOption;
    }
}
