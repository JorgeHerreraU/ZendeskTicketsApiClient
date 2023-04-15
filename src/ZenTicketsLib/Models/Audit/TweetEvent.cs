using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record TweetEvent : AuditEvent
{
    [JsonPropertyName("direct_message")]
    public bool DirectMessage { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; } = default!;

    [JsonPropertyName("recipients")]
    public long[] Recipients { get; set; } = default!;
}