using System.Runtime.Serialization;

namespace ZenTicketsLib.Models.SharingAgreements;

public enum SharingAgreementType
{
    [EnumMember(Value = "inbound")]
    Inbound,

    [EnumMember(Value = "outbound")]
    Outbound
}