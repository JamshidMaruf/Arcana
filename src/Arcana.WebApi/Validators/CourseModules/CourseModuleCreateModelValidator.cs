using FluentValidation;
using Arcana.WebApi.Models.CourseModules;

namespace Arcana.WebApi.Validators.CourseModules;

public class CourseModuleCreateModelValidator : AbstractValidator<CourseModuleCreateModel>
{
    public CourseModuleCreateModelValidator()
    {
        RuleFor(courseModule => courseModule.Name)
            .NotNull()
            .WithMessage(courseModule => $"{nameof(courseModule.Name)} is not specified");

        RuleFor(courseModule => courseModule.CourseId)
            .NotNull()
            .WithMessage(courseModule => $"{nameof(courseModule.CourseId)} is not specified");
    }
}
