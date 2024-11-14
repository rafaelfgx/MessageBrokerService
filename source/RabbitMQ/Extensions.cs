namespace MessageBrokerService.RabbitMQ;

public static class Extensions
{
    public static byte[] Bytes(this object obj) => Encoding.Default.GetBytes(JsonSerializer.Serialize(obj));

    public static T Object<T>(this byte[] bytes) => JsonSerializer.Deserialize<T>(Encoding.Default.GetString(bytes));
}
