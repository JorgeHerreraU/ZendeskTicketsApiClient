using System.Runtime.Serialization;

namespace ZenTicketsLib.Models.Users;

public enum UserRole
{
    [EnumMember(Value = "end-user")]
    EndUser,

    [EnumMember(Value = "agent")]
    Agent,

    [EnumMember(Value = "admin")]
    Admin
}