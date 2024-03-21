namespace Poc.Nasa.Portal.Infrastructure.Configurations;

public static class MessageValidation
{
    public static (string code, string description) GeneralError { get; } = ("NASA999", "Generic Error");
    public static (string code, string description) DateLessThan { get; } = ("NASA002", "Date can not be less than 2020-01-01");
    public static (string code, string description) NoDataFound { get; } = ("NASA003", "Empty list");
    public static (string code, string description) RequiredField { get; } = ("NASA004", "The field {0} is required");
    public static (string code, string description) InvalidField { get; } = ("NASA005", "The field {0} is invalid");
    public static (string code, string description) InvalidMaxlength { get; } = ("NASA006", "The field {0} should contains at maximun {1}");
    public static (string code, string description) InvalidMinlength { get; } = ("NASA007", "The field {0} should contains at minimum {1}");
    public static (string code, string description) UserOrPasswordInvalid { get; } = ("NASA008", "E-mail or password invalid");
}