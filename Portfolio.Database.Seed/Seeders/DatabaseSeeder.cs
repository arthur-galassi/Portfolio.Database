using Portfolio.Database.Seed.Seeders.Abstractions;

namespace Portfolio.Database.Seed.Seeders;

public sealed class DatabaseSeeder
{
    private readonly IEnumerable<IDatabaseSeeder> _seeders;

    public DatabaseSeeder(IEnumerable<IDatabaseSeeder> seeders)
    {
        _seeders = seeders;
    }

    public async Task SeedAsync()
    {
        var orderedSeeders = _seeders
            .OrderBy(seeder => seeder.Order);

        foreach (var seeder in orderedSeeders)
        {
            Console.WriteLine($"Executando {seeder.GetType().Name}...");
            await seeder.SeedAsync();
        }
    }
}