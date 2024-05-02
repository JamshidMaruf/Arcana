using Arcana.Domain.Entities.Commons;
using Arcana.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Arcana.Service.Services.Assets;

public interface IAssetService
{
    ValueTask<Asset> UploadAsync(IFormFile file, FileType type);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Asset> GetByIdAsync(long id);
}