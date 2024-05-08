using Arcana.Service.Configurations;

namespace Arcana.WebApi.Models.Assets
{
    public class AssetCreateModel
    {
        public IFormFile File { get; set; }
        public FileType FileType { get; set; }
    }
}
