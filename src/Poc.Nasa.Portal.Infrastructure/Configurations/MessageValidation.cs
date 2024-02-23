namespace Poc.Nasa.Portal.Infrastructure.Configurations;

public static class MessageValidation
{
    public static (string code, string description) GeneralError { get; } = ("NASA999", "Generic Error.");
    public static (string code, string description) DateLessThan { get; } = ("NASA002", "Date can not be less than 2020-01-01");
    public static (string code, string description) NoDataFound { get; } = ("NASA003", "Empty list");
}