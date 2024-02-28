namespace User.Microservice.Rabbit
{
    public interface IRabbitMQ
    {
        public void Send<T>(string queue, T message);
        public void Receive(string queue);
    }
}
