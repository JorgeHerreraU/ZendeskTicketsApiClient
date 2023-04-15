using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Metrics;

public record Policy
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = default!;
}