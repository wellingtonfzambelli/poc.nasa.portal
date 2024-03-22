using FluentValidation;
using Poc.Nasa.Portal.Infrastructure.Configurations;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.SignUp;

public sealed class SignupValidator : AbstractValidator<SignupRequestDto>
{
    public SignupValidator()
    {
        RuleFor(s => s.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
                .WithErrorCode(MessageValidation.RequiredField.code)
                .WithMessage(string.Format(MessageValidation.RequiredField.description, "Name"));

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
                .WithMessage(string.Format(MessageValidation.RequiredField.description, "Password"));

        RuleFor(s => s.PasswordConfirm)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
                .WithErrorCode(MessageValidation.RequiredField.code)
                .WithMessage(string.Format(MessageValidation.RequiredField.description, "Password Confirm"))
            .Equal(x => x.Password)
                .WithErrorCode(MessageValidation.NotEqual.code)
                .WithMessage(string.Format(MessageValidation.NotEqual.description, "Password", "Password Confirm"));
    }
}