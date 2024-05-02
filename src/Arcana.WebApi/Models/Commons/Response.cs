namespace Arcana.WebApi.Models.Commons;

public class Response
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}
