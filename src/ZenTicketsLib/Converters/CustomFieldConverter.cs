using System.Buffers.Text;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ZenTicketsLib.Models.Tickets;

namespace ZenTicketsLib.Converters;

public class CustomFieldConverter : JsonConverter<CustomField>
{
    private static readonly Dictionary<string, JsonEncodedText> PropertyNames = new()
    {
        ["url"] = JsonEncodedText.Encode("url"),
        ["id"] = JsonEncodedText.Encode("id"),
        ["type"] = JsonEncodedText.Encode("type"),
        ["title"] = JsonEncodedText.Encode("title"),
        ["raw_title"] = JsonEncodedText.Encode("raw_title"),
        ["description"] = JsonEncodedText.Encode("description"),
        ["raw_description"] = JsonEncodedText.Encode("raw_description"),
        ["position"] = JsonEncodedText.Encode("position"),
        ["active"] = JsonEncodedText.Encode("active"),
        ["required"] = JsonEncodedText.Encode("required"),
        ["collapsed_for_agents"] = JsonEncodedText.Encode("collapsed_for_agents"),
        ["regexp_for_validation"] = JsonEncodedText.Encode("regexp_for_validation"),
        ["title_in_portal"] = JsonEncodedText.Encode("title_in_portal"),
        ["raw_title_in_portal"] = JsonEncodedText.Encode("raw_title_in_portal"),
        ["visible_in_portal"] = JsonEncodedText.Encode("visible_in_portal"),
        ["editable_in_portal"] = JsonEncodedText.Encode("editable_in_portal"),
        ["required_in_portal"] = JsonEncodedText.Encode("required_in_portal"),
        ["tag"] = JsonEncodedText.Encode("tag"),
        ["created_at"] = JsonEncodedText.Encode("created_at"),
        ["updated_at"] = JsonEncodedText.Encode("updated_at"),
        ["removable"] = JsonEncodedText.Encode("removable"),
        ["agent_description"] = JsonEncodedText.Encode("agent_description")
    };

    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(CustomField);
    }

    public override CustomField Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var token = JsonDocument.ParseValue(ref reader).RootElement;

        var customField = new CustomField { Id = token.GetProperty("id").GetInt64() };

        var valueToken = token.GetProperty("value");

        customField.Values = valueToken.ValueKind == JsonValueKind.Array
            ? ReadArrayValues(valueToken)
            : new List<string> { ReadSingleValue(valueToken) };

        customField.Value = ReadSingleValue(valueToken);

        return customField;
    }

    private static List<string> ReadArrayValues(JsonElement valueToken)
    {
        return valueToken.EnumerateArray().Select(ReadSingleValue).ToList();
    }

    private static string ReadSingleValue(JsonElement valueToken)
    {
        return valueToken.ValueKind switch
        {
            JsonValueKind.String => valueToken.GetString()!,
            JsonValueKind.True or JsonValueKind.False => valueToken.GetBoolean().ToString(),
            JsonValueKind.Number => valueToken.GetDouble().ToString(CultureInfo.InvariantCulture),
            JsonValueKind.Null => string.Empty,
            _ => throw new NotSupportedException($"Unsupported JsonValueKind: {valueToken.ValueKind}")
        };
    }

    public override void Write(Utf8JsonWriter writer, CustomField value, JsonSerializerOptions options)
    {
        if (string.IsNullOrEmpty(value.Value)) return;

        writer.WriteStartObject();

        writer.WriteNumber("id", value.Id);
        WriteValue(writer, "value", value.Value);
        writer.WritePropertyName("details");
        if (value.Details != null) WriteDetails(writer, value.Details);

        writer.WriteEndObject();
    }

    private static void WriteValue(Utf8JsonWriter writer, string propertyName, string value)
    {
        if (bool.TryParse(value, out var boolValue))
            writer.WriteBoolean(propertyName, boolValue);
        else if (TryParseDouble(value, out var doubleValue))
            writer.WriteNumber(propertyName, doubleValue);
        else
            writer.WriteString(propertyName, value);
    }

    private static bool TryParseDouble(string value, out double doubleValue)
    {
        var utf8Value = Encoding.UTF8.GetBytes(value);
        return Utf8Parser.TryParse(utf8Value, out doubleValue, out var bytesConsumed) &&
               bytesConsumed == utf8Value.Length;
    }

    private static void WriteDetails(Utf8JsonWriter writer, TicketField details)
    {
        writer.WriteStartObject();

        writer.WriteString(PropertyNames["url"], details.Url);
        writer.WriteNumber(PropertyNames["id"], details.Id);
        writer.WriteString(PropertyNames["type"], details.Type);
        writer.WriteString(PropertyNames["title"], details.Title);
        writer.WriteString(PropertyNames["raw_title"], details.RawTitle);
        writer.WriteString(PropertyNames["description"], details.Description);
        writer.WriteString(PropertyNames["raw_description"], details.RawDescription);
        writer.WriteNumber(PropertyNames["position"], details.Position);
        writer.WriteBoolean(PropertyNames["active"], details.Active);
        writer.WriteBoolean(PropertyNames["required"], details.Required);
        writer.WriteBoolean(PropertyNames["collapsed_for_agents"], details.CollapsedForAgents);
        writer.WriteString(PropertyNames["regexp_for_validation"], details.RegexpForValidation);
        writer.WriteString(PropertyNames["title_in_portal"], details.TitleInPortal);
        writer.WriteString(PropertyNames["raw_title_in_portal"], details.RawTitleInPortal);
        writer.WriteBoolean(PropertyNames["visible_in_portal"], details.VisibleInPortal);
        writer.WriteBoolean(PropertyNames["editable_in_portal"], details.EditableInPortal);
        writer.WriteBoolean(PropertyNames["required_in_portal"], details.RequiredInPortal);
        writer.WriteString(PropertyNames["tag"], details.Tag);
        writer.WriteBoolean(PropertyNames["removable"], details.Removable);
        writer.WriteString(PropertyNames["agent_description"], details.AgentDescription);

        if (details.CreatedAt.HasValue)
            writer.WriteString(PropertyNames["created_at"], details.CreatedAt.Value);
        else
            writer.WriteNull("created_at");

        if (details.UpdatedAt.HasValue)
            writer.WriteString(PropertyNames["updated_at"], details.UpdatedAt.Value);
        else
            writer.WriteNull("updated_at");

        writer.WriteEndObject();
    }
}