using Poc.Nasa.Portal.Domain.Models.Shared;

namespace Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;

public sealed class PictureOfTheDay : BaseModel
{
    // EF
    public PictureOfTheDay() { }

    public PictureOfTheDay
    (
        string copyright,
        DateTime pictureDate,
        string explanation,
        string hdUrl,
        string title,
        string url
    )
    {
        base.Generate();
        Copyright = copyright;
        PictureDate = pictureDate;
        Explanation = explanation;
        HdUrl = hdUrl;
        Title = title;
        Url = url;
    }

    public string Copyright { get; private set; }
    public DateTime PictureDate { get; private set; }
    public string Explanation { get; private set; }
    public string HdUrl { get; private set; }
    public string Title { get; private set; }
    public string Url { get; private set; }
}