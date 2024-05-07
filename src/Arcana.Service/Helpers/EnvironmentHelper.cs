namespace Arcana.Service.Helpers;

public class EnvironmentHelper
{
    public static string WebRootPath { get; set; }
    public static string JWTKey { get; set; }
    public static string TokenLifeTimeInHours { get; set; }
    public static string EmailAddress { get; set; }
    public static string EmailPassword { get; set; }
    public static string SmtpHost { get; set; }
    public static string SmtpPort { get; set; }
    public static int PageIndex { get; set; }
    public static int PageSize { get; set; }
}