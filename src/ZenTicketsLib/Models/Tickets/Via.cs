using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Tickets;

public record Via
{
    [JsonPropertyName("channel")]
    public string Channel { get; set; } = default!;

    [JsonPropertyName("source")]
    public Source Source { get; set; } = default!;
}

public record Source
{
    [JsonPropertyName("to")]
    public dynamic To { get; set; } = default!;

    [JsonPropertyName("from")]
    public dynamic From { get; set; } = default!;

    [JsonPropertyName("rel")]
    public string Rel { get; set; } = default!;
}