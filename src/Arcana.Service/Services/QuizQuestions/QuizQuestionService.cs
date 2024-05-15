using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.QuizQuestions;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.QuizQuestions;

public class QuizQuestionService(IUnitOfWork unitOfWork) : IQuizQuestionService
{
    public async ValueTask<QuizQuestion> CreateAsync(QuizQuestion quizQuestion)
    {
        var existQuestion = await unitOfWork.Questions.SelectAsync(q => q.Id == quizQuestion.QuestionId && !q.IsDeleted)
            ?? throw new NotFoundException($"Question is not found with this ID={quizQuestion.QuestionId}");

        var existQuiz = await unitOfWork.Quizzes.SelectAsync(q => q.Id == quizQuestion.QuestionId && !q.IsDeleted)
            ?? throw new NotFoundException($"Quiz is not found with this ID={quizQuestion.QuestionId}");

        var existQuizQuestion = await unitOfWork.QuizQuestions
            .SelectAsync(q => q.QuestionId == quizQuestion.QuestionId && q.QuizId == quizQuestion.QuizId && !q.IsDeleted);
        if (existQuizQuestion is not null)
            throw new AlreadyExistException($"This question is already exist in this quiz");

        quizQuestion.CreatedByUserId = HttpContextHelper.UserId;
        var createdQuizQuestion = await unitOfWork.QuizQuestions.InsertAsync(quizQuestion);
        await unitOfWork.SaveAsync();

        return createdQuizQuestion;
    }

    public async ValueTask<QuizQuestion> UpdateAsync(long id, QuizQuestion quizQuestion)
    {
        var existQuizQuestion = await unitOfWork.QuizQuestions.SelectAsync(q => q.Id == id && !q.IsDeleted)
            ?? throw new NotFoundException($"QuizQuestion is not found with this ID={id}");

        var existQuiz = await unitOfWork.Quizzes.SelectAsync(q => q.Id == quizQuestion.QuizId && !q.IsDeleted)
            ?? throw new NotFoundException($"Quiz is not found with this ID={quizQuestion.QuizId}");

        var existQuestion = await unitOfWork.Questions.SelectAsync(q => q.Id == quizQuestion.QuestionId && !q.IsDeleted)
            ?? throw new NotFoundException($"Question is not found with this ID={quizQuestion.QuestionId}");

        var alreadyExistQuizQuestion = await unitOfWork.QuizQuestions
            .SelectAsync(q => q.QuestionId == quizQuestion.QuestionId && q.QuizId == quizQuestion.QuizId && quizQuestion.Id != id && !q.IsDeleted);
        if (existQuizQuestion is not null)
            throw new AlreadyExistException($"This question is already exist in this quiz");

        existQuizQuestion.QuizId = quizQuestion.QuizId;
        existQuizQuestion.QuestionId = quizQuestion.QuestionId;

        existQuizQuestion.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.QuizQuestions.UpdateAsync(existQuizQuestion);
        await unitOfWork.SaveAsync();

        return existQuizQuestion;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existQuizQuestion = await unitOfWork.QuizQuestions.SelectAsync(q => q.Id == id && !q.IsDeleted)
            ?? throw new NotFoundException($"QuizQuestion is not found with this ID={id}");

        existQuizQuestion.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.QuizQuestions.DeleteAsync(existQuizQuestion);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<QuizQuestion> GetByIdAsync(long id)
    {
        var existQuizQuestion = await unitOfWork
            .QuizQuestions
            .SelectAsync(
                expression: quizQuestion => quizQuestion.Id == id && !quizQuestion.IsDeleted, 
                includes: ["Quiz.Module.Course", "Question"])
            ?? throw new NotFoundException($"QuizQuestion is not found with this ID={id}");

        return existQuizQuestion;
    }

    public async ValueTask<IEnumerable<QuizQuestion>> GetAllAsync(
        PaginationParams @params, 
        Filter filter, 
        string search = null,
        long? quizId = null)
    {
        var quizQuestions = unitOfWork
            .QuizQuestions
            .SelectAsQueryable(
                expression: quizQuestions => !quizQuestions.IsDeleted, 
                includes: ["Quiz.Module.Course", "Question"], 
                isTracked: false)
            .OrderBy(filter);

        if (quizId is not null)
            quizQuestions = quizQuestions.Where(quizQuestion => quizQuestion.QuizId == quizId);

        if (!string.IsNullOrEmpty(search))
            quizQuestions = quizQuestions.Where(quizQuestion =>
            quizQuestion.Question.Content.Contains(search.ToLower()) ||
            quizQuestion.Quiz.Name.Contains(search.ToLower()));

        return await quizQuestions.ToPaginateAsQueryable(@params).ToListAsync();
    }
}