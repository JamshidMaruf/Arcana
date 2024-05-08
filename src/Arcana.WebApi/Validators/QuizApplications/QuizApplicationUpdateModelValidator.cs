using FluentValidation;
using Arcana.WebApi.Models.QuizApplications;

namespace Arcana.WebApi.Validators.QuizApplications;

public class QuizApplicationUpdateModelValidator : AbstractValidator<QuizApplicationUpdateModel>
{
    public QuizApplicationUpdateModelValidator()
    {
        RuleFor(quizApplication => quizApplication.QuizId)
            .NotNull()
            .WithMessage(quizApplication => $"{nameof(quizApplication.QuizId)} is not specified");

        RuleFor(quizApplication => quizApplication.StudentId)
            .NotNull()
            .WithMessage(quizApplication => $"{nameof(quizApplication.StudentId)} is not specified");
    }
}
