using Poc.Nasa.Portal.Domain.Models.Shared;

namespace Poc.Nasa.Portal.Domain.Models.AuthenticationAggregate;

public sealed class User : BaseModel
{
    // EF
    public User() { }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;

        Roles = new HashSet<UserRole>();
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public ICollection<UserRole> Roles { get; private set; }

    // TODO: temporary method, get the data from database
    public void SetMockedRoles(User user)
    {
        Roles.Add(new UserRole("admin"));
        Roles.Add(new UserRole("developer"));
    }
}