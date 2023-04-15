using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record CommentPrivacyChangeEvent : AuditEvent
{
    [JsonPropertyName("comment_id")]
    public long CommentId { get; set; }

    [JsonPropertyName("public")]
    public bool Public { get; set; }
}