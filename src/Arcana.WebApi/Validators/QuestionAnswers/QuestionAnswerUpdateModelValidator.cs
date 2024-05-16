using Arcana.WebApi.Models.QuestionAnswers;
using FluentValidation;

namespace Arcana.WebApi.Validators.QuestionAnswers;

public class QuestionAnswerUpdateModelValidator : AbstractValidator<QuestionAnswerUpdateModel>
{
    public QuestionAnswerUpdateModelValidator()
    {
        RuleFor(questionAnswer => questionAnswer.QuizId)
            .NotNull()
            .WithMessage(questionAnswer => $"{nameof(questionAnswer.QuizId)} is not specified");

        RuleFor(questionAnswer => questionAnswer.StudentId)
            .NotNull()
            .WithMessage(questionAnswer => $"{nameof(questionAnswer.StudentId)} is not specified");

        RuleFor(questionAnswer => questionAnswer.QuestionId)
            .NotNull()
            .WithMessage(questionAnswer => $"{nameof(questionAnswer.QuestionId)} is not specified");

        RuleFor(questionAnswer => questionAnswer.OptionId)
            .NotNull()
            .WithMessage(questionAnswer => $"{nameof(questionAnswer.OptionId)} is not specified");
    }
}
