using ShaurmaN0App.Data;
using ShaurmaN0App.Models;
using Microsoft.EntityFrameworkCore;
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
            context.MenusCategory.Add(menusCategory);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Console.WriteLine(id);
            var mC = context.MenusCategory.Find(id);
            if (mC == null)
            {
                throw new InvalidOperationException("Entity not found");
            }
            Console.WriteLine(mC.Id);
            context.MenusCategory.Remove(mC);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<MenusCategory>> GetAllAsync()
        {
            var arr = await context.MenusCategory.ToListAsync();
            return (arr == null) ? Enumerable.Empty<MenusCategory>() : arr;
        }

        public async Task<MenusCategory?> GetByIdAsync(Guid id)
        {
            return await context.MenusCategory.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(MenusCategory menusCategory)
        {
            var existingEntity = await context.MenusCategory.FindAsync(menusCategory.Id);
            if (existingEntity != null)
            {
                context.Entry(existingEntity).State = EntityState.Detached;
            }
            context.MenusCategory.Update(menusCategory);
            await context.SaveChangesAsync();
        }
    }
}