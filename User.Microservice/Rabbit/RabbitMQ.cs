
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace User.Microservice.Rabbit
{
    public class RabbitMQService : IRabbitMQ
    {
        private readonly IConnectionFactory _connectionFactory;

        public RabbitMQService(IConnectionFactory connectionFactory) { 
            _connectionFactory = connectionFactory;
        }
        
       
        public void Send<T>(string queue, T message)
        {
            var conection = _connectionFactory.CreateConnection();
            var channel = conection.CreateModel();

            channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete:false, arguments:null);
            var jsonString=JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish(
                     exchange: "",
                     routingKey: queue,
                     body: body);

            Console.WriteLine($" [x] Sent {body}");

            conection.Close();
        }

        public void Receive(string queue)
        {
            var conection = _connectionFactory.CreateConnection();
            var channel = conection.CreateModel();

            channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
            
            };

            channel.BasicConsume(queue: queue,
                     autoAck: true,
                     consumer: consumer);
        }
    }
}
