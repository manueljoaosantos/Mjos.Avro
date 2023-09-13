// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using System;
using System.Text.Json;

var producerConfig = new ProducerConfig
{ 
    BootstrapServers = "localhost:9092"
};

var producer = new ProducerBuilder<Null, string>(producerConfig).Build();

while (true)
{
    var userName =Faker.Name.FirstName();
    Console.WriteLine($"Creating User: {userName}");
    var result = producer.ProduceAsync("users-string", new Message<Null, string> { Value = userName }).GetAwaiter().GetResult();

    Thread.Sleep(1000);
}