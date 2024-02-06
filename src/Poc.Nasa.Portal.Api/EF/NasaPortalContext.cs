using Microsoft.EntityFrameworkCore;

namespace Poc.Nasa.Portal.Api.EF;

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