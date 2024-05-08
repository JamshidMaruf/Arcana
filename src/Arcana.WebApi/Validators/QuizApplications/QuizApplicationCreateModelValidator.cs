using FluentValidation;
using Arcana.WebApi.Models.QuizApplications;

namespace Arcana.WebApi.Validators.QuizApplications;

public class QuizApplicationCreateModelValidator : AbstractValidator<QuizApplicationCreateModel>
{
    public QuizApplicationCreateModelValidator()
    {
        RuleFor(quizApplication => quizApplication.QuizId)
            .NotNull()
            .WithMessage(quizApplication => $"{nameof(quizApplication.QuizId)} is not specified");

        RuleFor(quizApplication => quizApplication.StudentId)
            .NotNull()
            .WithMessage(quizApplication => $"{nameof(quizApplication.StudentId)} is not specified");
    }
}
