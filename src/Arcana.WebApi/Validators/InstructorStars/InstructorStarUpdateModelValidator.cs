using Arcana.WebApi.Models.InstructorStars;
using FluentValidation;

namespace Arcana.WebApi.Validators.InstructorStars;

public class InstructorStarUpdateModelValidator : AbstractValidator<InstructorStarUpdateModel>
{
    public InstructorStarUpdateModelValidator()
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