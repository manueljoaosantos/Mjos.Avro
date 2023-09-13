// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using System;
using System.Text.Json;

var producerConfig = new ProducerConfig
{ 
    BootstrapServers = "localhost:9092"
};

var producer = new ProducerBuilder<string, string>(producerConfig).Build();

while (true)
{
    var user = new User{
        Id = Guid.NewGuid().ToString(),
        FirstName = Faker.Name.FirstName(),
        LastName = Faker.Name.LastName()
    };
    Console.WriteLine($"Creating User: {user.FirstName}");
    producer.ProduceAsync("users-json", new Message<string, string> {
        Key = user.Id,
        Value = JsonSerializer.Serialize(user) 
        }).GetAwaiter().GetResult();

    Thread.Sleep(1000);
}