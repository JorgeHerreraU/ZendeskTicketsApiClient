using System.Text.Json.Serialization;
using ZenTicketsLib.Models;
using ZenTicketsLib.Models.Audit;
using ZenTicketsLib.Models.Brands;
using ZenTicketsLib.Models.Groups;
using ZenTicketsLib.Models.Metrics;
using ZenTicketsLib.Models.Organizations;
using ZenTicketsLib.Models.SharingAgreements;
using ZenTicketsLib.Models.TicketForms;
using ZenTicketsLib.Models.Tickets;
using ZenTicketsLib.Models.Users;

namespace ZenTicketsLib.Responses;

public record SearchResponse
{
    [JsonPropertyName("results")]
    public IEnumerable<Ticket> Tickets { get; set; } = default!;

    [JsonPropertyName("users")]
    public IEnumerable<User> Users { get; set; } = default!;

    [JsonPropertyName("groups")]
    public IEnumerable<Group> Groups { get; set; } = default!;

    [JsonPropertyName("organizations")]
    public IEnumerable<Organization> Organizations { get; set; } = default!;

    [JsonPropertyName("last_audits")]
    public IEnumerable<AuditEvent> LastAudits { get; set; } = default!;

    [JsonPropertyName("metric_sets")]
    public IEnumerable<MetricSet> MetricSets { get; set; } = default!;

    [JsonPropertyName("brands")]
    public IEnumerable<Brand> Brands { get; set; } = default!;

    [JsonPropertyName("sharing_agreements")]
    public IEnumerable<SharingAgreement> SharingAgreements { get; set; } = default!;

    [JsonPropertyName("ticket_forms")]
    public IEnumerable<TicketForm> TicketForms { get; set; } = default!;

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; } = new();

    [JsonPropertyName("links")]
    public Links Links { get; set; } = new();
}