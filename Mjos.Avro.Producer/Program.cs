// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using mjos.avro;

var config  = new ProducerConfig
{ 
    BootstrapServers = "localhost:9092"
};

 var schemaRegistryConfig = new SchemaRegistryConfig
    {
        Url = "localhost:8500"
    };
var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
var producer = new ProducerBuilder<Null, user>(config)
    .SetValueSerializer(new AvroSerializer<user>(schemaRegistry))
    .Build();

while (true)
{
    var user = new user()
    {
        firstname = Faker.Name.FirstName(),
        lastname = Faker.Name.LastName()
    };

    Console.WriteLine($"Creating user {user.firstname}");

    await producer.ProduceAsync("users-avro", new Message<Null, user>()
    {
        Value = user
    });

    Thread.Sleep(1000);
}