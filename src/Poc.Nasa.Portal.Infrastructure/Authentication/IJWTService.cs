using Poc.Nasa.Portal.Domain.Models.AuthenticationAggregate;

namespace Poc.Nasa.Portal.Infrastructure.Authentication;

public interface IJWTService
{
    string GenerateToken(User user);
}