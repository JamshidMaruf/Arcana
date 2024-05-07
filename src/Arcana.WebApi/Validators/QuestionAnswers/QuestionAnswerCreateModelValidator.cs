using Arcana.WebApi.Models.QuestionAnswers;
using FluentValidation;

namespace Arcana.WebApi.Validators.QuestionAnswers;
public class QuestionAnswerCreateModelValidator : AbstractValidator<QuestionAnswerCreateModel>
{
    public QuestionAnswerCreateModelValidator()
    {
        RuleFor(questionAnswer => questionAnswer.Content)
            .NotNull()
            .WithMessage(questionAnswer => $"{nameof(questionAnswer.Content)} is not specified");
    }
}