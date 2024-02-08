using Microsoft.AspNetCore.Mvc;
using Poc.Nasa.Portal.App.Nasa.AstronomyPicture;

namespace Poc.Nasa.Portal.Api.Controllers;

[ApiController]
[Route("astronomy-picture/v1")]
public sealed class AstronomyPictureController : ControllerBase
{
    private readonly AstronomyPictureOfTheDayHandler _handler;

    public AstronomyPictureController(AstronomyPictureOfTheDayHandler handler) =>
        _handler = handler;

    [HttpGet]
    [Route("info/{date}")]
    public async Task<AstronomyPictureOfTheDayResponseDto> GetPictureByDateAsync(
        DateTime date, CancellationToken ct)
    {
        await _handler.HandleAsync(new AstronomyPictureOfTheDayRequestDto { Date = date }, ct);

        return null;
    }
}