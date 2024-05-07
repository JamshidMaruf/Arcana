using FluentValidation;
using Arcana.WebApi.Models.LessonComments;

namespace Arcana.WebApi.Validators.LessonComments;

public class LessonCommentCreateModelValidator : AbstractValidator<LessonCommentCreateModel>
{
    public LessonCommentCreateModelValidator()
    {
        RuleFor(lessonComment => lessonComment.LessonId)
            .NotNull()
            .WithMessage(lessonComment => $"{nameof(lessonComment.LessonId)} is not specified");

        RuleFor(lessonComment => lessonComment.Content)
           .NotNull()
           .WithMessage(lessonComment => $"{nameof(lessonComment.Content)} is not specified");
    }
}