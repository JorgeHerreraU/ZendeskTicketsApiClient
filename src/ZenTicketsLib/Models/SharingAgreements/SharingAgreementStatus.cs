using System.Runtime.Serialization;

namespace ZenTicketsLib.Models.SharingAgreements;

public enum SharingAgreementStatus
{
    [EnumMember(Value = "accepted")]
    Accepted,

    [EnumMember(Value = "declined")]
    Declined,

    [EnumMember(Value = "pending")]
    Pending,

    [EnumMember(Value = "inactive")]
    Inactive,

    [EnumMember(Value = "failed")]
    Failed,

    [EnumMember(Value = "ssl_error")]
    SslError,

    [EnumMember(Value = "configuration_error")]
    ConfigurationError
}