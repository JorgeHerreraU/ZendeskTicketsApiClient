using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record ErrorEvent : AuditEvent
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = default!;
}