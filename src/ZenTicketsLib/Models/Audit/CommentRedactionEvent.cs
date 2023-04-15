using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record CommentRedactionEvent : AuditEvent
{
    [JsonPropertyName("comment_id")]
    public long CommentId { get; set; }
}