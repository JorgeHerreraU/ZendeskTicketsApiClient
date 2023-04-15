using System.Text.Json;
using System.Text.Json.Serialization;
using ZenTicketsLib.Models.Users;

namespace ZenTicketsLib.Converters;

public class RoleConverter : JsonConverter<UserRole>
{
    public override UserRole Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var enumString = reader.GetString();
        if (enumString == null) return UserRole.EndUser;
        var roleMap = GetRoleMap();
        if (roleMap.TryGetValue(enumString, out var role)) return role;
        throw new JsonException($"Unknown enum value '{enumString}'");
    }

    public override void Write(Utf8JsonWriter writer, UserRole value, JsonSerializerOptions options)
    {
        var roleExists = CreateRoleMap().TryGetValue(value, out var role);
        if (roleExists) writer.WriteStringValue(role);
        else writer.WriteNullValue();
    }

    private static Dictionary<string, UserRole> GetRoleMap()
    {
        return new Dictionary<string, UserRole>(StringComparer.OrdinalIgnoreCase)
        {
            { "end-user", UserRole.EndUser },
            { "agent", UserRole.Agent },
            { "admin", UserRole.Admin }
        };
    }

    private static Dictionary<UserRole, string> CreateRoleMap()
    {
        return new Dictionary<UserRole, string>
        {
            { UserRole.EndUser, "end-user" },
            { UserRole.Agent, "agent" },
            { UserRole.Admin, "admin" }
        };
    }
}