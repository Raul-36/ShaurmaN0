using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;

namespace ShaurmaN0App.Repositories
{
    public class MenusSQLRepository : IMenusRepository
    {
        private readonly IConfiguration configuration;

        public MenusSQLRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task CreateAsync(Menus Menus)
        {
            var connection = new SqlConnection(this.configuration.GetConnectionString("SqlDb"));
            string sql = "INSERT INTO Menus (Name, MenusCategoryId, Price) VALUES (@Name, @MenusCategoryId, @Price)";
            await connection.ExecuteAsync(sql, Menus);
        }

        public async Task DeleteAsync(Guid id)
        {
            var connection = new SqlConnection(this.configuration.GetConnectionString("SqlDb"));
            string sql = "DELETE FROM Menus WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Menus>> GetAllAsync()
        {
            var connection = new SqlConnection(this.configuration.GetConnectionString("SqlDb"));
            string sql = "SELECT * FROM Menus";
            return await connection.QueryAsync<Menus>(sql);
        }

        public async Task UpdateAsync(Menus Menus)
        {
            var connection = new SqlConnection(this.configuration.GetConnectionString("SqlDb"));
            string sql = "UPDATE Menus SET Name = @Name Price = @Price, MenusCategoryId = @MenusCategoryId WHERE Id = @Id";
            await connection.ExecuteAsync(sql, Menus);
        }
    }
    }
}