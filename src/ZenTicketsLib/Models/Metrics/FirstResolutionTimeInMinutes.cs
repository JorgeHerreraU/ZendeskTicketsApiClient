namespace ZenTicketsLib.Models.Metrics;

public record FirstResolutionTimeInMinutes
{
    public int? Calendar { get; set; }
    public int? Business { get; set; }
}