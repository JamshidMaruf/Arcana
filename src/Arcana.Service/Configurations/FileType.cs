using Arcana.Service.Helpers;
using Newtonsoft.Json;

namespace Arcana.Service.Configurations;

[JsonConverter(typeof(EnumStringConverter))]
public enum FileType
{
    Pictures = 1,
    Videos,
    Audios
}