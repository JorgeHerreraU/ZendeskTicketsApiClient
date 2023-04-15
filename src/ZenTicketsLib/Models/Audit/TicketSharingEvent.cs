using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record TicketSharingEvent : AuditEvent
{
    [JsonPropertyName("agreement_id")]
    public long AgreementId { get; set; }

    [JsonPropertyName("action")]
    public string Action { get; set; } = default!;
}