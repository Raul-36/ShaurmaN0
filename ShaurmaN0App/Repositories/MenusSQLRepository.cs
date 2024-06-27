using ShaurmaN0App.Data;
using ShaurmaN0App.Models;
using System.Data.Entity.Migrations;
using Microsoft.EntityFrameworkCore;
using ShaurmaN0App.Data;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;
namespace ShaurmaN0App.Repositories
{
    public class MenusSQLRepository : IMenusRepository
    {
        private readonly ShaurmaDbContext context;

        public MenusSQLRepository(ShaurmaDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(Menus menus)
        {
            context.Menus.Add(menus);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var mC = context.Menus.FirstOrDefault(m => m.Id == id, null);
            if (mC != null)
            {
                context.Menus.Remove(mC);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Menus>> GetAllAsync()
        {
            if (context.Menus == null)
            {
                throw new InvalidOperationException("Menus DbSet is not initialized.");
            }
            return await context.Menus.ToArrayAsync();
        }


        public async Task UpdateAsync(Menus menus)
        {
            context.Menus.Update(menus);
            await context.SaveChangesAsync();
        }
    }
}