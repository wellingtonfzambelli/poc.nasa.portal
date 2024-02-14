namespace Poc.Nasa.Portal.Integration.NasaPortal;

public sealed class GetPictureOfTheDayResponseClientDto : NasaResponseBaseClientDto
{
    public string Copyright { get; set; }
    public DateTime Date { get; set; }
    public string Explanation { get; set; }
    public string Hdurl { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
}