namespace Poc.Nasa.Portal.Infrastructure.Authentication;

public interface IJWTService
{
    string GenerateToken(string email, string[] roles);
}