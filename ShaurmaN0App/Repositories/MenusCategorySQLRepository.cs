using System.Data.Entity.Migrations;
using Microsoft.EntityFrameworkCore;
using ShaurmaN0App.Data;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;

namespace ShaurmaN0App.Repositories
{
    public class MenusCategorySQLRepository : IMenusCategoryRepository
    {
        private readonly ShaurmaDbContext context;

        public MenusCategorySQLRepository(ShaurmaDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(MenusCategory menusCategory)
        {
            context.MenusCategories.Add(menusCategory);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var mC = context.MenusCategories.FirstOrDefault(m => m.Id == id, null);
            if (mC != null)
            {
                context.MenusCategories.Remove(mC);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MenusCategory>> GetAllAsync()
        {
            var arr = await context.MenusCategories.ToListAsync();
            return (arr == null) ? Enumerable.Empty<MenusCategory>() : arr;
        }

        public async Task<MenusCategory?> GetByIdAsync(Guid id)
        {
           return await context.MenusCategories.FirstOrDefaultAsync(m => m.Id==id);
        }

        public async Task UpdateAsync(MenusCategory menusCategory)
        {
           context.MenusCategories.Update(menusCategory);
           await context.SaveChangesAsync();
        }
    }
}