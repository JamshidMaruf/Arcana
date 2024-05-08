using FluentValidation;
using Arcana.WebApi.Models.InstructorStars;

namespace Arcana.WebApi.Validators.InstructorStars;

public class InstructorStarCreateModelValidator : AbstractValidator<InstructorStarCreateModel>
{
    public InstructorStarCreateModelValidator()
    {
        RuleFor(instructorStar => instructorStar.Stars)
            .NotNull()
            .WithMessage(instructorStar => $"{nameof(instructorStar.Stars)} is not specified");
        RuleFor(instructorStar => instructorStar.StudentId)
            .NotNull()
            .WithMessage(instructorStar => $"{nameof(instructorStar.StudentId)} is not specified");
        RuleFor(instructorStar => instructorStar.InstructorId)
            .NotNull()
            .WithMessage(instructorStar => $"{nameof(instructorStar.InstructorId)} is not specified");
    }
}