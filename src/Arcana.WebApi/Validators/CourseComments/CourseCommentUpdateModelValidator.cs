using Arcana.WebApi.Models.CourseComments;
using FluentValidation;

namespace Arcana.WebApi.Validators.CourseComments;

public class CourseCommentUpdateModelValidator : AbstractValidator<CourseCommentUpdateModel>
{
    public CourseCommentUpdateModelValidator()
    {
        RuleFor(CourseComment => CourseComment.CourseId)
          .NotNull()
          .WithMessage(CourseComment => $"{nameof(CourseComment.CourseId)} is not specified");

        RuleFor(CourseComment => CourseComment.StudentId)
            .NotNull()
            .WithMessage(CourseComment => $"{nameof(CourseComment.StudentId)} is not specified");

        RuleFor(CourseComment => CourseComment.Content)
            .NotNull()
            .WithMessage(CourseComment => $"{nameof(CourseComment.Content)} is not specified");
    }
}