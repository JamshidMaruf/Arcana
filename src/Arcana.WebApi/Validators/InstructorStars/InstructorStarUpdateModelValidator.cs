using FluentValidation;
using Arcana.WebApi.Models.InstructorStars;

namespace Arcana.WebApi.Validators.InstructorStars;

public class InstructorStarUpdateModelValidator : AbstractValidator<InstructorStarUpdateModel>
{
    public InstructorStarUpdateModelValidator()
    {
        RuleFor(instructorStars => instructorStars.Stars)
            .NotNull()
            .GreaterThanOrEqualTo(Convert.ToByte(0))
            .LessThanOrEqualTo(Convert.ToByte(5))
            .WithMessage(instructorStars => $"{nameof(instructorStars.Stars)} is not specified");

        RuleFor(instructorStars => instructorStars.StudentId)
            .NotNull()
            .WithMessage(instructorStars => $"{nameof(instructorStars.StudentId)} is not specified");

        RuleFor(instructorStars => instructorStars.InstructorId)
            .NotNull()
            .WithMessage(instructorStars => $"{nameof(instructorStars.InstructorId)} is not specified");
    }
}