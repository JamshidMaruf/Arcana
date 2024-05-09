using Arcana.WebApi.Models.InstructorStars;
using FluentValidation;

namespace Arcana.WebApi.Validators.InstructorStars;

public class InstructorStarCreateModelValidator : AbstractValidator<InstructorStarCreateModel>
{
    public InstructorStarCreateModelValidator()
    {
        RuleFor(instructorStars => instructorStars.Stars)
            .NotNull()
            .WithMessage(instructorStars => $"{nameof(instructorStars.Stars)} is not specified");
        RuleFor(instructorStars => instructorStars.StudentId)
            .NotNull()
            .WithMessage(instructorStars => $"{nameof(instructorStars.StudentId)} is not specified");
        RuleFor(instructorStars => instructorStars.InstructorId)
            .NotNull()
            .WithMessage(instructorStars => $"{nameof(instructorStars.InstructorId)} is not specified");
    }
}