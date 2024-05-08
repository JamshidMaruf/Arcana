using Arcana.WebApi.Models.LessonComments;
using FluentValidation;

namespace Arcana.WebApi.Validators.LessonComments;

public class LessonCommentUpdateModelValidator : AbstractValidator<LessonCommentUpdateModel>
{
    public LessonCommentUpdateModelValidator()
    {
        RuleFor(lessonComment => lessonComment.LessonId)
            .NotNull()
            .WithMessage(lessonComment => $"{nameof(lessonComment.LessonId)} is not specified");

        RuleFor(lessonComment => lessonComment.Content)
           .NotNull()
           .WithMessage(lessonComment => $"{nameof(lessonComment.Content)} is not specified");
    }
}