namespace Poc.Nasa.Portal.Infrastructure.Configurations;

public static class MessageValidation
{
    public static (string code, string description) CorrelationId { get; } = ("CPC001", "CorrelationId é inválido ou não foi informado.");
    public static (string code, string description) DateLessThan { get; } = ("CPC002", "Date can not be less than 2020-01-01");
}