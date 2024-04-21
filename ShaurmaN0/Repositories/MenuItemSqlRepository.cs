using System.Data.SqlClient;
using Dapper;
using ShaurmaN0.Models;

namespace ShaurmaN0.Repositories;

    public class MenuItemSqlRepository
    {
        private const string connectionString = "Server=localhost;Database=ShaurmaN0;";

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync() {
            var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<MenuItem>("select * from MenuItem");
        }
         public async Task<IEnumerable<MenuItem>> GetMenuItemByIdAsync(int id) {
            var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<MenuItem>("select * from MenuItem where Id = @id", new { id = id });
        }
    }