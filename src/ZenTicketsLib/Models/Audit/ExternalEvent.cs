using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record ExternalEvent : AuditEvent
{
    [JsonPropertyName("resource")]
    public string Resource { get; set; } = default!;

    [JsonPropertyName("body")]
    public string Body { get; set; } = default!;
}