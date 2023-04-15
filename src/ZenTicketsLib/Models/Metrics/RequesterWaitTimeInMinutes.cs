namespace ZenTicketsLib.Models.Metrics;

public record RequesterWaitTimeInMinutes
{
    public int? Calendar { get; set; }
    public int? Business { get; set; }
}