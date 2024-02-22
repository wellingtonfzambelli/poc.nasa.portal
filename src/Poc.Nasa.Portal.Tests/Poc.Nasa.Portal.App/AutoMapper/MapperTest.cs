using AutoMapper;
using Poc.Nasa.Portal.App.AutoMapper;
using Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetPictureOfTheDay;
using Poc.Nasa.Portal.Integration.NasaPortal;

namespace Poc.Nasa.Portal.Tests.Poc.Nasa.Portal.App.AutoMapper;

public sealed class MapperTest
{
    [Fact]
    public void AutoMapper_Configuration_IsValid()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<ConfigurationMapping>());
        config.AssertConfigurationIsValid();
    }

    [Fact]
    public void ShouldMapper_MapAdmitAllFields()
    {
        // arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<ConfigurationMapping>());
        var mapper = config.CreateMapper();

        var source = new GetPictureOfTheDayResponseClientDto
        {
            Copyright = "copy",
            Date = DateTime.Today,
            Explanation = "Explanation test",
            Hdurl = "hdurl.test",
            Title = "my title",
            Url = "myurl.com"
        };

        // act
        var result = mapper.Map<GetPictureOfTheDayResponseClientDto, AstronomyPictureOfTheDayResponseDto>(source);

        // assert
        Assert.NotNull(result);
        Assert.Equal(result.Copyright, source.Copyright);
        Assert.Equal(result.Date, source.Date);
        Assert.Equal(result.Explanation, source.Explanation);
        Assert.Equal(result.Hdurl, source.Hdurl);
        Assert.Equal(result.Title, source.Title);
        Assert.Equal(result.Url, source.Url);
    }
}