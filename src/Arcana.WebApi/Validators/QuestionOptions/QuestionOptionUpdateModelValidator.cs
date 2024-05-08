using Arcana.WebApi.Models.QuestionOptions;
using FluentValidation;

namespace Arcana.WebApi.Validators.QuestionOptions;
public class QuestionOptionUpdateModelValidator : AbstractValidator<QuestionOptionUpdateModel>
{
    public QuestionOptionUpdateModelValidator()
    {
        RuleFor(questionAnswer => questionAnswer.Content)
            .NotNull()
            .WithMessage(questionAnswer => $"{nameof(questionAnswer.Content)} is not specified");
    }
}
