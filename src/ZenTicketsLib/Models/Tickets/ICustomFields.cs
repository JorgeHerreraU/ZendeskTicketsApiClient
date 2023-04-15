namespace ZenTicketsLib.Models.Tickets;

public interface ICustomFields : IList<CustomField>
{
    string? this[long id] { get; set; }
    List<string>? GetValues(long id);
    void SetValues(long id, List<string> values);
}