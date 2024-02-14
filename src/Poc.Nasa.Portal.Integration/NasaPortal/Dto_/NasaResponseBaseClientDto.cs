namespace Poc.Nasa.Portal.Integration.NasaPortal;

public abstract class NasaResponseBaseClientDto
{
    protected NasaBadRequestClientDto BadRequest { get; private set; }

    public void SetError(NasaBadRequestClientDto error) =>
        BadRequest = error;

    public NasaBadRequestClientDto GetError() =>
        BadRequest;

    public bool IsValid() =>
        BadRequest is null;
}