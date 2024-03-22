namespace Poc.Nasa.Portal.Infrastructure.Identity;

public interface IIdentityService
{
    Task<Tuple<string, string>> GenerateCredentialsAsync(string email);
}