using DbUp;
using Portfolio.Database.Shared.Configuration;

namespace Portfolio.Database.Migrations;

public sealed class DatabaseMigrator
{
    public void Run()
    {
        var connectionString = DatabaseConfiguration.GetConnectionString();

        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(typeof(DatabaseMigrator).Assembly)
            .LogToConsole()
            .Build();

        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
            throw result.Error;
    }
}