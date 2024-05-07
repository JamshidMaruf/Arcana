using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Arcana.Service.Services.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.QuestionAnswers;

public class QuestionAnswerService(IUnitOfWork unitOfWork) : IQuestionAnswerService
{
    public async ValueTask<QuestionAnswer> CreateAsync(QuestionAnswer questionAnswer)
    {
        questionAnswer.CreatedByUserId = HttpContextHelper.UserId;
        var createdQuestionAnswer = await unitOfWork.QuestionAnswers.InsertAsync(questionAnswer);

        await unitOfWork.SaveAsync();

        return createdQuestionAnswer;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existQuestionAnswer = await unitOfWork.QuestionAnswers.SelectAsync(questionAnswer => questionAnswer.Id == id && !questionAnswer.IsDeleted)
           ?? throw new NotFoundException($"Question Answer is not found with this ID={id}");

        existQuestionAnswer.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.QuestionAnswers.DeleteAsync(existQuestionAnswer);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<QuestionAnswer>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var questionAnswers = unitOfWork.QuestionAnswers.
            SelectAsQueryable(expression: questionAnswer => !questionAnswer.IsDeleted, includes: ["Question"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            questionAnswers = questionAnswers.Where(questionAnswer =>
            questionAnswer.Content.ToLower().Contains(search.ToLower()));

        return await questionAnswers.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<QuestionAnswer> GetByIdAsync(long id)
    {
        var existQuestionAnswer = await unitOfWork.QuestionAnswers
           .SelectAsync(questionAnswer => questionAnswer.Id == id && !questionAnswer.IsDeleted, includes: ["Question"])
           ?? throw new NotFoundException($"Question Answer is not found with this ID={id}");

        return existQuestionAnswer;
    }

    public async ValueTask<QuestionAnswer> UpdateAsync(long id, QuestionAnswer questionAnswer)
    {
        var existQuestionAnswer = await unitOfWork.QuestionAnswers.SelectAsync(questionAnswer => questionAnswer.Id == id && !questionAnswer.IsDeleted)
            ?? throw new NotFoundException($"Question Answer is not found with this ID={id}");

        existQuestionAnswer.Content = questionAnswer.Content;

        existQuestionAnswer.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.QuestionAnswers.UpdateAsync(existQuestionAnswer);
        await unitOfWork.SaveAsync();

        return existQuestionAnswer;
    }
}
