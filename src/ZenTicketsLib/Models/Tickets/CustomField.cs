using System.Text.Json.Serialization;
using ZenTicketsLib.Converters;

namespace ZenTicketsLib.Models.Tickets;

[JsonConverter(typeof(CustomFieldConverter))]
public class CustomField
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    public string? Value { get; set; }
    public List<string>? Values { get; set; } = new();
    public TicketField? Details { get; set; }
}