using Poc.Nasa.Portal.Domain.Shared;

namespace Poc.Nasa.Portal.Tests.Poc.Nasa.Portal.Domain.Shared;

public sealed class UtilsTests
{
    [Theory]
    [InlineData("Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1T", 60)]
    [InlineData("Test1 Test1 Test1", 35)]
    [InlineData("Test1 Test1 Test1 Test1 Test1", 40)]
    [InlineData("Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1T Test1 Test1 Test1 Test1T", 85)]
    public async Task Validate_Texts_Under_Limit_Will_Not_Truncate_And_Return_Success(string text, int limitChar)
    {
        // Act
        string truncatedText = text.Truncate(limitChar);

        // Assert
        Assert.Equal(text, truncatedText);
        Assert.True(truncatedText.Length <= limitChar);
    }

    [Theory]
    [InlineData("Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1T", 59)]
    [InlineData("Test1 Test1 Test1", 10)]
    [InlineData("Test1 Test1 Test1 Test1 Test1", 15)]
    [InlineData("Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1 Test1T Test1 Test1 Test1 Test1", 80)]
    public async Task Validate_Texts_Under_Limit_Will_Be_Truncate_With_Specified_Size_And_Return_Success(string text, int limitChar)
    {
        // Act
        string truncatedText = text.Truncate(limitChar);

        // Assert
        Assert.NotEqual(text, truncatedText);
        Assert.True(truncatedText.Length == limitChar);
    }
}