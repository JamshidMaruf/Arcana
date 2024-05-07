using Arcana.WebApi.Models.CourseComments;
using FluentValidation;

namespace Arcana.WebApi.Validators.CourseComments;

public class CourseCommentCreateModelValidator : AbstractValidator<CourseCommentCreateModel>
{
    public CourseCommentCreateModelValidator()
    {
        RuleFor(CourseComment => CourseComment.Content)
            .NotNull()
            .WithMessage(CourseComment => $"{nameof(CourseComment.Content)} is not specified");
    }
}
