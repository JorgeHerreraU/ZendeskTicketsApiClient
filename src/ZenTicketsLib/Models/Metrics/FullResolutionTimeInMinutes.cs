namespace ZenTicketsLib.Models.Metrics;

public record FullResolutionTimeInMinutes
{
    public int? Calendar { get; set; }
    public int? Business { get; set; }
}