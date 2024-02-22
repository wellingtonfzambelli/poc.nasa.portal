using Poc.Nasa.Portal.Domain.Shared;

namespace Poc.Nasa.Portal.Tests.Poc.Nasa.Portal.Domain.Shared;

public sealed class UtilsTests
{
    [Theory]
    [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", 60)]
    [InlineData("Lorem ipsum dolor", 35)]
    [InlineData("Lorem ipsum dolor sit amet, c", 40)]
    [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incidi", 85)]
    public async Task Validate_Texts_Under_Limit_Will_Not_Truncate_And_Return_Success(string text, int limitChar)
    {
        // Act
        string truncatedText = text.Truncate(limitChar);

        // Assert
        Assert.Equal(text, truncatedText);
        Assert.True(truncatedText.Length <= limitChar);
    }

    [Theory]
    [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", 59)]
    [InlineData("Lorem ipsum dolor sit", 10)]
    [InlineData("Lorem ipsum dolor sit amet", 15)]
    [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt", 80)]
    public async Task Validate_Texts_Under_Limit_Will_Be_Truncate_With_Specified_Size_And_Return_Success(string text, int limitChar)
    {
        // Act
        string truncatedText = text.Truncate(limitChar);

        // Assert
        Assert.NotEqual(text, truncatedText);
        Assert.True(truncatedText.Length == limitChar);
    }
}