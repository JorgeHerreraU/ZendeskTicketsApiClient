using System.Text.Json;
using System.Text.Json.Serialization;
using ZenTicketsLib.Models.Tickets;

namespace ZenTicketsLib.Converters;

public class CustomFieldsConverter : JsonConverter<IReadOnlyCustomFields>
{
    private static readonly Type[] DeserializableSearchTypes =
    {
        typeof(IReadOnlyCustomFields),
        typeof(ICustomFields)
    };

    public override bool CanConvert(Type typeToConvert)
    {
        return DeserializableSearchTypes.Any(t => t == typeToConvert);
    }

    public override IReadOnlyCustomFields? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<CustomFields>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, IReadOnlyCustomFields value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}