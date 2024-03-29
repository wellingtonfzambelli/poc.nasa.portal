﻿using Poc.Nasa.Portal.App.Shared;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetPictureOfTheDay;

public sealed class GetPictureOfTheDayResponseHandlerDto : BaseResponseDto
{
    public string Copyright { get; set; }
    public DateTime Date { get; set; }
    public string Explanation { get; set; }
    public string Hdurl { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
}