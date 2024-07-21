# MessageBrokerService

[RabbitMQ](https://www.rabbitmq.com)

## IProductQueue

 ```csharp
    public interface IProductQueue : IQueue<Product> { }
 ```

## ProductQueue

 ```csharp
    public class ProductQueue : Queue<Product>, IProductQueue { }
 ```

## Publisher

 ```csharp
    public static class Publisher
    {
        public static void Main()
        {
            Console.WriteLine(nameof(Publisher).ToUpper());

            while (true)
            {
                Console.Write("Enter the product name: ");

                var name = Console.ReadLine();

                var product = new Product { Name = name };

                IProductQueue productQueue = new ProductQueue();

                productQueue.Publish(product);
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

            IProductQueue productQueue = new ProductQueue();

            productQueue.Subscribe((product) => Console.WriteLine(product.Name));

            Console.ReadLine();
        }
    }
 ```
