using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models;

public record Links
{
    [JsonPropertyName("prev")]
    public string Prev { get; set; } = default!;

    [JsonPropertyName("next")]
    public string Next { get; set; } = default!;
}