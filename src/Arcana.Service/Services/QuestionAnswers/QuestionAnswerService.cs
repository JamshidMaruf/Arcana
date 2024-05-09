using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Service.Exceptions;

namespace Arcana.Service.Services.QuestionAnswers;

public class QuestionAnswerService(IUnitOfWork unitOfWork) : IQuestionAnswerService
{
    public async ValueTask CreateAsync(List<QuestionAnswer> questionAnswers)
    {
        foreach (var questionAnswer in questionAnswers)
        {
            var student = await unitOfWork.Students.SelectAsync(student => student.Id == questionAnswer.StudentId)
                ?? throw new NotFoundException($"Student is not found with this ID={questionAnswer.StudentId}");
        
            var quiz = await unitOfWork.Quizzes.SelectAsync(quiz => quiz.Id == questionAnswer.QuizId)
                ?? throw new NotFoundException($"Quiz is not found with this ID={questionAnswer.QuizId}");
        
            var option = await unitOfWork.QuestionOptions.SelectAsync(option => option.Id == questionAnswer.OptionId)
                ?? throw new NotFoundException($"Option is not found with this ID={questionAnswer.OptionId}");
       
            var question = await unitOfWork.Questions.SelectAsync(question => question.Id == questionAnswer.QuestionId)
                ?? throw new NotFoundException($"Question is not found with this ID={questionAnswer.QuestionId}");
        }

        await unitOfWork.QuestionAnswers.BulkInsertAsync(questionAnswers);
        await unitOfWork.SaveAsync();
    }

    public async ValueTask<IEnumerable<QuestionAnswer>> GetAllByQuizIdAsync(long quizId)
    {
        var quiz = await unitOfWork.Quizzes.SelectAsync(quiz => quiz.Id == quizId)
            ?? throw new NotFoundException($"Quiz is not found with this ID={quizId}");

        return await unitOfWork.QuestionAnswers
            .SelectAsEnumerableAsync(
                expression: questionAnswer => questionAnswer.QuizId == quizId, 
                includes: ["Student", "Option", "Quiz", "Question"],
                isTracked: false);
    }
}
