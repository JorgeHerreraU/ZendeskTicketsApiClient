using System.Runtime.Serialization;

namespace ZenTicketsLib.Models.Tickets;

public enum TicketRestriction
{
    [EnumMember(Value = "organization")]
    Organization,

    [EnumMember(Value = "groups")]
    Groups,

    [EnumMember(Value = "assigned")]
    Assigned,

    [EnumMember(Value = "requested")]
    Requested
}