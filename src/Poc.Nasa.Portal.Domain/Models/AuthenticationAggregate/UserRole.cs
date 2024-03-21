using Poc.Nasa.Portal.Domain.Models.Shared;

namespace Poc.Nasa.Portal.Domain.Models.AuthenticationAggregate;

public sealed class UserRole : BaseModel
{
    // EF
    public UserRole() { }

    public UserRole(string desscription)
    {
        Desscription = desscription;
        Users = new HashSet<User>();
    }

    public string Desscription { get; private set; }

    public ICollection<User> Users { get; private set; }
}