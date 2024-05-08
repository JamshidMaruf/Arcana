using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.QuizQuestions;
using Arcana.Domain.Entities.Quizzes;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Arcana.Service.Services.Questions;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.Quizzes;

public class QuizService(IUnitOfWork unitOfWork, IQuestionService questionService) : IQuizService
{
    public async ValueTask<Quiz> CreateAsync(Quiz quiz)
    {
        var module = await unitOfWork.CourseModules.SelectAsync(module => module.Id == quiz.ModuleId && !module.IsDeleted)
            ?? throw new NotFoundException($"Module is not found with this ID={quiz.ModuleId}");

        quiz.CreatedByUserId = HttpContextHelper.UserId;
        var createdQuiz = await unitOfWork.Quizzes.InsertAsync(quiz);
        await unitOfWork.SaveAsync();
        createdQuiz.Module = module;

        return createdQuiz;
    }

    public async ValueTask<Quiz> UpdateAsync(long id, Quiz quiz)
    {
        var module = await unitOfWork.CourseModules.SelectAsync(module => module.Id == quiz.ModuleId && !module.IsDeleted)
            ?? throw new NotFoundException($"Module is not found with this ID={quiz.ModuleId}");

        var existQuiz = await unitOfWork.Quizzes.SelectAsync(quiz => quiz.Id == id && !quiz.IsDeleted)
            ?? throw new NotFoundException($"Quiz is not found with this ID={id}");

        existQuiz.Name = quiz.Name;
        existQuiz.ModuleId = quiz.ModuleId;
        existQuiz.QuestionCount = quiz.QuestionCount;
        existQuiz.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.Quizzes.UpdateAsync(existQuiz);
        await unitOfWork.SaveAsync();
        existQuiz.Module = module;

        return existQuiz;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existQuiz = await unitOfWork.Quizzes.SelectAsync(quiz => quiz.Id == id && !quiz.IsDeleted)
            ?? throw new NotFoundException($"Quiz is not found with this ID={id}");

        existQuiz.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Quizzes.DeleteAsync(existQuiz);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<Quiz> GetByIdAsync(long id)
    {
        var existQuiz = await unitOfWork.Quizzes
            .SelectAsync(expression: quiz => quiz.Id == id && !quiz.IsDeleted, includes: ["Module"])
            ?? throw new NotFoundException($"Quiz is not found with this ID={id}");

        return existQuiz;
    }

    public async ValueTask<IEnumerable<Quiz>> GetAllAsync(PaginationParams @params, Filter filter, string search = null, long? moduleId = null)
    {
        var quizzes = unitOfWork.Quizzes
            .SelectAsQueryable(expression: quiz => !quiz.IsDeleted, includes: ["Module"], isTracked: false)
            .OrderBy(filter);

        if (moduleId is not null)
            quizzes = quizzes.Where(quiz => quiz.ModuleId == moduleId);

        if (!string.IsNullOrWhiteSpace(search))
            quizzes = quizzes.Where(quiz => quiz.Name.ToLower().Contains(search.ToLower()));

        return await quizzes.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Quiz> GenerateQuestionsAsync(long quizId, long moduleId)
    {
        var quiz = await unitOfWork.Quizzes
            .SelectAsync(expression: quiz => quiz.Id == quizId && !quiz.IsDeleted, includes: ["Module"])
            ?? throw new NotFoundException($"Quiz is not found with this ID={quizId}");

        var module = await unitOfWork.CourseModules
            .SelectAsync(expression: module => module.Id == moduleId && !module.IsDeleted)
            ?? throw new NotFoundException($"Quiz is not found with this ID={moduleId}");

        var questions = await questionService.GetShuffledListAsync(moduleId, quiz.QuestionCount);

        questions.ForEach(async question =>
            await unitOfWork.QuizQuestions.InsertAsync(new QuizQuestion
            {
                QuestionId = question.Id,
                QuizId = quizId,
                CreatedByUserId = HttpContextHelper.UserId
            }));

        await unitOfWork.SaveAsync();

        quiz.Questions = questions;
        return quiz;
    }
}