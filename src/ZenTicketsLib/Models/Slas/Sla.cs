using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Slas;

public record Sla
{
    [JsonPropertyName("policy_metrics")]
    public List<PolicyMetric>? PolicyMetrics { get; set; } = new();
}