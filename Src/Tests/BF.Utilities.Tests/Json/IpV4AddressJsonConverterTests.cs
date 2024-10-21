using BF.Utilities.Json;

namespace BF.Utilities.Tests.Json;

public class IpV4AddressJsonConverterTests
{
    private readonly JsonSerializerOptions _options;

    public IpV4AddressJsonConverterTests()
    {
        _options = new()
        {
            Converters = { new IpV4AddressJsonConverter() },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    [Fact]
    public void Test_Serialize_IpAddress_To_Json()
    {
        JsonSerializer.Serialize(IPAddress.Parse("192.168.1.1"), _options).Should().Be("\"192.168.1.1\"");

        Action actInvalid = () => JsonSerializer.Serialize(IPAddress.Parse("2001:0db8:85a3:0000:0000:8a2e:0370:7334"), _options);
        actInvalid.Should().Throw<JsonException>();
    }

    [Fact]
    public void Test_Deserialize_IpAddress_From_Json()
    {
        JsonSerializer.Deserialize<IPAddress>( "\"192.168.1.1\"", _options).Should().Be(IPAddress.Parse("192.168.1.1"));
        JsonSerializer.Deserialize<IPAddress>( "\"172.16.2.6\"", _options).Should().Be(IPAddress.Parse("172.16.2.6"));

        Action act1 = () => JsonSerializer.Deserialize<IPAddress>("\"2001:0db8:85a3:0000:0000:8a2e:0370:7334\"", _options);
        act1.Should().Throw<JsonException>();

        Action act2 = () => JsonSerializer.Deserialize<IPAddress>("\"\"", _options);
        act2.Should().Throw<JsonException>();

        Action act3 = () => JsonSerializer.Deserialize<IPAddress>("\"127.0\"", _options);
        act2.Should().Throw<JsonException>();
    }
}
