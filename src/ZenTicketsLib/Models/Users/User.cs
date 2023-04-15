using System.Text.Json.Serialization;
using ZenTicketsLib.Converters;
using ZenTicketsLib.Models.Tickets;

namespace ZenTicketsLib.Models.Users;

public record User
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("alias")]
    public string Alias { get; set; } = default!;

    [JsonPropertyName("chat_only")]
    public bool ChatOnly { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("custom_role_id")]
    public long? CustomRoleId { get; set; }

    [JsonPropertyName("details")]
    public string Details { get; set; } = default!;

    [JsonPropertyName("external_id")]
    public string ExternalId { get; set; } = default!;

    [JsonPropertyName("last_login_at")]
    public DateTime? LastLoginAt { get; set; }

    [JsonPropertyName("locale")]
    public string Locale { get; set; } = default!;

    [JsonPropertyName("locale_id")]
    public long? LocaleId { get; set; }

    [JsonPropertyName("moderator")]
    public bool Moderator { get; set; }

    [JsonPropertyName("notes")]
    public string Notes { get; set; } = default!;

    [JsonPropertyName("only_private_comments")]
    public bool OnlyPrivateComments { get; set; }

    [JsonPropertyName("organization_id")]
    public long? OrganizationId { get; set; }

    [JsonPropertyName("default_group_id")]
    public long? DefaultGroupId { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; } = default!;

    [JsonPropertyName("restricted_agent")]
    public bool RestrictedAgent { get; set; }

    [JsonPropertyName("role")]
    [JsonConverter(typeof(RoleConverter))]
    public UserRole Role { get; set; }

    [JsonPropertyName("shared")]
    public bool Shared { get; set; }

    [JsonPropertyName("shared_agent")]
    public bool SharedAgent { get; set; }

    [JsonPropertyName("signature")]
    public string Signature { get; set; } = default!;

    [JsonPropertyName("suspended")]
    public bool Suspended { get; set; }

    [JsonPropertyName("tags")]
    public IReadOnlyList<string> Tags { get; set; } = default!;

    [JsonPropertyName("ticket_restriction")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TicketRestriction? TicketRestriction { get; set; }

    [JsonPropertyName("time_zone")]
    public string TimeZone { get; set; } = default!;

    [JsonPropertyName("two_factor_auth_enabled")]
    public bool? TwoFactorAuthEnabled { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; } = default!;

    [JsonPropertyName("user_fields")]
    [JsonConverter(typeof(DictionaryObjectTypeConverter))]
    public IReadOnlyDictionary<string, object> UserFields { get; set; } = default!;

    [JsonPropertyName("verified")]
    public bool Verified { get; set; }
}