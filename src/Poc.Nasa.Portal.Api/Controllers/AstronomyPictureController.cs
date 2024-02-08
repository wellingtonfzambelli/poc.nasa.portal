using Microsoft.AspNetCore.Mvc;
using Poc.Nasa.Portal.Api.Shared;
using Poc.Nasa.Portal.App.Nasa.AstronomyPicture;
using Poc.Nasa.Portal.App.Shared.Dt;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Poc.Nasa.Portal.Api.Controllers;

[ApiController]
[Route("astronomy-picture/v1")]
public sealed class AstronomyPictureController : AstronomyBaseController
{
    private readonly AstronomyPictureOfTheDayHandler _handler;

    public AstronomyPictureController(AstronomyPictureOfTheDayHandler handler) =>
        _handler = handler;

    [HttpGet]
    [Route("info/{date}")]
    [ProducesResponseType(typeof(AstronomyPictureOfTheDayResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestDto), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<AstronomyPictureOfTheDayResponseDto> GetPictureByDateAsync
    (
        [FromHeader(Name = TrackId)][Required] Guid trackId,
        [FromRoute] DateTime date,
        CancellationToken ct
    )
    {
        if (await _handler.HandleAsync(new AstronomyPictureOfTheDayRequestDto { Date = date }, ct)
            is var response && response is null)
            return null;

        return null;
    }
}