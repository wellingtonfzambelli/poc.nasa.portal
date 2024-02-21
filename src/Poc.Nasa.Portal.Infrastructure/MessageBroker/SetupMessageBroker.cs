using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Poc.Nasa.Portal.Infrastructure.MessageBroker;

public sealed class SetupMessageBroker : ISetupMessageBroker
{
    private readonly IConnectionFactory _connectionFactory;

    public SetupMessageBroker(string hostName, string vhost, string userName, string password) =>
        _connectionFactory = new ConnectionFactory()
        {
            HostName = hostName,
            VirtualHost = vhost,
            UserName = userName,
            Password = password
        };

    public void ProduceMessage(string message, string queue, string exchange, string routingKey)
    {
        using (IConnection conn = _connectionFactory.CreateConnection())
        using (IModel channel = conn.CreateModel())
        {
            channel.ExchangeDeclare(exchange, ExchangeType.Direct, durable: true);
            channel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            channel.QueueBind(queue, exchange, routingKey, null);

            var props = channel.CreateBasicProperties();
            props.Persistent = true;

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange, routingKey, props, body);
        }
    }

    public string ConsumeMessage(string queue)
    {
        using (var connection = _connectionFactory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(channel);

            BasicGetResult result = channel.BasicGet(queue, true);

            if (result == null)
                return null;

            return Encoding.UTF8.GetString(result.Body.ToArray());
        }
    }
}