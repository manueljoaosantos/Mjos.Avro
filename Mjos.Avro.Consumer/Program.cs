// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using System.Text.Json;

var consumerConfig = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "dotnet-users-json",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using(var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
{
    consumer.Subscribe("users-json");
    while(true)
    {
        var consumerResult = consumer.Consume();
        var user = JsonSerializer.Deserialize<User>(consumerResult.Message.Value);

        Console.WriteLine($"Received User: Key={user.Id} {user.FirstName}");
    }
}
