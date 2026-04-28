namespace Portfolio.Database.Migrations;

public static class Program
{
    public static int Main(string[] args)
    {
        try
        {
            var migrator = new DatabaseMigrator();
            migrator.Run();

            Console.WriteLine("Migrations executadas com sucesso.");
            return 0;
        }
        catch (Exception exception)
        {
            Console.WriteLine("Erro ao executar migrations:");
            Console.WriteLine(exception.Message);
            return 1;
        }
    }
}