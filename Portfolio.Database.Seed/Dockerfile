FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore Portfolio.Database.Seed/Portfolio.Database.Seed.csproj
RUN dotnet publish Portfolio.Database.Seed/Portfolio.Database.Seed.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app

COPY --from=build /app .

ENTRYPOINT ["dotnet", "Portfolio.Database.Seed.dll"]