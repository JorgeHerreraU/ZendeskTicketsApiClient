using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.SharingAgreements;

public record SharingAgreement
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("partner_name")]
    public string PartnerName { get; set; } = default!;

    [JsonPropertyName("remote_subdomain")]
    public string RemoteSubdomain { get; set; } = default!;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyName("status")]
    public SharingAgreementStatus SharingAgreementStatus { get; set; } = default!;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyName("type")]
    public SharingAgreementType SharingAgreementType { get; set; } = default!;
}