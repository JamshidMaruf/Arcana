using Arcana.WebApi.Models.InstructorComments;
using FluentValidation;

namespace Arcana.WebApi.Validators.InstructorComments;

public class InstructorCommentCreateModelValidator : AbstractValidator<InstructorCommentCreateModel>
{
    public InstructorCommentCreateModelValidator()
    {
        RuleFor(ic => ic.InstructorId)
            .NotNull()
            .WithMessage(ic => $"{nameof(ic.InstructorId)} is not specified");
      
        RuleFor(ic => ic.StudentId)
            .NotNull()
            .WithMessage(ic => $"{nameof(ic.StudentId)} is not specified");

        RuleFor(ic => ic.Content)
           .NotNull()
           .WithMessage(ic => $"{nameof(ic.Content)} is not specified");
    }
}
