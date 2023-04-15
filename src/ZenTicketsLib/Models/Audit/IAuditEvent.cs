using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public interface IAuditEvent
{
    [JsonPropertyName("id")]
    long Id { get; set; }

    [JsonPropertyName("type")]
    AuditType Type { get; set; }
}