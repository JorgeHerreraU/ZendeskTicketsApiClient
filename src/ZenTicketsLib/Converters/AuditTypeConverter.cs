using System.Text.Json;
using System.Text.Json.Serialization;
using ZenTicketsLib.Models.Audit;

namespace ZenTicketsLib.Converters;

public class AuditTypeConverter : JsonConverter<AuditType>
{
    public override AuditType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();
        return Enum.TryParse<AuditType>(stringValue, true, out var result) ? result : AuditType.Error;
    }

    public override void Write(Utf8JsonWriter writer, AuditType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}