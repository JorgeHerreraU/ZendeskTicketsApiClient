using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public class Attachment : Thumbnail
{
    [JsonPropertyName("thumbnails")]
    public List<Thumbnail> Thumbnails { get; set; } = new();
}

public class Thumbnail
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = default!;

    [JsonPropertyName("content_url")]
    public string ContentUrl { get; set; } = default!;

    [JsonPropertyName("content_type")]
    public string ContentType { get; set; } = default!;

    [JsonPropertyName("size")]
    public long Size { get; set; }
}