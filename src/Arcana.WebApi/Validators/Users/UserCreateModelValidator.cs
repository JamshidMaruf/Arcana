using FluentValidation;
using Arcana.Service.Helpers;
using Arcana.WebApi.Models.Users;

namespace Arcana.WebApi.Validators.Users;

public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
{
    public UserCreateModelValidator()
    {
        RuleFor(user => user.FirstName)
            .NotNull()
            .WithMessage(user => $"{nameof(user.FirstName)} is not specified");

        RuleFor(user => user.Phone)
            .NotNull()
            .WithMessage(user => $"{nameof(user.Phone)} is not specified");

        RuleFor(user => user.Phone)
            .Must(ValidationHelper.IsPhoneValid);

        RuleFor(user => user.Email)
            .NotNull()
            .WithMessage(user => $"{nameof(user.Email)} is not specified");

        RuleFor(user => user.Email)
            .Must(ValidationHelper.IsEmailValid);

        RuleFor(user => user.Password)
            .Must(ValidationHelper.IsPasswordHard);
    }
}