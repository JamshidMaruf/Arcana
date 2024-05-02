using Arcana.WebApi.Models.Accounts;
using Arcana.WebApi.Models.Users;

namespace Arcana.WebApi.ApiServices.Accounts;

public interface IAccountApiService
{
    ValueTask<UserLoginViewModel> LoginAsync(LoginModel loginModel);
    ValueTask<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel);
    ValueTask<bool> SendCodeAsync(SendCodeModel sendCodeModel);
    ValueTask<bool> ConfirmCodeAsync(ConfirmCodeModel confirmCodeModel);
}