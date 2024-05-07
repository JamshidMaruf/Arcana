using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Helpers;
using Arcana.Service.Services.Assets;

namespace Arcana.Service.Services.QuestionAnswers;

public class QuestionAnswerService(IUnitOfWork unitOfWork,
    IAssetService assetService, QuestionService questionService) : IQuestionAnswerService
{
    public async ValueTask<QuestionAnswer> CreateAsync(QuestionAnswer questionAnswer)
    {
        var existAnswer = await unitOfWork.QuestionAnswers.SelectAsync(questionAnswer => questionAnswer.Content.ToLower() == questionAnswer.Content.ToLower());
        if (existAnswer is not null)
            throw new AlreadyExistException("Question Answer already exists");

        questionAnswer.CreatedByQuestionId = HttpContextHelper.QuestionId;
        var createdQuestionAnswer = await unitOfWork.QuestionAnswers.InsertAsync(questionAnswer);
        await unitOfWork.SaveAsync();

        return createdQuestionAnswer;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {

        var existAnswer = await unitOfWork.QuestionAnswers.SelectAsync(c => c.Id == id && !c.IsDeleted)
          ?? throw new NotFoundException($"Question Answer is not found with this ID = {id}");

        await unitOfWork.QuestionAnswers.DeleteAsync(existAnswer);
        return true;

    }

    public async ValueTask<IEnumerable<QuestionAnswer>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var questionAnswer = unitOfWork.QuestionAnswers.SelectAsQueryable().OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            questionAnswer = questionAnswer.Where(questionAnswer => questionAnswer.Content.Contains(search, StringComparison.OrdinalIgnoreCase));

        return await questionAnswer.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<QuestionAnswer> GetByIdAsync(long id)
    {
        var existAnswer = await unitOfWork.QuestionAnswers
            .SelectAsync(answer => answer.Id == id && !answer.IsDeleted, includes: ["Question"])
            ?? throw new NotFoundException($"Question Answer is not found with this ID={id}");

        return existAnswer;
    }

    public async ValueTask<QuestionAnswer> UpdateAsync(long id, QuestionAnswer questionAnswer)
    {
        var existAnswer = await unitOfWork.QuestionAnswers.SelectAsync(questionAnswer => questionAnswer.Id == id)
            ?? throw new NotFoundException($"Question Answer is not found with this ID={id}");

        var alreadyExistAnswer = await unitOfWork.QuestionAnswers.SelectAsync(questionAnswer => questionAnswer.Content.ToLower() == questionAnswer.Content.ToLower());
        if (alreadyExistAnswer is not null)
            throw new AlreadyExistException("This question Answer already exists");

        existAnswer.Content = questionAnswer.Content;
        existAnswer.UpdatedByQuestionId = HttpContextHelper.QuestionId;
        await unitOfWork.QuestionAnswers.UpdateAsync(questionAnswer);
        await unitOfWork.SaveAsync();

        return existAnswer;
    }
}
