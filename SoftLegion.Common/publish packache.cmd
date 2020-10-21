dotnet restore
dotnet clean -c Release
dotnet build -c Release
dotnet pack --include-symbols --configuration Release
dotnet nuget push "bin/Release/SoftLegion.Common.1.0.0.nupkg" --source "github"

pause