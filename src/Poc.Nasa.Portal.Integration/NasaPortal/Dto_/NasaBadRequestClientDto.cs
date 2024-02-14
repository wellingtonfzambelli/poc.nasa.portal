namespace Poc.Nasa.Portal.Integration.NasaPortal;

public sealed class NasaBadRequestClientDto
{
    public NasaErrorClientDto error { get; set; }
}

public sealed class NasaErrorClientDto
{
    public string code { get; set; }
    public string message { get; set; }
}