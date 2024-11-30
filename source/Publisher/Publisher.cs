namespace MessageBrokerService.Publisher;

public static class Publisher
{
    public static void Main()
    {
        Console.WriteLine(nameof(Publisher).ToUpper());

        IProductQueue productQueue = new ProductQueue(new Connection("localhost", 5672, "admin", "P4ssW0rd!"));

        while (true)
        {
            Console.Write("Enter the product name: ");

            var name = Console.ReadLine();

            var product = new Product { Name = name };

            productQueue.PublishAsync(product).Wait();
        }
    }
}
