﻿using Arcana.DataAccess.UnitOfWorks;
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
        var existModule = await unitOfWork.CourseModules.SelectAsync(module => module.Id == question.ModuleId)
            ?? throw new NotFoundException($"Module is not found with this ID={question.ModuleId}");
        question.CreatedByUserId = HttpContextHelper.UserId;
        var createdQuestion = await unitOfWork.Questions.InsertAsync(question);
        createdQuestion.Module = existModule;
        await unitOfWork.SaveAsync();

        return createdQuestion;
    }

    public async ValueTask<Question> UpdateAsync(long id, Question question)
    {
        var existQuestion = await unitOfWork.Questions.SelectAsync(question => question.Id == id && !question.IsDeleted)
            ?? throw new NotFoundException($"Question is not found with this ID={id}");

        existQuestion.Content = question.Content;

        existQuestion.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Questions.UpdateAsync(existQuestion);
        await unitOfWork.SaveAsync();

        return existQuestion;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existQuestion = await unitOfWork.Questions.SelectAsync(question => question.Id == id && !question.IsDeleted)
            ?? throw new NotFoundException($"Question is not found with this ID={id}");

        existQuestion.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Questions.DeleteAsync(existQuestion);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<Question>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        // Prepare the base query
        var query = unitOfWork.Questions
            .SelectAsQueryable(question => !question.IsDeleted, includes: ["File", "Module"], isTracked: false)
            .OrderBy(filter);

        // Apply search filter if provided
        if (!string.IsNullOrEmpty(search))
        {
            var lowerSearch = search.ToLower();
            query = query.Where(question => question.Content.ToLower().Contains(lowerSearch));
        }

        // Apply pagination before fetching the data
        var paginatedQuery = query.ToPaginateAsQueryable(@params);

        // Fetch the data including paginated result
        var questions = await paginatedQuery.ToListAsync();

        // Fetch and assign related QuestionOptions for each question
        foreach (var question in questions)
        {
            var options = await unitOfWork.QuestionOptions
                .SelectAsEnumerableAsync(option => option.QuestionId == question.Id);

            question.Options = options.ToList();
        }

        return questions;
    }



    public async ValueTask<Question> GetByIdAsync(long id)
    {
        var existQuestion = await unitOfWork.Questions
            .SelectAsync(question => question.Id == id && !question.IsDeleted, includes: ["File", "Module"])
            ?? throw new NotFoundException($"Question is not found with this ID={id}");

        var options = unitOfWork.QuestionOptions.SelectAsEnumerableAsync(
            expression: option => option.QuestionId == existQuestion.Id
            );

        existQuestion.Options = await options;

        return existQuestion;
    }

    public async ValueTask<Question> UploadFileAsync(long id, IFormFile file)
    {
        await unitOfWork.BeginTransactionAsync();

        var existQuestion = await unitOfWork.Questions
            .SelectAsync(question => question.Id == id && !question.IsDeleted, includes: ["File", "Module"])
            ?? throw new NotFoundException($"Question is not found with this ID={id}");

        var createdFile = await assetService.UploadAsync(file, FileType.Pictures);

        existQuestion.File = createdFile;
        existQuestion.FileId = createdFile.Id;
        existQuestion.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Questions.UpdateAsync(existQuestion);
        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return existQuestion;
    }

    public async ValueTask<Question> DeleteFileAsync(long id)
    {
        await unitOfWork.BeginTransactionAsync();

        var existQuestion = await unitOfWork.Questions
            .SelectAsync(question => question.Id == id && !question.IsDeleted, includes: ["File", "Module"])
            ?? throw new NotFoundException($"Question is not found with this ID={id}");

        await assetService.DeleteAsync(Convert.ToInt64(existQuestion.FileId));

        existQuestion.FileId = null;
        await unitOfWork.Questions.UpdateAsync(existQuestion);
        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return existQuestion;
    }

    public async ValueTask<List<Question>> GetShuffledListAsync(long moduleId, int questionCount)
    {
        var questions = await unitOfWork.Questions
            .SelectAsQueryable(question => question.ModuleId == moduleId && !question.IsDeleted)
            .ToListAsync();

        return Shuffle(questions).Take(questionCount).ToList();
    }

    private List<Question> Shuffle(List<Question> questions)
    {
        int n = questions.Count();
        Random rnd = new Random();
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            Question value = questions[k];
            questions[k] = questions[n];
            questions[n] = value;
        }

        return questions;
    }
}