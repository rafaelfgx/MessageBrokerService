# MessageBrokerService

[RabbitMQ](https://www.rabbitmq.com)

## IProductQueue

 ```csharp
public interface IProductQueue : IQueue<Product>;
 ```

## ProductQueue

 ```csharp
public class ProductQueue(Connection connection) : RabbitMQ.Queue<Product>(connection), IProductQueue;
 ```

## Publisher

 ```csharp
public static class Publisher
{
    public static void Main()
    {
        Console.WriteLine(nameof(Publisher).ToUpper());

        IProductQueue productQueue = new ProductQueue(new Connection("localhost", 5672, "user", "password"));

        while (true)
        {
            Console.Write("Enter the product name: ");

            var name = Console.ReadLine();

            var product = new Product { Name = name };

            productQueue.PublishAsync(product).Wait();
        }
    }
}
 ```

## Subscriber

 ```csharp
public static class Subscriber
{
    public static void Main()
    {
        Console.WriteLine(nameof(Subscriber).ToUpper());

        IProductQueue productQueue = new ProductQueue(new Connection("localhost", 5672, "user", "password"));

        productQueue.SubscribeAsync(Handle).Wait();
    }

    private static Task Handle(Product product)
    {
        Console.WriteLine(product.Name);

        return Task.CompletedTask;
    }
}
 ```
