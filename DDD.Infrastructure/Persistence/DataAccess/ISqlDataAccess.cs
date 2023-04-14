

namespace DDD.Infrastructure.Persistence.DataAccess;

public interface ISqlDataAccess
{
    Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
}