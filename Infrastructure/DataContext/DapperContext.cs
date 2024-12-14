using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    string _connectionString="Server=localhost; Port=5432; Database=TestDb;User Id=postgres;Password=1234;";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}