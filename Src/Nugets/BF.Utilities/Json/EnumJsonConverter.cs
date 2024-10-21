namespace BF.Utilities.Json;

public class EnumJsonConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
{
    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException($"Unexpected token type: {reader.TokenType}");

        string? enumValue = reader.GetString();
        return Enum.TryParse(enumValue, true, out TEnum result) ? result :
            throw new JsonException($"Unable to convert \"{enumValue}\" to enum {typeof(TEnum)}");
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString());
}