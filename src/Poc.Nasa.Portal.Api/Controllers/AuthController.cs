using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.Nasa.Portal.Api.Controllers.Base;
using Poc.Nasa.Portal.App.Nasa.Authentication.Login;
using Poc.Nasa.Portal.App.Nasa.Authentication.SignUp;
using Poc.Nasa.Portal.App.Shared.Dt;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Poc.Nasa.Portal.Api.Controllers;

[ApiController]
[Route("nasa/v1")]
public sealed class AuthController : AstronomyBaseController
{
    public AuthController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    [Route("login")]
    [ProducesResponseType(typeof(BadRequestDto), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AuthAsync
    (
        [FromBody] LoginRequestDto request,
        [FromHeader(Name = TrackId)][Required] Guid trackId,
        CancellationToken ct
    )
    {
        var response = base.Mediator.Send(
            new LoginRequestHandlerDto(request, trackId),
            ct);

        if (response.Result.IsValid())
            return Ok(response.Result);

        return BadRequest(response.Result.GetErrors());
    }

    [HttpPost]
    [Route("signup")]
    [ProducesResponseType(typeof(BadRequestDto), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SignUpAsync
    (
        [FromBody] SignupRequestDto request,
        [FromHeader(Name = TrackId)][Required] Guid trackId,
        CancellationToken ct
    )
    {
        var response = base.Mediator.Send(
            new SignupRequestHandlerDto(
                request,
                trackId),
            ct);

        if (response.Result.IsValid())
            return NoContent();

        return BadRequest(response.Result.GetErrors());
    }
}