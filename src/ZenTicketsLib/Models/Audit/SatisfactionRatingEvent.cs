using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record SatisfactionRatingEvent : AuditEvent
{
    [JsonPropertyName("score")]
    public string Score { get; set; } = default!;

    [JsonPropertyName("assignee_id")]
    public long AssigneeId { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; } = default!;
}