using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Tickets;

public record TicketField
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = default!;

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [JsonPropertyName("title")]
    public string Title { get; set; } = default!;

    [JsonPropertyName("raw_title")]
    public string RawTitle { get; set; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = default!;

    [JsonPropertyName("raw_description")]
    public string RawDescription { get; set; } = default!;

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("required")]
    public bool Required { get; set; }

    [JsonPropertyName("collapsed_for_agents")]
    public bool CollapsedForAgents { get; set; }

    [JsonPropertyName("regexp_for_validation")]
    public string RegexpForValidation { get; set; } = default!;

    [JsonPropertyName("title_in_portal")]
    public string TitleInPortal { get; set; } = default!;

    [JsonPropertyName("raw_title_in_portal")]
    public string RawTitleInPortal { get; set; } = default!;

    [JsonPropertyName("visible_in_portal")]
    public bool VisibleInPortal { get; set; }

    [JsonPropertyName("editable_in_portal")]
    public bool EditableInPortal { get; set; }

    [JsonPropertyName("required_in_portal")]
    public bool RequiredInPortal { get; set; }

    [JsonPropertyName("tag")]
    public string Tag { get; set; } = default!;

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("removable")]
    public bool Removable { get; set; }

    [JsonPropertyName("agent_description")]
    public string AgentDescription { get; set; } = default!;
}