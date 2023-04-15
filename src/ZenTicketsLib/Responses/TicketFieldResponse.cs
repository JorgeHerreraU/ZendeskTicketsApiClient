using System.Text.Json.Serialization;
using ZenTicketsLib.Models.Tickets;

namespace ZenTicketsLib.Responses;

public record TicketFieldResponse
{
    [JsonPropertyName("ticket_fields")]
    public List<TicketField> TicketFields { get; set; } = default!;

    [JsonPropertyName("next_page")]
    public string NextPage { get; set; } = default!;

    [JsonPropertyName("previous_page")]
    public string PreviousPage { get; set; } = default!;

    [JsonPropertyName("count")]
    public int Count { get; set; }
}