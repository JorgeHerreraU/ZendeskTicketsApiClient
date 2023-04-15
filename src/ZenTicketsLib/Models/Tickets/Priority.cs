using System.Runtime.Serialization;

namespace ZenTicketsLib.Models.Tickets;

public enum Priority
{
    [EnumMember(Value = "urgent")]
    Urgent,

    [EnumMember(Value = "high")]
    High,

    [EnumMember(Value = "normal")]
    Normal,

    [EnumMember(Value = "low")]
    Low
}