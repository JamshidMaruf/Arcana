using Arcana.WebApi.Models.Questions;
using FluentValidation;

namespace Arcana.WebApi.Validators.Questions;

public class QuestionCreateModelValidator : AbstractValidator<QuestionCreateModel>
{
    public QuestionCreateModelValidator()
    {
        RuleFor(question => question.Content)
            .NotNull()
            .WithMessage(question => $"{nameof(question.Content)} is not specified");
    }
}