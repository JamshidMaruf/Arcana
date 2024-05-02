using Arcana.Service.Helpers;
using Arcana.WebApi.Models.Accounts;
using FluentValidation;

namespace Arcana.WebApi.Validators.Accounts;

public class SendCodeModelValidator : AbstractValidator<SendCodeModel>
{
    public SendCodeModelValidator()
    {

        RuleFor(sc => sc.Phone)
            .NotNull()
            .WithMessage(sc => $"{nameof(sc.Phone)} is not specified");

        RuleFor(sc => sc.Phone)
            .Must(ValidationHelper.IsPhoneValid);
    }
}