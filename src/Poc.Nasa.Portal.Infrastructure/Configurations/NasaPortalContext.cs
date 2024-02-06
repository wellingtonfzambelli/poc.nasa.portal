using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Poc.Nasa.Portal.Infrastructure.Configurations;

public sealed class NasaPortalContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public NasaPortalContext
    (
        DbContextOptions<NasaPortalContext> options,
        ILoggerFactory loggerFactory = null
    ) : base(options) =>
        _loggerFactory = loggerFactory;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_loggerFactory != null)
            optionsBuilder
                .UseLoggerFactory(_loggerFactory)
                .EnableSensitiveDataLogging(false);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //new SolicitacaoBuilder().Build(modelBuilder.Entity<Solicitacao>());

        base.OnModelCreating(modelBuilder);
    }
}