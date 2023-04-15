using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Audit;

public record ChangeEvent : AuditEvent
{
    [JsonPropertyName("field_name")]
    public string FieldName { get; set; } = default!;

    [JsonPropertyName("value")]
    public object Value { get; set; } = default!;

    [JsonPropertyName("previous_value")]
    public object? PreviousValue { get; set; } = default!;
}