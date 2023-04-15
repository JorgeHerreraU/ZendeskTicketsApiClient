namespace ZenTicketsLib.Models.Metrics;

public record AgentWaitTimeInMinutes
{
    public int? Calendar { get; set; }
    public int? Business { get; set; }
}