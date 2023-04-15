namespace ZenTicketsLib.Exceptions;

public class ZendeskRequestException : Exception
{
    public ZendeskRequestException(
        string message,
        ErrorResponse? errorResponse,
        HttpResponseMessage? response)
        : base(message)
    {
        Error = errorResponse;
        Response = response;
    }

    public ErrorResponse? Error { get; }
    public HttpResponseMessage? Response { get; }
}