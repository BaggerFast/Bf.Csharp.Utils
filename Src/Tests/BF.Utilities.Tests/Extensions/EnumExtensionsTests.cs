using BF.Utilities.Extensions;

namespace BF.Utilities.Tests.Extensions;

public enum TestEnum
{
    [Description("FirstValue")]
    First,
    Second
}

public class EnumExtensionsTests
{
    [Fact]
    public void Test_Enum_Get_Description()
    {
        TestEnum.First.GetDescription().Should().Be("FirstValue");
        TestEnum.Second.GetDescription().Should().Be(nameof(TestEnum.Second));
    }
}