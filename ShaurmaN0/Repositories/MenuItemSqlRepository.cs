using System.Data.SqlClient;
using Dapper;
using ShaurmaN0.Models;

namespace ShaurmaN0.Repositories;

    public class MenuItemSqlRepository
    {
        private const string connectionString = "Server=localhost;Database=ShaurmaN0;Integrated Security=SSPI;";

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync() {
            var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<MenuItem>("select * from MenuItem");
        }
    }