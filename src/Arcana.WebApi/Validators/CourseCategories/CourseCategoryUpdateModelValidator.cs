using Arcana.WebApi.Models.CourseCategories;
using FluentValidation;

namespace Arcana.WebApi.Validators.CourseCategories;

public class CourseCategoryUpdateModelValidator : AbstractValidator<CourseCategoryUpdateModel>
{
    public CourseCategoryUpdateModelValidator()
    {
        RuleFor(CourseCategory => CourseCategory.Name)
            .NotNull()
            .WithMessage(CourseCategory => $"{nameof(CourseCategory.Name)} is not specified");
    }
}
