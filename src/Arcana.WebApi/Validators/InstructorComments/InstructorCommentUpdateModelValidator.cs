using Arcana.WebApi.Models.InstructorComments;
using FluentValidation;

namespace Arcana.WebApi.Validators.InstructorComments;

public class InstructorCommentUpdateModelValidator : AbstractValidator<InstructorCommentUpdateModel>
{
    public InstructorCommentUpdateModelValidator()
    {

        RuleFor(ic => ic.Content)
           .NotNull()
           .WithMessage(ic => $"{nameof(ic.Content)} is not specified");
    }
}