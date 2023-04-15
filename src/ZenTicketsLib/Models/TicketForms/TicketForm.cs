using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.TicketForms;

public record TicketForm
{
    [JsonPropertyName("url")]
    public Uri Url { get; set; } = default!;

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("raw_name")]
    public string RawName { get; set; } = default!;

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = default!;

    [JsonPropertyName("raw_display_name")]
    public string RawDisplayName { get; set; } = default!;

    [JsonPropertyName("end_user_visible")]
    public bool EndUserVisible { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("ticket_field_ids")]
    public List<long> TicketFieldIds { get; set; } = new();

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("default")]
    public bool Default { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("in_all_brands")]
    public bool InAllBrands { get; set; }

    [JsonPropertyName("restricted_brand_ids")]
    public List<int> RestrictedBrandIds { get; set; } = new();

    [JsonPropertyName("end_user_conditions")]
    public List<object> EndUserConditions { get; set; } = new();

    [JsonPropertyName("agent_conditions")]
    public List<object> AgentConditions { get; set; } = new();
}