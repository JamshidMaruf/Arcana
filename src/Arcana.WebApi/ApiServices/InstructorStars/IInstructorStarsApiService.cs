using Arcana.Service.Configurations;
using Arcana.WebApi.Models.InstructorStars;

namespace Arcana.WebApi.ApiServices.InstructorStars;

public interface IInsturctorStarsApiService
{
    ValueTask<InstructorStarsViewModel> PostAsync(InstructorStarsCreateModel createModel);
    ValueTask<InstructorStarsViewModel> PutAsync(long id, InstructorStarsUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<InstructorStarsViewModel> GetAsync(long id);
    ValueTask<IEnumerable<InstructorStarsViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}
