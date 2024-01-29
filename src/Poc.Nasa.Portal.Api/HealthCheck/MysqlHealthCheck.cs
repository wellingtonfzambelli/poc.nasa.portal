using Microsoft.Extensions.Diagnostics.HealthChecks;
using MySql.Data.MySqlClient;

namespace Poc.Nasa.Portal.Api.HealthCheck;

public sealed class MysqlHealthCheck : IHealthCheck
{
    private readonly string _connectionString;
    private readonly string _sql;
    private readonly Action<MySqlConnection> _beforeOpenConnectionConfigurer;

    public MysqlHealthCheck(string mySqlConnectionstring, string sql, Action<MySqlConnection> beforeOpenConnectionConfigurer = null)
    {
        _connectionString = mySqlConnectionstring ?? throw new ArgumentNullException(nameof(mySqlConnectionstring));
        _sql = sql ?? throw new ArgumentNullException(nameof(sql));
        _beforeOpenConnectionConfigurer = beforeOpenConnectionConfigurer;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken ct = default)
    {
        string baseName = "MySql";

        try
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                _beforeOpenConnectionConfigurer?.Invoke(connection);

                await connection.OpenAsync(ct);
                using (var command = connection.CreateCommand())
                {
                    if (ct.IsCancellationRequested)
                        return new HealthCheckResult(context.Registration.FailureStatus);

                    command.CommandText = _sql;
                    await command.ExecuteScalarAsync(ct);
                }

                return HealthCheckResult.Healthy(baseName);
            }
        }
        catch (Exception ex)
        {
            return new HealthCheckResult(context.Registration.FailureStatus, exception: ex, description: $"{baseName} - {ex.Message}");
        }
    }
}