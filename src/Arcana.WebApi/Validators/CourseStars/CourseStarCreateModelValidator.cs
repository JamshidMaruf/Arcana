using Arcana.WebApi.Models.CourseStars;
using FluentValidation;

namespace Arcana.WebApi.Validators.CourseStars;

public class CourseStarCreateModelValidator : AbstractValidator<CourseStarCreateModel>
{
    public CourseStarCreateModelValidator()
    {
        RuleFor(courseStar => courseStar.Stars)
            .NotNull()
            .GreaterThanOrEqualTo(Convert.ToByte(0))
            .LessThanOrEqualTo(Convert.ToByte(5))
            .WithMessage(courseStar => $"{nameof(courseStar.Stars)} is not specified");

        RuleFor(courseStar => courseStar.StudentId)
            .NotNull()
            .WithMessage(courseStar => $"{nameof(courseStar.StudentId)} is not specified");

        RuleFor(courseStar => courseStar.CourseId)
            .NotNull()
            .WithMessage(courseStar => $"{nameof(courseStar.CourseId)} is not specified");
    }
}
