// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using System.Text.Json;

var consumerConfig = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "dotnet-users-string",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using(var consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build())
{
    consumer.Subscribe("users-string");
    while(true)
    {
        var consumerResult = consumer.Consume();
        Console.WriteLine($"Received User: {consumerResult.Message.Value}");
    }
}
