FROM mcr.microsoft.com/dotnet/sdk:7.0
RUN apt-get update

#ARG Version  
WORKDIR /sln

COPY . .

RUN dotnet restore
RUN dotnet build /p:Version=7.0 -c Release --no-restore  
RUN dotnet pack /p:Version=7.0 -c Release --no-restore --no-build -o /sln/artifacts 

ENTRYPOINT ["dotnet", "nuget", "push", "/sln/artifacts/*.nupkg"]
CMD ["--source", "https://api.nuget.org/v3/index.json"]