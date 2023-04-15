using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ZenTicketsLib.Exceptions;

public class ErrorResponse
{
    public ErrorResponse(string error, string description)
    {
        Error = error;
        Description = description;
    }

    [JsonPropertyName("error")]
    public string Error { get; internal set; }

    [JsonPropertyName("description")]
    public string Description { get; internal set; }

    [JsonPropertyName("details")]
    public JsonObject Details { get; internal set; } = new();
}