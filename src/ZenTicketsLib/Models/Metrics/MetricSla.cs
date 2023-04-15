using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Metrics;

public record MetricSla
{
    [JsonPropertyName("target")]
    public int? Target { get; set; }

    [JsonPropertyName("business_hours")]
    public bool? BusinessHours { get; set; }

    [JsonPropertyName("policy")]
    public Policy Policy { get; set; } = new();
}