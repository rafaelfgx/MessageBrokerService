namespace MessageBrokerService.Queues;

public class ProductQueue : RabbitMQ.Queue<Product>, IProductQueue
{
    public ProductQueue(Connection connection) : base(connection) { }
}
