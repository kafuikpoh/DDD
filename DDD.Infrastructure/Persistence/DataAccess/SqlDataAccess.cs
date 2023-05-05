using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DDD.Infrastructure.Persistence.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task LoadData<T, T1, T2>(string sql, Func<T, T1, T2, T>  parameters, string splitOn, string connectionStringName)
    {
        string? connectionString = _config.GetConnectionString(connectionStringName);

        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            var rows = await connection.QueryAsync<T, T1, T2, T>(sql, parameters, splitOn: splitOn, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
    {
        string? connectionString = _config.GetConnectionString(connectionStringName);

        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            var rows = await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }

}