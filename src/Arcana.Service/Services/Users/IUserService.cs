using Arcana.Domain.Entities.Users;
using Arcana.Service.Configurations;

namespace Arcana.Service.Services.Users;

public interface IUserService
{
    ValueTask<User> CreateAsync(User user);
    ValueTask<User> UpdateAsync(long id, User user);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<User> GetByIdAsync(long id);
    ValueTask<IEnumerable<User>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<(User user, string token)> LoginAsync(string phone, string password);
    ValueTask<bool> ResetPasswordAsync(string phone, string newPassword);
    ValueTask<bool> SendCodeAsync(string phone);
    ValueTask<bool> ConfirmCodeAsync(string phone, string code);
    ValueTask<User> ChangePasswordAsync(string phone, string oldPassword, string newPassword);
}