using Arcana.Service.Helpers;
using Arcana.WebApi.Models.Students;
using FluentValidation;

namespace Arcana.WebApi.Validators.Students;

public class StudentCreateModelValidator : AbstractValidator<StudentCreateModel>
{
    public StudentCreateModelValidator()
    {
        RuleFor(student => student.FirstName)
            .NotNull()
            .WithMessage(student => $"{nameof(student.FirstName)} is not specified");

        RuleFor(student => student.FirstName)
            .NotNull()
            .WithMessage(student => $"{nameof(student.FirstName)} is not specified");

        RuleFor(student => student.Phone)
            .NotNull()
            .WithMessage(student => $"{nameof(student.Phone)} is not specified");

        RuleFor(student => student.Phone)
            .Must(ValidationHelper.IsPhoneValid);

        RuleFor(student => student.Email)
            .Must(ValidationHelper.IsEmailValid);

        RuleFor(student => student.Password)
            .Must(ValidationHelper.IsPasswordHard);
    }
}