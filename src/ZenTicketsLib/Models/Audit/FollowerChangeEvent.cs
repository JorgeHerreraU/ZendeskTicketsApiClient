using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record FollowerChangeEvent : AuditEvent
{
    [JsonPropertyName("previous_followers")]
    public string[] PreviousFollowers { get; set; } = default!;

    [JsonPropertyName("current_followers")]
    public string[] CurrentFollowers { get; set; } = default!;
}