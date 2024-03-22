namespace Poc.Nasa.Portal.Infrastructure.Configurations;

public static class MessageValidation
{
    // Globals
    public static (string code, string description) GeneralError { get; } = ("NASA999", "Something was wrong. Try again later.");

    // FluentValidation
    public static (string code, string description) DateLessThan { get; } = ("NASA002", "Date can not be less than 2020-01-01");
    public static (string code, string description) NoDataFound { get; } = ("NASA003", "Empty list");
    public static (string code, string description) RequiredField { get; } = ("NASA004", "The field {0} is required");
    public static (string code, string description) InvalidField { get; } = ("NASA005", "The field {0} is invalid");
    public static (string code, string description) InvalidMaxlength { get; } = ("NASA006", "The field {0} should contains at maximun {1}");
    public static (string code, string description) InvalidMinlength { get; } = ("NASA007", "The field {0} should contains at minimum {1}");
    public static (string code, string description) NotEqual { get; } = ("NASA008", "The field {0} does not match with the field {1}");

    // Auth
    public static (string code, string description) AuthUserIsLockedOut { get; } = ("NASA050", "This account is locked out");
    public static (string code, string description) AuthUserIsNowAllowed { get; } = ("NASA051", "This account does not have permition to login");
    public static (string code, string description) AuthUserRequiresTwoFactors { get; } = ("NASA052", "It is necessary to confirm in your the second factor");
    public static (string code, string description) AuthUserOrPasswordInvalid { get; } = ("NASA053", "E-mail or password invalid");
}