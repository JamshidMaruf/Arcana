using Arcana.Service.Configurations;
using Arcana.WebApi.Models.Students;

namespace Arcana.WebApi.ApiServices.Students;

public interface IStudentApiService
{
    ValueTask<StudentViewModel> PostAsync(StudentCreateModel createModel);
    ValueTask<StudentViewModel> PutAsync(long id, StudentUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<StudentViewModel> GetAsync(long id);
    ValueTask<IEnumerable<StudentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<StudentViewModel> UploadPictureAsync(long id, IFormFile picture);
    ValueTask<StudentViewModel> DeletePictureAsync(long id);
}
