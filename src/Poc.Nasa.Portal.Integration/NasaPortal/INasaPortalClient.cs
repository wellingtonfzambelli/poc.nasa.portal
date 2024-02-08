namespace Poc.Nasa.Portal.Integration.NasaPortal;

public interface INasaPortalClient
{
    Task<GetPictureOfTheDayResponseDto> GetPictureOfTheDayAsync(Guid trackId, CancellationToken ct);
}