using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Slas;

public record PolicyMetric
{
    [JsonPropertyName("breach_at")]
    public DateTime? BreachAt { get; set; }

    [JsonPropertyName("stage")]
    public string Stage { get; set; } = default!;

    [JsonPropertyName("metric")]
    public string Metric { get; set; } = default!;

    [JsonPropertyName("days")]
    public int Days { get; set; }
}