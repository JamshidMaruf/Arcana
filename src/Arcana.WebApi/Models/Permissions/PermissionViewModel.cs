namespace Arcana.WebApi.Models.Permissions;

public class PermissionViewModel
{
    public long Id { get; set; }
    public string Action { get; set; }
    public string Controller { get; set; }
}
