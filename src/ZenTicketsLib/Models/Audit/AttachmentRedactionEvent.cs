using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record AttachmentRedactionEvent : AuditEvent
{
    [JsonPropertyName("attachment_id")]
    public long AttachmentId { get; set; }

    [JsonPropertyName("comment_id")]
    public long CommentId { get; set; }
}