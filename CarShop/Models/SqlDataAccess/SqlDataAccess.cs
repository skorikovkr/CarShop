using Dapper;
using Npgsql;
using System.Data;

namespace CarShop.Models.SqlDataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
           string sqlCommand,
           U parameters,
           string connectionStringId = "Default")
        {
            var connectionString = _config.GetConnectionString(connectionStringId);
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                return await connection.QueryAsync<T>(sqlCommand, parameters);
            }
        }

        public async Task SaveData<T>(
           string sqlCommand,
           T parameters,
           string connectionStringId = "Default")
        {
            var connectionString = _config.GetConnectionString(connectionStringId);
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sqlCommand, parameters);
            }
        }
    }
}
