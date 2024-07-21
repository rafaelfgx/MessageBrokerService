namespace MessageBrokerService.Subscriber;

public static class Subscriber
{
    public static void Main()
    {
        Console.WriteLine(nameof(Subscriber).ToUpper());

        IProductQueue productQueue = new ProductQueue(new Connection("localhost", 5672, "admin", "P4ssW0rd!"));

        productQueue.Subscribe(product => Console.WriteLine(product.Name));
    }
}
