using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Brands;

public record Brand
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = default!;

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("brand_url")]
    public string BrandUrl { get; set; } = default!;

    [JsonPropertyName("subdomain")]
    public string Subdomain { get; set; } = default!;

    [JsonPropertyName("host_mapping")]
    public string HostMapping { get; set; } = default!;

    [JsonPropertyName("has_help_center")]
    public bool HasHelpCenter { get; set; }

    [JsonPropertyName("help_center_state")]
    public string HelpCenterState { get; set; } = default!;

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("default")]
    public bool Default { get; set; }

    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }

    [JsonPropertyName("logo")]
    public object Logo { get; set; } = default!;

    [JsonPropertyName("ticket_form_ids")]
    public List<long> TicketFormIds { get; set; } = new();

    [JsonPropertyName("signature_template")]
    public string SignatureTemplate { get; set; } = default!;

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}