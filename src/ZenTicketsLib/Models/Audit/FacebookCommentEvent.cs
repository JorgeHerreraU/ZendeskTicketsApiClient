using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record FacebookCommentEvent : AuditEvent
{
    [JsonPropertyName("data")]
    public object? Data { get; set; } = default!;

    [JsonPropertyName("body")]
    public string Body { get; set; } = default!;

    [JsonPropertyName("html_body")]
    public string HtmlBody { get; set; } = default!;

    [JsonPropertyName("public")]
    public bool Public { get; set; }

    [JsonPropertyName("trusted")]
    public bool Trusted { get; set; }

    [JsonPropertyName("author_id")]
    public long AuthorId { get; set; }

    [JsonPropertyName("graph_object_id")]
    public string GraphObjectId { get; set; } = default!;
}