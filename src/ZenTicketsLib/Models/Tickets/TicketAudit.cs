using System.Text.Json.Serialization;
using ZenTicketsLib.Converters;
using ZenTicketsLib.Models.Audit;

namespace ZenTicketsLib.Models.Tickets;

public record TicketAudit
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("ticket_id")]
    public long TicketId { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("author_id")]
    public long AuthorId { get; set; }

    [JsonPropertyName("events")]
    [JsonConverter(typeof(AuditEventConverter))]
    public List<IAuditEvent> Events { get; set; } = new();

    [JsonIgnore]
    private Lazy<IEnumerable<CreateEvent>> LazyCreateEvents => new(() => Events.OfType<CreateEvent>());

    [JsonIgnore]
    public IEnumerable<CreateEvent> CreateEvents => LazyCreateEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<ChangeEvent>> LazyChangeEvents => new(() => Events.OfType<ChangeEvent>());

    [JsonIgnore]
    public IEnumerable<ChangeEvent> ChangeEvents => LazyChangeEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<CommentEvent>> LazyCommentEvents => new(() => Events.OfType<CommentEvent>());

    [JsonIgnore]
    public IEnumerable<CommentEvent> CommentEvents => LazyCommentEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<CommentRedactionEvent>> LazyCommentRedactionEvents =>
        new(() => Events.OfType<CommentRedactionEvent>());

    [JsonIgnore]
    public IEnumerable<CommentRedactionEvent> CommentRedactionEvents => LazyCommentRedactionEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<AttachmentRedactionEvent>> LazyAttachmentRedactionEvents =>
        new(() => Events.OfType<AttachmentRedactionEvent>());

    [JsonIgnore]
    public IEnumerable<AttachmentRedactionEvent> AttachmentRedactionEvents => LazyAttachmentRedactionEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<VoiceCommentEvent>> LazyVoiceCommentEvents =>
        new(() => Events.OfType<VoiceCommentEvent>());

    [JsonIgnore]
    public IEnumerable<VoiceCommentEvent> VoiceCommentEvents => LazyVoiceCommentEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<CommentPrivacyChangeEvent>> LazyCommentPrivacyChangeEvents =>
        new(() => Events.OfType<CommentPrivacyChangeEvent>());

    [JsonIgnore]
    public IEnumerable<CommentPrivacyChangeEvent> CommentPrivacyChangeEvents => LazyCommentPrivacyChangeEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<NotificationEvent>> LazyNotificationEvents =>
        new(() => Events.OfType<NotificationEvent>());

    [JsonIgnore]
    public IEnumerable<NotificationEvent> NotificationEvents => LazyNotificationEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<NotificationWithCCsEvent>> LazyNotificationWithCCEvents =>
        new(() => Events.OfType<NotificationWithCCsEvent>());

    [JsonIgnore]
    public IEnumerable<NotificationWithCCsEvent> NotificationWithCCsEvents => LazyNotificationWithCCEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<CCEvent>> LazyCCEvents => new(() => Events.OfType<CCEvent>());

    [JsonIgnore]
    public IEnumerable<CCEvent> CcEvents => LazyCCEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<FollowerNotificationEvent>> LazyFollowerNotificationEvents =>
        new(() => Events.OfType<FollowerNotificationEvent>());

    [JsonIgnore]
    public IEnumerable<FollowerNotificationEvent> FollowerNotificationEvents => LazyFollowerNotificationEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<FollowerChangeEvent>> LazyFollowerChangeEvents =>
        new(() => Events.OfType<FollowerChangeEvent>());

    [JsonIgnore]
    public IEnumerable<FollowerChangeEvent> FollowerChangeEvents => LazyFollowerChangeEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<EmailCCChangeEvent>> LazyEmailCcChangeEvents =>
        new(() => Events.OfType<EmailCCChangeEvent>());

    [JsonIgnore]
    public IEnumerable<EmailCCChangeEvent> EmailCcChangeEvents => LazyEmailCcChangeEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<SatisfactionRatingEvent>> LazySatisfactionRatingEvents =>
        new(() => Events.OfType<SatisfactionRatingEvent>());

    [JsonIgnore]
    public IEnumerable<SatisfactionRatingEvent> SatisfactionRatingEvents => LazySatisfactionRatingEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<TicketSharingEvent>> LazyTicketSharingEvents =>
        new(() => Events.OfType<TicketSharingEvent>());

    [JsonIgnore]
    public IEnumerable<TicketSharingEvent> TicketSharingEvents => Events.OfType<TicketSharingEvent>();

    [JsonIgnore]
    private Lazy<IEnumerable<OrganizationActivityEvent>> LazyOrganizationActivityEvents =>
        new(() => Events.OfType<OrganizationActivityEvent>());

    [JsonIgnore]
    public IEnumerable<OrganizationActivityEvent> OrganizationActivityEvents => LazyOrganizationActivityEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<ErrorEvent>> LazyErrorEvents => new(() => Events.OfType<ErrorEvent>());

    [JsonIgnore]
    public IEnumerable<ErrorEvent> ErrorEvents => LazyErrorEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<TweetEvent>> LazyTweetEvents => new(() => Events.OfType<TweetEvent>());

    [JsonIgnore]
    public IEnumerable<TweetEvent> TweetEvents => LazyTweetEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<FacebookEvent>> LazyFacebookEvents => new(() => Events.OfType<FacebookEvent>());

    [JsonIgnore]
    public IEnumerable<FacebookEvent> FacebookEvents => LazyFacebookEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<FacebookCommentEvent>> LazyFacebookCommentEvents =>
        new(() => Events.OfType<FacebookCommentEvent>());

    [JsonIgnore]
    public IEnumerable<FacebookCommentEvent> FacebookCommentEvents => LazyFacebookCommentEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<ExternalEvent>> LazyExternalEvents => new(() => Events.OfType<ExternalEvent>());

    [JsonIgnore]
    public IEnumerable<ExternalEvent> ExternalEvents => LazyExternalEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<LogMeInTranscriptEvent>> LazyLogMeInTranscriptEvents =>
        new(() => Events.OfType<LogMeInTranscriptEvent>());

    [JsonIgnore]
    public IEnumerable<LogMeInTranscriptEvent> LogMeInTranscriptEvents => LazyLogMeInTranscriptEvents.Value;

    [JsonIgnore]
    private Lazy<IEnumerable<PushEvent>> LazyPushEvents => new(() => Events.OfType<PushEvent>());

    [JsonIgnore]
    public IEnumerable<PushEvent> PushEvents => LazyPushEvents.Value;
}