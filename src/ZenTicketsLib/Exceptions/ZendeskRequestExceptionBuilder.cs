using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace ZenTicketsLib.Exceptions;

internal class ZendeskRequestExceptionBuilder
{
    private static readonly int[] DoNotBuildErrorModelResponseCodes = { 429 };
    private List<HttpStatusCode>? _expectedStatusCode;
    private HttpResponseMessage? _response;

    public ZendeskRequestExceptionBuilder WithResponse(HttpResponseMessage response)
    {
        _response = response;
        return this;
    }

    public void WithExpectedHttpStatus(params HttpStatusCode[]? status)
    {
        if (status == null) return;
        if (_expectedStatusCode != null)
            _expectedStatusCode.AddRange(status);
        else
            _expectedStatusCode = new List<HttpStatusCode>(status);
    }

    public async Task<ZendeskRequestException> Build()
    {
        var message = new StringBuilder();
        ErrorResponse? error = null;

        if (_response != null &&
            (int)_response.StatusCode <= 499 &&
            !DoNotBuildErrorModelResponseCodes.Contains((int)_response.StatusCode))
        {
            error = await _response.Content.ReadFromJsonAsync<ErrorResponse>();

            if (error is { Error: not null, Description: not null })
                message.AppendLine($"{error.Error}: {error.Description}.");
        }

        if (_expectedStatusCode != null)
        {
            if (_expectedStatusCode.Count > 1)
            {
                var expectedCodes = string.Join(", ", _expectedStatusCode.Select(x => $"({(int)x} {x})"));
                message.AppendLine(_response != null
                    ? $"Status code retrieved was {_response.StatusCode} and not in {expectedCodes} as expected."
                    : $"Status code retrieved was not in {expectedCodes} as expected.");
            }
            else
            {
                message.AppendLine(_response != null
                    ? $"Status code retrieved was {_response.StatusCode} and not {_expectedStatusCode[0]}({(int)_expectedStatusCode[0]}) as expected."
                    : $"Status code retrieved was not {_expectedStatusCode[0]} as expected.");
            }
        }
        else if (_response != null)
        {
            message.AppendLine($"Status code retrieved was {_response.StatusCode}.");
        }

        return new ZendeskRequestException(message.ToString(), error, _response);
    }
}