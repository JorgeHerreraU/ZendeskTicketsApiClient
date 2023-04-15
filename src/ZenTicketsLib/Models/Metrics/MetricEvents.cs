namespace ZenTicketsLib.Models.Metrics;

public record MetricEvents
{
    public List<ResolutionTime> ResolutionTime { get; set; } = new();
    public List<PeriodicUpdateTime> PeriodicUpdateTime { get; set; } = new();
    public List<RequesterWaitTime> RequesterWaitTime { get; set; } = new();
    public List<AgentWorkTime> AgentWorkTime { get; set; } = new();
    public List<PausableUpdateTime> PausableUpdateTime { get; set; } = new();
    public List<ReplyTime> ReplyTime { get; set; } = new();
}