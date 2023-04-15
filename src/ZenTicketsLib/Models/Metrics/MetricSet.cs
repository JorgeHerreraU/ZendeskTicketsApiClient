using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Metrics;

public record MetricSet
{
    public Uri Url { get; set; } = default!;
    public long Id { get; set; }

    [JsonPropertyName("ticket_id")]
    public long TicketId { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("group_stations")]
    public int GroupStations { get; set; }

    [JsonPropertyName("assignee_stations")]
    public int AssigneeStations { get; set; }

    public int Reopens { get; set; }
    public int Replies { get; set; }

    [JsonPropertyName("assignee_updated_at")]
    public DateTime? AssigneeUpdatedAt { get; set; }

    [JsonPropertyName("requester_updated_at")]
    public DateTime? RequesterUpdatedAt { get; set; }

    [JsonPropertyName("status_updated_at")]
    public DateTime? StatusUpdatedAt { get; set; }

    [JsonPropertyName("initially_assigned_at")]
    public DateTime? InitiallyAssignedAt { get; set; }

    [JsonPropertyName("assigned_at")]
    public DateTime? AssignedAt { get; set; }

    [JsonPropertyName("solved_at")]
    public DateTime? SolvedAt { get; set; }

    [JsonPropertyName("latest_comment_added_at")]
    public DateTime? LatestCommentAddedAt { get; set; }

    [JsonPropertyName("reply_time_in_minutes")]
    public ReplyTimeInMinutes ReplyTimeInMinutes { get; set; } = new();

    [JsonPropertyName("first_resolution_time_in_minutes")]
    public FirstResolutionTimeInMinutes FirstResolutionTimeInMinutes { get; set; } = new();

    [JsonPropertyName("full_resolution_time_in_minutes")]
    public FullResolutionTimeInMinutes FullResolutionTimeTnMinutes { get; set; } = new();

    [JsonPropertyName("agent_wait_time_in_minutes")]
    public AgentWaitTimeInMinutes AgentWaitTimeInMinutes { get; set; } = new();

    [JsonPropertyName("requester_wait_time_in_minutes")]
    public RequesterWaitTimeInMinutes RequesterWaitTimeInMinutes { get; set; } = new();

    [JsonPropertyName("on_hold_time_in_minutes")]
    public OnHoldTimeInMinutes OnHoldTimeInMinutes { get; set; } = new();
}