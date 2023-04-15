using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ZenTicketsLib.Models.Tickets;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SatisfactionRatingScore
{
    [EnumMember(Value = "offered")]
    Offered,

    [EnumMember(Value = "unoffered")]
    Unoffered,

    [EnumMember(Value = "good")]
    Good,

    [EnumMember(Value = "bad")]
    Bad
}