using Arcana.Domain.Entities.Instructors;
using Arcana.Service.Configurations;
using Arcana.WebApi.Models.Instructors;

namespace Arcana.WebApi.ApiServices.Instructors;

public interface IInstructorApiService
{
    ValueTask<InstructorViewModel> PostAsync(InstructorCreateModel createModel);
    ValueTask<InstructorViewModel> PutAsync(long id, InstructorUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<InstructorViewModel> GetAsync(long id);
    ValueTask<IEnumerable<InstructorViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<InstructorViewModel> UploadPictureAsync(long id, IFormFile picture);
    ValueTask<InstructorViewModel> DeletePictureAsync(long id);
}