namespace Poc.Nasa.Portal.Integration.NasaPortal;

public interface INasaPortalClient
{
    Task<GetPictureOfTheDayResponseClientDto> GetPictureOfTheDayAsync(
        DateTime dateOfPicture, Guid trackId, CancellationToken ct);
}