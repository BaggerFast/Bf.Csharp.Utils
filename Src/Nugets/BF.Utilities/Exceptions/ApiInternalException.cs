// ReSharper disable UnusedType.Global
namespace BF.Utilities.Exceptions;

public class ApiInternalException : Exception
{
    public required string ErrorDisplayMessage { get; set; } = string.Empty;
    public string ErrorInternalMessage { get; set; } = string.Empty;
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
}