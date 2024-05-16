using Arcana.WebApi.Models.CourseStars;
using FluentValidation;

namespace Arcana.WebApi.Validators.CourseStars;

public class CourseStarUpdateModelValidator : AbstractValidator<CourseStarUpdateModel>
{
    public CourseStarUpdateModelValidator()
    {
        RuleFor(courseStar => courseStar.Stars)
            .NotNull()
            .GreaterThanOrEqualTo(Convert.ToByte(0))
            .LessThanOrEqualTo(Convert.ToByte(5))
            .WithMessage(courseStar => $"{nameof(courseStar.Stars)} is not specified");
    }
}