using System.Text.Json.Serialization;
using ZenTicketsLib.Models.Tickets;

namespace ZenTicketsLib.Models.Audit;

public record FollowerNotificationEvent : AuditEvent
{
    [JsonPropertyName("subject")]
    public string Subject { get; set; } = default!;

    [JsonPropertyName("body")]
    public string Body { get; set; } = default!;

    [JsonPropertyName("recipients")]
    public long[] Recipients { get; set; } = default!;

    [JsonPropertyName("via")]
    public Via Via { get; set; } = new();
}