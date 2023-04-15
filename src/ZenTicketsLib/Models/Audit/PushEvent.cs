using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record PushEvent : AuditEvent
{
    [JsonPropertyName("value")]
    public string Value { get; set; } = default!;

    [JsonPropertyName("value_reference")]
    public string ValueReference { get; set; } = default!;
}