using FluentValidation;
using Arcana.WebApi.Models.Lessons;

namespace Arcana.WebApi.Validators.Lessons;

public class LessonUpdateModelValidator : AbstractValidator<LessonUpdateModel>
{
    public LessonUpdateModelValidator()
    {
        RuleFor(lesson => lesson.Title)
            .NotNull()
            .WithMessage(lesson => $"{nameof(lesson.Title)} is not specified");

        RuleFor(lesson => lesson.ModuleId)
            .NotNull()
            .WithMessage(lesson => $"{nameof(lesson.ModuleId)} is not specified");
    }
}