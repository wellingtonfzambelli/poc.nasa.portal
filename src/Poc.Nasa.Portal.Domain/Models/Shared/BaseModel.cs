namespace Poc.Nasa.Portal.Domain.Models.Shared;

public abstract class BaseModel
{
    public Guid Id { get; private set; }

    public void GenerateId() =>
        Id = Guid.NewGuid();
}