using System.Text.Json;
using System.Text.Json.Serialization;
using ZenTicketsLib.Models.Audit;

namespace ZenTicketsLib.Converters;

public class AuditEventConverter : JsonConverter<List<IAuditEvent>>
{
    private readonly Dictionary<AuditType, Type> _typeMappings = new()
    {
        { AuditType.Create, typeof(CreateEvent) },
        { AuditType.Change, typeof(ChangeEvent) },
        { AuditType.Comment, typeof(CommentEvent) },
        { AuditType.CommentRedactionEvent, typeof(CommentRedactionEvent) },
        { AuditType.AttachmentRedactionEvent, typeof(AttachmentRedactionEvent) },
        { AuditType.VoiceComment, typeof(VoiceCommentEvent) },
        { AuditType.CommentPrivacyChange, typeof(CommentPrivacyChangeEvent) },
        { AuditType.Notification, typeof(NotificationEvent) },
        { AuditType.NotificationWithCcs, typeof(NotificationWithCCsEvent) },
        { AuditType.Cc, typeof(CCEvent) },
        { AuditType.FollowerNotificationEvent, typeof(FollowerNotificationEvent) },
        { AuditType.FollowersChange, typeof(FollowerChangeEvent) },
        { AuditType.EmailCcChange, typeof(EmailCCChangeEvent) },
        { AuditType.SatisfactionRating, typeof(SatisfactionRatingEvent) },
        { AuditType.TicketSharingEvent, typeof(TicketSharingEvent) },
        { AuditType.OrganizationActivity, typeof(OrganizationActivityEvent) },
        { AuditType.Error, typeof(ErrorEvent) },
        { AuditType.Tweet, typeof(TweetEvent) },
        { AuditType.FacebookEvent, typeof(FacebookEvent) },
        { AuditType.FacebookComment, typeof(FacebookCommentEvent) },
        { AuditType.External, typeof(ExternalEvent) },
        { AuditType.LogMeInTranscript, typeof(LogMeInTranscriptEvent) },
        { AuditType.Push, typeof(PushEvent) }
    };

    public override List<IAuditEvent> Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException();

        var result = new List<IAuditEvent>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray) return result;

            using (var jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                var root = jsonDocument.RootElement;

                var hasTypeProperty = root.TryGetProperty("type", out var typeElement);

                var isAuditType = Enum.TryParse(typeElement.GetString(), out AuditType type);

                if (!hasTypeProperty || !isAuditType) continue;

                var json = JsonSerializer.Deserialize(root.GetRawText(), _typeMappings[type], options);

                if (json is IAuditEvent auditEvent) result.Add(auditEvent);
            }
        }

        throw new JsonException("Expected end of array.");
    }

    public override void Write(Utf8JsonWriter writer, List<IAuditEvent> value, JsonSerializerOptions options)
    {
        if (writer == null) throw new ArgumentNullException(nameof(writer));
        if (value == null) throw new ArgumentNullException(nameof(value));

        writer.WriteStartArray();

        foreach (var auditEvent in value)
        {
            var targetType = _typeMappings[auditEvent.Type];
            JsonSerializer.Serialize(writer, auditEvent, targetType, options);
        }

        writer.WriteEndArray();
    }
}