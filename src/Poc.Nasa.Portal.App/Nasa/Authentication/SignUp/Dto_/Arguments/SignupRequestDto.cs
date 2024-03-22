namespace Poc.Nasa.Portal.App.Nasa.Authentication.SignUp;

public sealed class SignupRequestDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}