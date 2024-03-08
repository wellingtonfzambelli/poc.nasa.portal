using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.Infrastructure.UnitOfWork;

namespace Poc.Nasa.Portal.App.Nasa.Dashboard;

public sealed class DashboardHandler : IRequestHandler<DashboardRequestHandlerDto, DashboardResponseHandlerDto>
{
    private readonly ILogger<DashboardHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DashboardHandler
    (
        ILogger<DashboardHandler> logger,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DashboardResponseHandlerDto> Handle(
        DashboardRequestHandlerDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("info DashboardHandler");

        throw new NotImplementedException();
    }
}