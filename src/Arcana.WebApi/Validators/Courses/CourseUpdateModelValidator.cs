using Arcana.WebApi.Models.Courses;
using FluentValidation;

namespace Arcana.WebApi.Validators.Courses;

public class CourseUpdateModelValidator : AbstractValidator<CourseUpdateModel>
{
    public CourseUpdateModelValidator()
    {
        RuleFor(course => course.Name)
            .NotNull()
            .WithMessage(instructor => $"{nameof(instructor.Name)} is not specified");

        RuleFor(course => course.Description)
            .NotNull()
            .WithMessage(instructor => $"{nameof(instructor.Description)} is not specified");

        RuleFor(course => course.Price)
            .NotNull()
            .WithMessage(instructor => $"{nameof(instructor.Price)} is not specified");

        RuleFor(course => course.CountOfLessons)
            .NotNull()
            .WithMessage(instructor => $"{nameof(instructor.CountOfLessons)} is not specified");

        RuleFor(course => course.Level)
            .NotNull()
            .WithMessage(instructor => $"{nameof(instructor.Level)} is not specified");

        RuleFor(course => course.Duration)
            .NotNull()
            .WithMessage(instructor => $"{nameof(instructor.Duration)} is not specified");
    }
}
