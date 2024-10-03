namespace MessageBrokerService.RabbitMQ;

public sealed record Connection(string HostName, int Port, string UserName, string Password);
