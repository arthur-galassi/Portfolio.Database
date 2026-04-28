using Microsoft.Extensions.Configuration;
using Portfolio.Database.Shared.Constants;

namespace Portfolio.Database.Shared.Configuration
{
    public static class DatabaseConfiguration
    {
        public static string GetConnectionString()
        {
            var basePath = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(
                DatabaseConstants.ConnectionStringName);

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string não configurada.");

            return connectionString;
        }
    }
}