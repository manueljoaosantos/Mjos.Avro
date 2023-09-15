avrogen.exe -s .\avro\user.avsc .
$version = (Get-Content .\version.txt) -as [int]
$version++

Out-File -FilePath ./version.txt -Encoding ASCII -InputObject $version

dotnet build --configuration Release /p:version=1.$version.0
dotnet nuget push -s https://api.nuget.org/v3/index.json -k oy2ccobqtagedjjjfpiaip2gkugtz4cubjkqmupamv5fo4 .\bin\Release\Mjos.Avro.1.$version.0.nupkg