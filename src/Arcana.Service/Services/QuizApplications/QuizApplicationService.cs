using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.QuizApplications;
using Arcana.Service.Configurations;
using Arcana.Service.Exceptions;
using Arcana.Service.Extensions;
using Arcana.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arcana.Service.Services.QuizApplications;

public class QuizApplicationService(IUnitOfWork unitOfWork) : IQuizApplicationService
{
    public async ValueTask<QuizApplication> CreateAsync(QuizApplication quizApplication)
    {
        var existQuiz = await unitOfWork.Quizzes.SelectAsync(quiz => quiz.Id == quizApplication.QuizId && !quiz.IsDeleted)
             ?? throw new NotFoundException($"Quiz is not found with this ID = {quizApplication.QuizId}");

        var existStudent = await unitOfWork.Students.SelectAsync(student => student.Id == quizApplication.StudentId && !student.IsDeleted)
            ?? throw new NotFoundException($"Student is not found with this ID = {quizApplication.StudentId}");

        var existQuizApplication = await unitOfWork.QuizApplications.SelectAsync(qa =>
            qa.QuizId == quizApplication.QuizId &&
            qa.StudentId == quizApplication.StudentId);

        if (existQuizApplication is not null)
            throw new AlreadyExistException("This quiz application already exists");

        quizApplication.CreatedByUserId = HttpContextHelper.UserId;
        var createdQuizApplication = await unitOfWork.QuizApplications.InsertAsync(quizApplication);
        await unitOfWork.SaveAsync();

        return createdQuizApplication;
    }

    public async ValueTask<QuizApplication> UpdateAsync(long id, QuizApplication quizApplication)
    {
        var existQuiz = await unitOfWork.Quizzes.SelectAsync(quiz => quiz.Id == quizApplication.QuizId && !quiz.IsDeleted)
            ?? throw new NotFoundException($"Quiz is not found with this ID = {quizApplication.QuizId}");

        var existStudent = await unitOfWork.Students.SelectAsync(student => student.Id == quizApplication.StudentId && !student.IsDeleted)
            ?? throw new NotFoundException($"Student is not found with this ID = {quizApplication.StudentId}");

        var existQuizApplication = await unitOfWork.QuizApplications.SelectAsync(qa => qa.Id == id && !qa.IsDeleted)
            ?? throw new NotFoundException($"Quiz application is not found with this Id = {id}");

        existQuizApplication.QuizId = quizApplication.QuizId;
        existQuizApplication.StudentId = quizApplication.StudentId;
        existQuizApplication.UpdatedByUserId = HttpContextHelper.UserId;

        await unitOfWork.QuizApplications.UpdateAsync(existQuizApplication);
        await unitOfWork.SaveAsync();

        return existQuizApplication;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existQuizApplication = await unitOfWork.QuizApplications.SelectAsync(qa => qa.Id == id && !qa.IsDeleted)
           ?? throw new NotFoundException($"Quiz application is not found with this ID={id}");

        existQuizApplication.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.QuizApplications.DeleteAsync(existQuizApplication);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<QuizApplication> GetByIdAsync(long id)
    {
        var existQuizApplication = await unitOfWork.QuizApplications
            .SelectAsync(qa => qa.Id == id && !qa.IsDeleted, includes: ["Student", "Quiz"])
           ?? throw new NotFoundException($"Quiz application is not found with this ID={id}");

        return existQuizApplication;
    }

    public async ValueTask<IEnumerable<QuizApplication>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var quizApplications = unitOfWork.QuizApplications
            .SelectAsQueryable(expression: qa => !qa.IsDeleted, includes: ["Student", "Quiz"], isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            quizApplications = quizApplications.Where(qa =>
                qa.Quiz.Name.ToLower().Contains(search.ToLower()) ||
                qa.Student.Detail.FirstName.Contains(search.ToLower()) ||
                qa.Student.Detail.LastName.ToLower().Contains(search.ToLower()));

        return await quizApplications.ToPaginateAsQueryable(@params).ToListAsync();
    }
}