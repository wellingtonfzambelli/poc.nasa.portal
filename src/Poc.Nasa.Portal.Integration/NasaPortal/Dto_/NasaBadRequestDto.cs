namespace Poc.Nasa.Portal.Integration.NasaPortal;

public sealed class NasaBadRequestDto
{
    public NasaErrorDto error { get; set; }
}

public sealed class NasaErrorDto
{
    public string code { get; set; }
    public string message { get; set; }
}