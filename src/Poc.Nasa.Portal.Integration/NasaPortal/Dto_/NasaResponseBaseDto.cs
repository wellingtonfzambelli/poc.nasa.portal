namespace Poc.Nasa.Portal.Integration.NasaPortal;

public abstract class NasaResponseBaseDto
{
    protected NasaBadRequestDto BadRequest { get; private set; }

    public void SetError(NasaBadRequestDto error) =>
        BadRequest = error;

    public NasaBadRequestDto GetError() =>
        BadRequest;

    public bool IsValid() =>
        BadRequest is null;
}