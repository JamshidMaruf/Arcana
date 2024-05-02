using Arcana.Domain.Entities.Users;
using Arcana.Service.Configurations;
using Arcana.Service.Services.Users;
using Arcana.WebApi.Extensions;
using Arcana.WebApi.Models.Users;
using Arcana.WebApi.Validators.Users;
using AutoMapper;

namespace Arcana.WebApi.ApiServices.Users;

public class UserApiService(
    IMapper mapper,
    IUserService userService,
    UserCreateModelValidator createModelValidator,
    UserUpdateModelValidator updateModelValidator,
    UserChangePasswordModelValidator changePasswordValidator) : IUserApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await userService.DeleteAsync(id);
    }

    public async ValueTask<UserViewModel> GetAsync(long id)
    {
        var user = await userService.GetByIdAsync(id);
        return mapper.Map<UserViewModel>(user);
    }

    public async ValueTask<IEnumerable<UserViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var users = await userService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<UserViewModel>>(users);
    }

    public async ValueTask<UserViewModel> PostAsync(UserCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var createdUser = await userService.CreateAsync(mapper.Map<User>(createModel));
        return mapper.Map<UserViewModel>(createdUser);
    }

    public async ValueTask<UserViewModel> PutAsync(long id, UserUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var updatedUser = await userService.UpdateAsync(id, mapper.Map<User>(updateModel));
        return mapper.Map<UserViewModel>(updatedUser);
    }

    public async ValueTask<UserViewModel> ChangePasswordAsync(UserChangePasswordModel changePasswordModel)
    {
        await changePasswordValidator.EnsureValidatedAsync(changePasswordModel);
        var user = await userService
            .ChangePasswordAsync(changePasswordModel.Phone, changePasswordModel.OldPassword, changePasswordModel.NewPassword);
        return mapper.Map<UserViewModel>(user);
    }
}