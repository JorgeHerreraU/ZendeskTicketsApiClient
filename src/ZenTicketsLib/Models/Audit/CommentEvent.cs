using System.Text.Json.Serialization;
using ZenTicketsLib.Models.Tickets;

namespace ZenTicketsLib.Models.Audit;

public record CommentEvent : AuditEvent
{
    [JsonPropertyName("body")]
    public string Body { get; set; } = default!;

    [JsonPropertyName("html_body")]
    public string HtmlBody { get; set; } = default!;

    [JsonPropertyName("plain_body")]
    public string PlainBody { get; set; } = default!;

    [JsonPropertyName("public")]
    public bool Public { get; set; }

    [JsonPropertyName("author_id")]
    public long AuthorId { get; set; }

    [JsonPropertyName("attachments")]
    public Attachment[] Attachments { get; set; } = default!;

    [JsonPropertyName("via")]
    public Via Via { get; set; } = new();

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}