using System.Net.Sockets;
using BF.Utilities.Utils;

namespace BF.Utilities.Json;

public class IpV4AddressJsonConverter : JsonConverter<IPAddress>
{
    public override IPAddress Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? ipString = reader.GetString();
        if (StrUtils.TryParseToIpV4Address(ipString, out IPAddress? ipAddress)) return ipAddress;
        throw new JsonException($"Invalid IP address format: {ipString}");
    }

    public override void Write(Utf8JsonWriter writer, IPAddress value, JsonSerializerOptions options)
    {
        if (value.AddressFamily == AddressFamily.InterNetworkV6) throw new JsonException($"Invalid IP V4 address format: {value}");
        writer.WriteStringValue(value.ToString());
    }
}