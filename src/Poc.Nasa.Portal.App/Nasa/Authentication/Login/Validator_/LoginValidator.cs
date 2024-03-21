using FluentValidation;
using Poc.Nasa.Portal.Infrastructure.Configurations;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.Login;

public sealed class LoginValidator : AbstractValidator<LoginRequestDto>
{
    public LoginValidator()
    {
        RuleFor(s => s.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
                .WithErrorCode(MessageValidation.RequiredField.code)
                .WithMessage(string.Format(MessageValidation.RequiredField.description, "Email"))
            .MinimumLength(7)
                .WithErrorCode(MessageValidation.InvalidMinlength.code)
                .WithMessage(string.Format(MessageValidation.InvalidMinlength.description, "Email", 7))
            .MaximumLength(90)
                .WithErrorCode(MessageValidation.InvalidMaxlength.code)
                .WithMessage(string.Format(MessageValidation.InvalidMaxlength.description, "Email", 90))
            .EmailAddress()
                .WithErrorCode(MessageValidation.InvalidField.code)
                .WithMessage(string.Format(MessageValidation.InvalidField.description, "Email"));

        RuleFor(s => s.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
                .WithErrorCode(MessageValidation.RequiredField.code)
                .WithMessage(string.Format(MessageValidation.RequiredField.description, "Password"))
            .MinimumLength(6)
                .WithErrorCode(MessageValidation.InvalidMinlength.code)
                .WithMessage(string.Format(MessageValidation.InvalidMinlength.description, "Password", 6))
            .MaximumLength(18)
                .WithErrorCode(MessageValidation.InvalidMaxlength.code)
                .WithMessage(string.Format(MessageValidation.InvalidMaxlength.description, "Password", 18));
    }
}