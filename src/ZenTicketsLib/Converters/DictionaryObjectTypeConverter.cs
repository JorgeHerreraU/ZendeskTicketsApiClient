using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZenTicketsLib.Converters;

public class DictionaryObjectTypeConverter : JsonConverter<IReadOnlyDictionary<string, object>>
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(IReadOnlyDictionary<string, object>).IsAssignableFrom(objectType);
    }

    public override IReadOnlyDictionary<string, object> Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

        var dictionary = new Dictionary<string, object>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject) return dictionary;

            if (reader.TokenType != JsonTokenType.PropertyName) throw new JsonException();

            var propertyName = reader.GetString();

            reader.Read();

            object? propertyValue = reader.TokenType switch
            {
                JsonTokenType.Number => reader.GetDouble(),
                JsonTokenType.String => reader.GetString(),
                JsonTokenType.True => true,
                JsonTokenType.False => false,
                JsonTokenType.Null => null,
                _ => throw new JsonException()
            };

            if (propertyName != null && propertyValue != null)
                dictionary.Add(propertyName, propertyValue);
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, IReadOnlyDictionary<string, object> value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        foreach (var kvp in value)
        {
            writer.WritePropertyName(kvp.Key);

            switch (kvp.Value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case string stringValue:
                    writer.WriteStringValue(stringValue);
                    break;
                case double doubleValue:
                    writer.WriteNumberValue(doubleValue);
                    break;
                case bool boolValue:
                    writer.WriteBooleanValue(boolValue);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        writer.WriteEndObject();
    }
}