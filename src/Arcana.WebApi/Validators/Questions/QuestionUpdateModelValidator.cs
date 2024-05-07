using Arcana.WebApi.Models.Questions;
using FluentValidation;

namespace Arcana.WebApi.Validators.Questions;

public class QuestionUpdateModelValidator : AbstractValidator<QuestionUpdateModel>
{
    public QuestionUpdateModelValidator()
    {
        RuleFor(question => question.Content)
            .NotNull()
            .WithMessage(question => $"{nameof(question.Content)} is not specified");
    }
}