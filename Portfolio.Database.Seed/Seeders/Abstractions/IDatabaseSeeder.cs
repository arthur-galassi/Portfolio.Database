namespace Portfolio.Database.Seed.Seeders.Abstractions;

public interface IDatabaseSeeder
{
    int Order { get; }
    Task SeedAsync();
}