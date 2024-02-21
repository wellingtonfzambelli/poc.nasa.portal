namespace Poc.Nasa.Portal.Infrastructure.MessageBroker.Messages;

public sealed class PictureOfTheDayMsg
{
    public string Copyright { get; set; }
    public DateTime PictureDate { get; set; }
    public string Explanation { get; set; }
    public string HdUrl { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
}