namespace ZenTicketsLib.Models.Metrics;

public record ReplyTimeInMinutes
{
    public int? Calendar { get; set; }
    public int? Business { get; set; }
}