using System.Text.Json.Serialization;
using ZenTicketsLib.Converters;

namespace ZenTicketsLib.Models.Audit;

[JsonConverter(typeof(AuditTypeConverter))]
public enum AuditType
{
    Create,
    Change,
    Comment,
    CommentRedactionEvent,
    AttachmentRedactionEvent,
    VoiceComment,
    CommentPrivacyChange,
    Notification,
    NotificationWithCcs,
    Cc,
    FollowerNotificationEvent,
    FollowersChange,
    EmailCcChange,
    SatisfactionRating,
    TicketSharingEvent,
    OrganizationActivity,
    Error,
    Tweet,
    FacebookEvent,
    FacebookComment,
    External,
    LogMeInTranscript,
    Push
}