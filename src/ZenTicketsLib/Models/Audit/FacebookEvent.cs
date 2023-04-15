using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record FacebookEvent : AuditEvent
{
    [JsonPropertyName("communication")]
    public int Communication { get; set; }

    [JsonPropertyName("ticket_via")]
    public string TicketVia { get; set; } = default!;

    [JsonPropertyName("body")]
    public string Body { get; set; } = default!;
}