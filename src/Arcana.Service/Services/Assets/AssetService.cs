using Arcana.Service.Helpers;
using Arcana.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Arcana.DataAccess.UnitOfWorks;
using Arcana.Service.Configurations;
using Arcana.Domain.Entities.Commons;

namespace Arcana.Service.Services.Assets;

public class AssetService(IUnitOfWork unitOfWork) : IAssetService
{
    public async ValueTask<Asset> UploadAsync(IFormFile file, FileType type)
    {
        var directoryPath = Path.Combine(EnvironmentHelper.WebRootPath, type.ToString());
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        var fullPath = Path.Combine(directoryPath, file.FileName);

        var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate);
        var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        var bytes = memoryStream.ToArray();
        await fileStream.WriteAsync(bytes);

        var asset = new Asset
        {
            Path = fullPath,
            Name = file.Name,
            CreatedByUserId = HttpContextHelper.UserId
        };

        var createdAsset = await unitOfWork.Assets.InsertAsync(asset);
        await unitOfWork.SaveAsync();

        return createdAsset;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var asset = await unitOfWork.Assets.SelectAsync(asset => asset.Id == id)
            ?? throw new NotFoundException($"Asset is not found with this ID={id}");

        await unitOfWork.Assets.DeleteAsync(asset);
        return true;
    }

    public async ValueTask<Asset> GetByIdAsync(long id)
    {
        var asset = await unitOfWork.Assets.SelectAsync(asset => asset.Id == id)
            ?? throw new NotFoundException($"Asset is not found with this ID={id}");

        return asset;
    }
}