using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;

namespace ShaurmaN0App.Repositories
{
    public class MenusCategorySQLRepository : IMenusCategoryRepository
    {
        private readonly IConfiguration configuration;

        public MenusCategorySQLRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task CreateAsync(MenusCategory menusCategory)
        {
            var connection = new SqlConnection(this.configuration.GetConnectionString("SqlDb"));
            string sql = "INSERT INTO MenusCategory (Name) VALUES (@Name)";
            await connection.ExecuteAsync(sql, menusCategory);
        }

        public async Task DeleteAsync(Guid id)
        {
            var connection = new SqlConnection(this.configuration.GetConnectionString("SqlDb"));
            string sql = "DELETE FROM MenusCategory WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<MenusCategory>> GetAllAsync()
        {
            var connection = new SqlConnection(this.configuration.GetConnectionString("SqlDb"));
            string sql = "SELECT * FROM MenusCategory";
            return await connection.QueryAsync<MenusCategory>(sql);
        }

        public async Task<MenusCategory> GetByIdAsync(Guid id)
        {
            var connection = new SqlConnection(this.configuration.GetConnectionString("SqlDb"));
            string sql = "SELECT * FROM MenusCategory WHERE Id = @Id";
           return await connection.QuerySingleAsync <MenusCategory>(sql, new { Id = id });
        }

        public async Task UpdateAsync(MenusCategory menusCategory)
        {
            var connection = new SqlConnection(this.configuration.GetConnectionString("SqlDb"));
            string sql = "UPDATE MenusCategory SET Name = @Name WHERE Id = @Id";
            await connection.ExecuteAsync(sql, menusCategory);
        }
    }
}