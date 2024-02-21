namespace Poc.Nasa.Portal.Infrastructure.MessageBroker;

public interface ISetupMessageBroker
{
    void ProduceMessage(string message, string queue, string exchange, string routingKey);
    string ConsumeMessage(string queue);
}