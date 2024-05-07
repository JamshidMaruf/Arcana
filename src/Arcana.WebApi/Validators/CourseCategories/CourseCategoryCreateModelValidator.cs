using Arcana.WebApi.Models.CourseCategories;
using FluentValidation;

namespace Arcana.WebApi.Validators.CourseCategories;

public class CourseCategoryCreateModelValidator : AbstractValidator<CourseCategoryCreateModel>
{
    public CourseCategoryCreateModelValidator()
    {
        RuleFor(CourseCategory => CourseCategory.Name)
            .NotNull()
             .WithMessage(CourseCategory => $"{nameof(CourseCategory.Name)} is not specified");
    }
}
