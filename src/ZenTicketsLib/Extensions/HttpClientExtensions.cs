using System.Net;
using System.Net.Http.Json;
using ZenTicketsLib.Exceptions;

namespace ZenTicketsLib.Extensions;

public static class HttpClientExtensions
{
    private static async Task ThrowException(
        this HttpResponseMessage response,
        HttpStatusCode? expected = null)
    {
        await response.ThrowException(expected.HasValue ? new[] { expected.Value } : null);
    }

    private static async Task ThrowException(
        this HttpResponseMessage response,
        HttpStatusCode[]? expected = null)
    {
        var builder = new ZendeskRequestExceptionBuilder()
            .WithResponse(response);

        if (expected != null)
            builder.WithExpectedHttpStatus(expected);

        throw await builder.Build();
    }

    internal static async Task<HttpResponseMessage> GuardResponse(
        this Task<HttpResponseMessage> response,
        HttpStatusCode? expected = null)
    {
        return await response.Bind(async responseMessage =>
        {
            if (!responseMessage.IsSuccessStatusCode)
                await responseMessage.ThrowException(expected);
            return responseMessage;
        });
    }

    internal static async Task<T> ReadContentAsAsync<T>(this Task<HttpResponseMessage> response)
    {
        return await response.Bind(r =>
                   r.Content.ReadFromJsonAsync<T>()) ??
               throw new NullReferenceException($"{typeof(T).Name} is null");
    }

    internal static async Task<IEnumerable<TResponse>> GetResourceAsync<T, TResponse>(this Task<T> request,
        Func<T, IEnumerable<TResponse>> selector)
    {
        var result = await request;
        return selector(result);
    }

    private static async Task<TOut> Bind<TIn, TOut>(this Task<TIn> task,
        Func<TIn, Task<TOut>> func)
    {
        return await func(await task);
    }
}