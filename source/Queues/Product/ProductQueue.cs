namespace MessageBrokerService.Queues;

public class ProductQueue(Connection connection) : RabbitMQ.Queue<Product>(connection), IProductQueue;
