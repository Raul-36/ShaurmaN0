using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ShaurmaN0.Models;

namespace ShaurmaN0.Repositories;
    public class OrderSqlRepository
    {
      
        private const string connectionString = "Server=localhost;Database=ShaurmaN0;";

        public async Task<IEnumerable<Order>> GetAllOrdersAsync() {
            var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Order>("select * from Order");
        }
        public async Task CreateNewOrderAsync(int id) {
            var connection = new SqlConnection(connectionString);
            await connection.QueryAsync<Order>(@"insert into MenuItem(menuItemId)
                values (@menuItemId);", new { menuItemId = id });
        }
    }
