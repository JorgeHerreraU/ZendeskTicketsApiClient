using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record LogMeInTranscriptEvent : AuditEvent
{
    [JsonPropertyName("body")]
    public string Body { get; set; } = default!;
}