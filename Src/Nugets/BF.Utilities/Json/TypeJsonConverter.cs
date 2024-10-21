namespace BF.Utilities.Json;

public class TypeJsonConverter : JsonConverter<Type>
{
    public override Type? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string value = reader.GetString() ?? string.Empty;
        try
        {
            return Type.GetType(value, throwOnError: true, ignoreCase: true);
        }
        catch (Exception e)
        {
            throw new JsonException($"Unable to parse type {value}.", e);
        }
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.FullName);
}