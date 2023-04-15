using System.Text.Json.Serialization;
using ZenTicketsLib.Converters;
using ZenTicketsLib.Models.Metrics;
using ZenTicketsLib.Models.Slas;

namespace ZenTicketsLib.Models.Tickets;

public record Ticket
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; } = default!;

    [JsonPropertyName("external_id")]
    public string ExternalId { get; set; } = default!;

    [JsonPropertyName("type")]
    public TicketType? Type { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; } = default!;

    [JsonPropertyName("raw_subject")]
    public string RawSubject { get; set; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = default!;

    [JsonPropertyName("priority")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Priority? Priority { get; set; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TicketStatus Status { get; set; } = new();

    [JsonPropertyName("recipient")]
    public string Recipient { get; set; } = default!;

    [JsonPropertyName("requester_id")]
    public long? RequesterId { get; set; }

    [JsonPropertyName("submitter_id")]
    public long? SubmitterId { get; set; }

    [JsonPropertyName("assignee_id")]
    public long? AssigneeId { get; set; }

    [JsonPropertyName("organization_id")]
    public long? OrganizationId { get; set; }

    [JsonPropertyName("group_id")]
    public long? GroupId { get; set; }

    [JsonPropertyName("collaborator_ids")]
    public IReadOnlyList<long> CollaboratorIds { get; set; } = default!;

    [JsonPropertyName("forum_topic_id")]
    public long? ForumTopicId { get; set; }

    [JsonPropertyName("problem_id")]
    public long? ProblemId { get; set; }

    [JsonPropertyName("has_incidents")]
    public bool HasIncidents { get; set; }

    [JsonPropertyName("due_at")]
    public DateTime? Due { get; set; }

    [JsonPropertyName("tags")]
    public IReadOnlyList<string> Tags { get; set; } = default!;

    [JsonPropertyName("via")]
    public Via Via { get; set; } = new();

    [JsonPropertyName("custom_fields")]
    [JsonConverter(typeof(CustomFieldsConverter))]
    public IReadOnlyCustomFields CustomFields { get; set; } = default!;

    [JsonPropertyName("satisfaction_rating")]
    public SatisfactionRating SatisfactionRating { get; set; } = new();

    [JsonPropertyName("sharing_agreement_ids")]
    public IReadOnlyList<long> SharingAgreementIds { get; set; } = default!;

    [JsonPropertyName("followup_ids")]
    public IReadOnlyList<long> FollowupIds { get; set; } = default!;

    [JsonPropertyName("ticket_form_id")]
    public long? FormId { get; set; }

    [JsonPropertyName("brand_id")]
    public long? BrandId { get; set; }

    [JsonPropertyName("allow_channelback")]
    public bool AllowChannelBack { get; set; }

    [JsonPropertyName("is_public")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = new();

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = new();

    [JsonPropertyName("result_type")]
    public string ResultType { get; set; } = default!;

    [JsonPropertyName("metric_set")]
    public MetricSet? MetricSet { get; set; } = new();

    [JsonPropertyName("slas")]
    public Sla? Slas { get; set; } = new();

    [JsonPropertyName("dates")]
    public Dates Dates { get; set; } = new();

    [JsonPropertyName("last_audit")]
    public TicketAudit LastAudit { get; set; } = new();

    [JsonPropertyName("comment_count")]
    public int? CommentCount { get; set; } = default!;

    [JsonPropertyName("incident_counts")]
    public int? IncidentCount { get; set; } = default!;
}