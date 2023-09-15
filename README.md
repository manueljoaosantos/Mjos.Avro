# Mjos.Avro
Testes Avro Schema  com Apache Kafka em Dotnet

# For create applications
```

dotnet new console -o Mjos.Avro.Producer
dotnet new console -o Mjos.Avro.Consumer
dotnet new classlib -o Mjos.Avro.Schema

dotnet sln add .\Mjos.Avro.Producer\
dotnet sln add .\Mjos.Avro.Consumer\
dotnet sln add .\Mjos.Avro.Schema\

```

dotnet tool install --global Apache.Avro.Tools --version 1.11.2

dotnet add package Mjos.Avro --version 1.1.0

dotnet nuget push foo.nupkg -k oy2ccobqtagedjjjfpiaip2gkugtz4cubjkqmupamv5fo4