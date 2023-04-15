using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record AuditEvent : IAuditEvent
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("type")]
    public AuditType Type { get; set; }
}