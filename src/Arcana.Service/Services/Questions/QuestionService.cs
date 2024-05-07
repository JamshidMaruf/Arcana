using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Questions;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Arcana.Service.Services.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.Questions;

public class QuestionService(IUnitOfWork unitOfWork, IAssetService assetService) : IQuestionService
{
    public async ValueTask<Question> CreateAsync(Question question)
    {
        question.CreatedByUserId = HttpContextHelper.UserId;
        var createdQuestion = await unitOfWork.Questions.InsertAsync(question);

        await unitOfWork.SaveAsync();

        return createdQuestion;
    }

    public async ValueTask<Question> UpdateAsync(long id, Question question)
    {
        var existQuestion = await unitOfWork.Questions.SelectAsync(question => question.Id == id && !question.IsDeleted)
            ?? throw new NotFoundException($"Question is not found with this ID={id}");

        existQuestion.Content = question.Content;

        existQuestion.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.SaveAsync();

        return existQuestion;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existQuestion = await unitOfWork.Questions.SelectAsync(question => question.Id == id && !question.IsDeleted)
            ?? throw new NotFoundException($"Question is not found with this ID={id}");

        existQuestion.DeletedByUserId = HttpContextHelper.UserId;

        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<Question>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var questions = unitOfWork.Questions.
            SelectAsQueryable(expression: question => !question.IsDeleted, includes: ["File"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            questions = questions.Where(question =>
            question.Content.ToLower().Contains(search.ToLower()));

        return await questions.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Question> GetByIdAsync(long id)
    {
        var existQuestion = await unitOfWork.Questions
            .SelectAsync(question => question.Id == id && !question.IsDeleted, includes: ["File"])
            ?? throw new NotFoundException($"Question is not found with this ID={id}");

        return existQuestion;
    }

    public async ValueTask<Question> UploadFileAsync(long id, IFormFile file)
    {
        var existQuestion = await unitOfWork.Questions
            .SelectAsync(question => question.Id == id && !question.IsDeleted, includes: ["File"])
            ?? throw new NotFoundException($"Question is not found with this ID={id}");

        var createdFile = await assetService.UploadAsync(file, FileType.Pictures);

        existQuestion.File = createdFile;
        existQuestion.FileId = createdFile.Id;
        existQuestion.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Questions.UpdateAsync(existQuestion);
        await unitOfWork.SaveAsync();

        return existQuestion;
    }

    public async ValueTask<Question> DeleteFileAsync(long id)
    {
        var existQuestion = await unitOfWork.Questions
            .SelectAsync(question => question.Id == id && !question.IsDeleted, includes: ["File"])
            ?? throw new NotFoundException($"Question is not found with this ID={id}");

        await assetService.DeleteAsync(Convert.ToInt64(existQuestion.FileId));

        existQuestion.FileId = null;
        await unitOfWork.Questions.UpdateAsync(existQuestion);
        await unitOfWork.SaveAsync();

        return existQuestion;
    }
}