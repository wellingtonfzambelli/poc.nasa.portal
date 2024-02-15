using Poc.Nasa.Portal.Domain.Models.Shared;

namespace Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;

public sealed class PictureOfTheDay : BaseModel
{
    // EF
    public PictureOfTheDay() { }

    public string Copyight { get; private set; }
    public DateTime Date { get; private set; }
    public string Explanation { get; private set; }
    public string HdUrl { get; private set; }
    public string Title { get; private set; }
    public string Url { get; private set; }
}