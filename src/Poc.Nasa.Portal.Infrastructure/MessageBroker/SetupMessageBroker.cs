using RabbitMQ.Client;
using System.Text;

namespace Poc.Nasa.Portal.Infrastructure.MessageBroker;

public sealed class SetupMessageBroker : ISetupMessageBroker
{
    private readonly ConnectionFactory _connectionFactory;

    public SetupMessageBroker(string hostName, string vhost) =>
        _connectionFactory = new ConnectionFactory()
        {
            HostName = hostName,
            VirtualHost = vhost
        };

    public void Producer(string message, string queue, string exchange, string routingKey)
    {
        using (var connection = _connectionFactory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: exchange,
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($" Sent: {message}");
        }
    }

    //static void Consumer()
    //{
    //    var factory = new ConnectionFactory()
    //    {
    //        HostName = HOST_NAME,
    //        VirtualHost = VHOST
    //    };

    //    using (var connection = factory.CreateConnection())
    //    using (var channel = connection.CreateModel())
    //    {
    //        channel.QueueDeclare(queue: QUEUE,
    //                             durable: false,
    //                             exclusive: false,
    //                             autoDelete: false,
    //                             arguments: null);

    //        var consumer = new EventingBasicConsumer(channel);
    //        consumer.Received += (model, ea) =>
    //        {
    //            try
    //            {
    //                var body = ea.Body.ToArray();
    //                var message = Encoding.UTF8.GetString(body);

    //                Console.WriteLine($"Received: {message}");

    //                // Remove the message from queue
    //                channel.BasicAck(ea.DeliveryTag, false);
    //            }
    //            catch (Exception ex)
    //            {
    //                // Return the message to queue
    //                channel.BasicNack(ea.DeliveryTag, false, true);
    //            }
    //        };

    //        channel.BasicConsume(queue: QUEUE,
    //                             autoAck: false, // RabbitMQ waiting a confirmation manualy
    //                             consumer: consumer);
    //    }
    //}
}