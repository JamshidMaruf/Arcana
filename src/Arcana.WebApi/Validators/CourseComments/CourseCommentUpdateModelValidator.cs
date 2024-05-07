using Arcana.WebApi.Models.CourseComments;
using FluentValidation;

namespace Arcana.WebApi.Validators.CourseComments;

public class CourseCommentUpdateModelValidator : AbstractValidator<CourseCommentCreateModel>
{
    public CourseCommentUpdateModelValidator()
    {
        RuleFor(CourseComment => CourseComment.Content)
            .NotNull()
            .WithMessage(CourseComment => $"{nameof(CourseComment.Content)} is not specified");
    }
}