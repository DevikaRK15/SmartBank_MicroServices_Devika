using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class TransactionConsumer
{
    public void Start()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };


        var connection = factory.CreateConnection();

        var channel = connection.CreateModel();


        channel.QueueDeclare(
            queue: "transaction_queue",
            durable: true,
            exclusive: false,
            autoDelete: false
        );


        var consumer = new EventingBasicConsumer(channel);


        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();

            var message = Encoding.UTF8.GetString(body);


            Console.WriteLine(
                $"Received Transaction: {message}"
            );


            channel.BasicAck(
                ea.DeliveryTag,
                false
            );
        };


        channel.BasicConsume(
            queue: "transaction_queue",
            autoAck: false,
            consumer: consumer
        );
    }
}