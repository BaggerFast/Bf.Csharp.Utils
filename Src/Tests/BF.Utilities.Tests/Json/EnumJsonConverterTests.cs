using BF.Utilities.Json;

namespace BF.Utilities.Tests.Json;

public enum TestEnum
{
    First
}

public class EnumJsonConverterTests
{
    private readonly JsonSerializerOptions _options;

    public EnumJsonConverterTests()
    {
        _options = new()
        {
            Converters = { new EnumJsonConverter<TestEnum>() },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    [Fact]
    public void Test_Serialize_Enum_To_Json()
    {
        JsonSerializer.Serialize(TestEnum.First, _options).Should().Be("\"First\"");
    }

    [Fact]
    public void Test_Deserialize_Enum_From_Json()
    {
        JsonSerializer.Deserialize<TestEnum>("\"First\"", _options).Should().Be(TestEnum.First);
        JsonSerializer.Deserialize<TestEnum>("\"first\"", _options).Should().Be(TestEnum.First);
        JsonSerializer.Deserialize<TestEnum>("\"FIRST\"", _options).Should().Be(TestEnum.First);

        Action act = () => JsonSerializer.Deserialize<TestEnum>("\"INVALID_VALUE\"", _options);
        act.Should().Throw<JsonException>();
    }
}