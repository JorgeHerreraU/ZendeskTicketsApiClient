using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Tickets;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TicketType
{
    [EnumMember(Value = "task")]
    Task,

    [EnumMember(Value = "incident")]
    Incident,

    [EnumMember(Value = "problem")]
    Problem,

    [EnumMember(Value = "question")]
    Question
}