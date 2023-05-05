
namespace DDD.Infrastructure.Persistence.DataAccess;

public interface ISqlDataAccess
{
    Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
    Task LoadData<T, T1, T2>(string sql, Func<T, T1, T2, T> parameters, string splitOn, string connectionStringName);
}