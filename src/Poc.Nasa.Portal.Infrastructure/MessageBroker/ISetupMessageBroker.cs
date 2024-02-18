namespace Poc.Nasa.Portal.Infrastructure.MessageBroker;

public interface ISetupMessageBroker
{
    void Producer(string message, string queue, string exchange, string routingKey);
}