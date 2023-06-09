﻿using System.Runtime.Serialization;

namespace ZenTicketsLib.Models.Tickets;

public enum TicketStatus
{
    [EnumMember(Value = "new")]
    New,

    [EnumMember(Value = "open")]
    Open,

    [EnumMember(Value = "closed")]
    Closed,

    [EnumMember(Value = "pending")]
    Pending,

    [EnumMember(Value = "solved")]
    Solved,

    [EnumMember(Value = "hold")]
    Hold,

    [EnumMember(Value = "deleted")]
    Deleted
}