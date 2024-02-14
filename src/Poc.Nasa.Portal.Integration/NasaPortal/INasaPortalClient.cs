namespace Poc.Nasa.Portal.Integration.NasaPortal;

public interface INasaPortalClient
{
    Task<GetPictureOfTheDayResponseClientDto> GetPictureOfTheDayAsync(Guid trackId, CancellationToken ct);
}