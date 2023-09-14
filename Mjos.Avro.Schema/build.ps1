avrogen.exe -s .\avro\user.avsc .
$version = (Get-Content .\version.txt) -as [int]
$version++

Out-File -FilePath ./version.txt -Encoding ASCII -InputObject $version

dotnet build --configuration Release /p:version=1.$version.0
dotnet nuget push -s http://localhost:8500/v3/index.json -k cd92b288-qvsc-2163-yfim-6e4b49e8f7bd .\bin\Release\Mjos.Avro.1.$version.0.nupkg

#dotnet nuget push -s http://localhost:8500/v3/index.json .\bin\Release\Mjos.Avro.1.0.0.nupkg