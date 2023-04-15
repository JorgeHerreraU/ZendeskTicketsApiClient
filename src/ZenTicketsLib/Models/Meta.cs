using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models;

public class Meta
{
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }

    [JsonPropertyName("after_cursor")]
    public string AfterCursor { get; set; } = default!;

    [JsonPropertyName("before_cursor")]
    public string BeforeCursor { get; set; } = default!;
}