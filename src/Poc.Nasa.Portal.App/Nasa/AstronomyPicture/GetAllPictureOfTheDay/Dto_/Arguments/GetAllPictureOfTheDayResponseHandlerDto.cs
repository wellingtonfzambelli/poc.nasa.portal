using Poc.Nasa.Portal.App.Shared;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetAllPictureOfTheDay;

public sealed class GetAllPictureOfTheDayResponseHandlerDto : BaseResponseDto
{
    public IList<GetAllPictureOfTheDayResponseDto> PicturesOfTheDay { get; set; }
}

public sealed class GetAllPictureOfTheDayResponseDto
{
    public Guid Id { get; set; }
    public string Copyright { get; set; }
    public DateTime Date { get; set; }
    public string Explanation { get; set; }
    public string Hdurl { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
}