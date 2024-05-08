using Arcana.WebApi.Models.QuestionOptions;
using FluentValidation;

namespace Arcana.WebApi.Validators.QuestionOptions;
public class QuestionOptionCreateModelValidator : AbstractValidator<QuestionOptionCreateModel>
{
    public QuestionOptionCreateModelValidator()
    {
        RuleFor(questionAnswer => questionAnswer.Content)
            .NotNull()
            .WithMessage(questionAnswer => $"{nameof(questionAnswer.Content)} is not specified");
    }
}