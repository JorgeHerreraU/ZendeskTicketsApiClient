using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Tickets;

public record Dates
{
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
}