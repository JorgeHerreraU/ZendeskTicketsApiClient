using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Organizations;

public record Organization
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("details")]
    public string Details { get; set; } = default!;

    [JsonPropertyName("notes")]
    public string Notes { get; set; } = default!;

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("due_at")]
    public DateTime? Due { get; set; }

    [JsonPropertyName("organization_fields")]
    public Dictionary<object, object> CustomFields { get; set; } = new();

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = default!;

    [JsonPropertyName("external_id")]
    public string ExternalId { get; set; } = default!;

    [JsonPropertyName("domain_names")]
    public List<string> DomainNames { get; set; } = new();

    [JsonIgnore]
    [JsonPropertyName("shared_tickets")]
    public bool SharedTickets { get; set; }

    [JsonIgnore]
    [JsonPropertyName("shared_comments")]
    public bool SharedComments { get; set; }

    [JsonIgnore]
    public Uri Url { get; set; } = default!;

    [JsonIgnore]
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    [JsonPropertyName("result_type")]
    public string ResultType => "organization";
}