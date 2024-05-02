using Arcana.Service.Helpers;
using Arcana.WebApi.Models.Instructors;
using FluentValidation;

namespace Arcana.WebApi.Validators.Instructors;

public class InstructorUpdateModelValidator : AbstractValidator<InstructorUpdateModel>
{
    public InstructorUpdateModelValidator()
    {
        RuleFor(instructor => instructor.Detail.FirstName)
            .NotNull()
            .WithMessage(instructor => $"{nameof(instructor.Detail.FirstName)} is not specified");

        RuleFor(instructor => instructor.Detail.FirstName)
            .NotNull()
            .WithMessage(instructor => $"{nameof(instructor.Detail.FirstName)} is not specified");

        RuleFor(instructor => instructor.Profession)
            .NotNull()
            .WithMessage(instructor => $"{nameof(instructor.Profession)} is not specified");

        RuleFor(instructor => instructor.Detail.Phone)
            .NotNull()
            .WithMessage(instructor => $"{nameof(instructor.Detail.Phone)} is not specified");

        RuleFor(instructor => instructor.Detail.Phone)
            .Must(ValidationHelper.IsPhoneValid);

        RuleFor(instructor => instructor.Detail.Email)
            .Must(ValidationHelper.IsEmailValid);
    }
}