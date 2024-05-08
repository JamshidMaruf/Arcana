using Arcana.WebApi.Models.Lessons;
using FluentValidation;

namespace Arcana.WebApi.Validators.Lessons;

public class LessonCreateModelValidator : AbstractValidator<LessonCreateModel>
{
    public LessonCreateModelValidator()
    {
        RuleFor(lesson => lesson.Title)
            .NotNull()
            .WithMessage(lesson => $"{nameof(lesson.Title)} is not specified");

        RuleFor(lesson => lesson.ModuleId)
            .NotNull()
            .WithMessage(lesson => $"{nameof(lesson.ModuleId)} is not specified");
    }
}