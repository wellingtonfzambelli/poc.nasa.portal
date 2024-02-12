using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.Nasa.Portal.Api.Controllers.Base;
using Poc.Nasa.Portal.App.Nasa.AstronomyPicture;
using Poc.Nasa.Portal.App.Shared.Dt;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Poc.Nasa.Portal.Api.Controllers;

[ApiController]
[Route("astronomy-picture/v1")]
public sealed class AstronomyPictureController : AstronomyBaseController
{
    public AstronomyPictureController(IMediator mediator) : base(mediator)
    { }

    [HttpGet]
    [Route("info/{date}")]
    [ProducesResponseType(typeof(AstronomyPictureOfTheDayResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestDto), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetPictureByDateAsync
    (
        [FromHeader(Name = TrackId)][Required] Guid trackId,
        [FromRoute] DateTime date,
        CancellationToken ct
    )
    {
        var response = base.Mediator.Send(
            new AstronomyPictureOfTheDayRequestHandlerDto(
                new AstronomyPictureOfTheDayRequestDto { Date = date },
                trackId),
            ct);

        if (response.Result.IsValid())
            return Ok(response.Result);

        return BadRequest(response.Result.GetErrors());
    }
}