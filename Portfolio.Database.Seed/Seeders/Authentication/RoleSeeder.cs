using Npgsql;
using Portfolio.Database.Seed.Seeders.Abstractions;
using Portfolio.Database.Shared.Configuration;

public sealed class RoleSeeder : IDatabaseSeeder
{
    public int Order => 1;

    public async Task SeedAsync()
    {
        var sql = """
        INSERT INTO authentication.roles (id, name)
        VALUES
            (gen_random_uuid(), 'Admin'),
            (gen_random_uuid(), 'Manager'),
            (gen_random_uuid(), 'User'),
            (gen_random_uuid(), 'Guest')
        ON CONFLICT (name) DO NOTHING;
        """;

        await ExecuteAsync(sql);
    }

    private static async Task ExecuteAsync(string sql)
    {
        await using var connection = new NpgsqlConnection(DatabaseConfiguration.GetConnectionString());
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(sql, connection);
        await command.ExecuteNonQueryAsync();
    }
}