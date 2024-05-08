using Arcana.Service.Configurations;
using Arcana.WebApi.Models.InstructorStars;

namespace Arcana.WebApi.ApiServices.InstructorsStars;

public interface IInstructorStarApiService
{
    ValueTask<InstructorStarViewModel> PostAsync(InstructorStarCreateModel createModel);
    ValueTask<InstructorStarViewModel> PutAsync(long id, InstructorStarUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<InstructorStarViewModel> GetAsync(long id);
    ValueTask<IEnumerable<InstructorStarViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}