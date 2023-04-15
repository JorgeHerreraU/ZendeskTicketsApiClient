using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record EmailCCChangeEvent : AuditEvent
{
    [JsonPropertyName("previous_email_ccs")]
    public string[] PreviousEmailCCs { get; set; } = default!;

    [JsonPropertyName("current_email_ccs")]
    public string[] CurrentEmailCCs { get; set; } = default!;
}