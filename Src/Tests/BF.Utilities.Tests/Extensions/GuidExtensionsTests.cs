using BF.Utilities.Constants;
using BF.Utilities.Extensions;

namespace BF.Utilities.Tests.Extensions;

public class GuidExtensionsTests
{
    [Fact]
    public void Test_Guid_Is_Max()
    {
        DefaultTypes.GuidMax.IsMax().Should().BeTrue();
        Guid.NewGuid().IsMax().Should().BeFalse();
    }

    [Fact]
    public void Test_Guid_Is_Empty()
    {
        Guid.Empty.IsEmpty().Should().BeTrue();
        Guid.NewGuid().IsEmpty().Should().BeFalse();
    }
}