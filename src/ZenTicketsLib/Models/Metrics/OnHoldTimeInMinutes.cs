namespace ZenTicketsLib.Models.Metrics;

public record OnHoldTimeInMinutes
{
    public int? Calendar { get; set; }
    public int? Business { get; set; }
}