using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record VoiceCommentEvent : AuditEvent
{
    [JsonPropertyName("data")]
    public object? Data { get; set; } = default!;

    [JsonPropertyName("formatted_from")]
    public string FormattedFrom { get; set; } = default!;

    [JsonPropertyName("formatted_to")]
    public string FormattedTo { get; set; } = default!;

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

    [JsonPropertyName("transcription_visible")]
    public bool TranscriptionVisible { get; set; }

    [JsonPropertyName("attachments")]
    public Attachment[] Attachments { get; set; } = default!;
}