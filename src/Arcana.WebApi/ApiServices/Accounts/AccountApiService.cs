using Arcana.Service.Services.Users;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.Accounts;
using Arcana.WebApi.Models.Users;
using Arcana.WebApi.Validators.Accounts;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.Accounts;

public class AccountApiService(
    IMapper mapper,
    IUserService userService,
    LoginModelValidator loginModelValidator,
    SendCodeModelValidator sendCodeModelValidator,
    ConfirmCodeModelValidator confirmCodeModelValidator,
    ResetPasswordModelValidator resetPasswordModelValidator) : IAccountApiService
{
    public async ValueTask<bool> ConfirmCodeAsync(ConfirmCodeModel confirmCodeModel)
    {
        await confirmCodeModelValidator.EnsureValidatedAsync(confirmCodeModel);
        return await userService.ConfirmCodeAsync(confirmCodeModel.Phone, confirmCodeModel.Code);
    }

    public async ValueTask<UserLoginViewModel> LoginAsync(LoginModel loginModel)
    {
        await loginModelValidator.EnsureValidatedAsync(loginModel);
        var loginResult = await userService.LoginAsync(loginModel.Phone, loginModel.Password);
        var mappedUser = mapper.Map<UserLoginViewModel>(loginResult.user);
        mappedUser.Token = loginResult.token;
        return mappedUser;
    }

    public async ValueTask<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel)
    {
        await resetPasswordModelValidator.EnsureValidatedAsync(resetPasswordModel);
        return await userService.ResetPasswordAsync(resetPasswordModel.Phone, resetPasswordModel.NewPassword);
    }

    public async ValueTask<bool> SendCodeAsync(SendCodeModel sendCodeModel)
    {
        await sendCodeModelValidator.EnsureValidatedAsync(sendCodeModel);
        return await userService.SendCodeAsync(sendCodeModel.Phone);
    }
}