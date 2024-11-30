namespace MessageBrokerService.Subscriber;

public static class Subscriber
{
    public static void Main()
    {
        Console.WriteLine(nameof(Subscriber).ToUpper());

        IProductQueue productQueue = new ProductQueue(new Connection("localhost", 5672, "admin", "P4ssW0rd!"));

        productQueue.SubscribeAsync(Handle).Wait();
    }

    private static Task Handle(Product product)
    {
        Console.WriteLine(product.Name);

        return Task.CompletedTask;
    }
}
