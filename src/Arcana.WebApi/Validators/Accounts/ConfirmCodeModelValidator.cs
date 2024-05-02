using Arcana.Service.Helpers;
using Arcana.WebApi.Models.Accounts;
using FluentValidation;

namespace Arcana.WebApi.Validators.Accounts;

public class ConfirmCodeModelValidator : AbstractValidator<ConfirmCodeModel>
{
    public ConfirmCodeModelValidator()
    {
        RuleFor(cc => cc.Code)
            .NotNull()
            .WithMessage(cc => $"{nameof(cc.Code)} is not specified");

        RuleFor(cc => cc.Phone)
            .Must(ValidationHelper.IsPhoneValid);
    }
}
