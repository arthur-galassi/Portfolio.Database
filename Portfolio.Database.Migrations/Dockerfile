FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore Portfolio.Database.Migrations/Portfolio.Database.Migrations.csproj
RUN dotnet publish Portfolio.Database.Migrations/Portfolio.Database.Migrations.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app

COPY --from=build /app .

ENTRYPOINT ["dotnet", "Portfolio.Database.Migrations.dll"]