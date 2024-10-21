using BF.Utilities.Json;

namespace BF.Utilities.Tests.Json;

public class TypeJsonConverterTests
{
    private readonly JsonSerializerOptions _options;

    public TypeJsonConverterTests()
    {
        _options = new()
        {
            Converters = { new TypeJsonConverter() },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    [Fact]
    public void Test_Serialize_Type_To_Json()
    {
        JsonSerializer.Serialize(typeof(string), _options).Should().Be("\"System.String\"");
        JsonSerializer.Serialize(typeof(int), _options).Should().Be("\"System.Int32\"");
        JsonSerializer.Serialize(typeof(Guid), _options).Should().Be("\"System.Guid\"");
        JsonSerializer.Serialize(typeof(ulong), _options).Should().Be("\"System.UInt64\"");
        JsonSerializer.Serialize(typeof(decimal), _options).Should().Be("\"System.Decimal\"");
    }

    [Fact]
    public void Test_Deserialize_Type_From_Json()
    {
        const string stringType = "\"System.String\"";
        JsonSerializer.Deserialize<Type>(stringType.ToLower(), _options).Should().Be(typeof(string));
        JsonSerializer.Deserialize<Type>(stringType.ToUpper(), _options).Should().Be(typeof(string));

        JsonSerializer.Deserialize<Type>("\"System.Int32\"", _options).Should().Be(typeof(int));

        Action act = () => JsonSerializer.Deserialize<Type>("\"INVALID_TYPE\"", _options);
        act.Should().Throw<JsonException>();

        Action act2 = () => JsonSerializer.Deserialize<Type>("", _options);
        act2.Should().Throw<JsonException>();
    }
}